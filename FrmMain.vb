Imports System
Imports System.Collections.Concurrent

Friend Class FrmMain

    ' Simple in-memory cache for repeated passcode requests (thread-safe)
    Private Shared ReadOnly _cache As New ConcurrentDictionary(Of String, UShort)(StringComparer.OrdinalIgnoreCase)

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim currentYear As Integer = DateTime.Now.Year
        Dim cpy As String = $"©2018-{currentYear}, PAROLE Software{vbLf}All rights reserved."

        Text = "APRS Passcode Generator"
        LblCpy.Text = cpy
    End Sub

    ''' <summary>
    ''' Generates APRS-IS passcode from amateur radio call sign (public enhanced API).
    ''' Performs normalization (trim, uppercase, remove SSID, strip invalid chars) and caches result.
    ''' </summary>
    ''' <param name="callSign">Raw amateur radio call sign (may include ssid like -7)</param>
    ''' <returns>16-bit APRS passcode (0-65535) as UShort</returns>
    Public Shared Function GeneratePasscode(callSign As String) As UShort
        If String.IsNullOrWhiteSpace(callSign) Then Return 0US
        Dim normalized As String = NormalizeCallSign(callSign)
        If normalized.Length = 0 Then Return 0US

        ' Return from cache if available
        Return _cache.GetOrAdd(normalized, Function(key) ComputePasscodeCore(key))
    End Function

    ''' <summary>
    ''' Original implementation retained for compatibility. Use <see cref="GeneratePasscode"/> instead.
    ''' </summary>
    <Obsolete("Use GeneratePasscode(String) instead.")>
    Private Shared Function GenPc(callSign As String) As Integer
        Return CInt(GeneratePasscode(callSign))
    End Function

    ''' <summary>
    ''' Normalizes a call sign: trims, uppercases, removes SSID after first dash, removes non A-Z0-9 chars.
    ''' </summary>
    Private Shared Function NormalizeCallSign(input As String) As String
        Dim span As String = input.Trim().ToUpperInvariant()
        If span.Length = 0 Then Return String.Empty

        ' Remove SSID (portion after first '-')
        Dim dashIndex As Integer = span.IndexOf("-"c)
        If dashIndex >= 0 Then span = span.Substring(0, dashIndex)

        ' Filter allowed characters (A-Z 0-9)
        Dim filtered = New System.Text.StringBuilder(span.Length)
        For Each ch As Char In span
            If (ch >= "A"c AndAlso ch <= "Z"c) OrElse (ch >= "0"c AndAlso ch <= "9"c) Then
                filtered.Append(ch)
            End If
        Next
        Return filtered.ToString()
    End Function

    ''' <summary>
    ''' Core APRS passcode computation (no normalization / caching). Expects already-normalized call sign.
    ''' Algorithm: seed 29666, XOR alternating shifted left (even index) and unchanged (odd index) ASCII.
    ''' </summary>
    Private Shared Function ComputePasscodeCore(baseCallSign As String) As UShort
        Const APRS_HASH_SEED As Integer = 29666
        Dim hash As Integer = APRS_HASH_SEED

        For i As Integer = 0 To baseCallSign.Length - 1
            Dim asciiValue As Integer = AscW(baseCallSign.Chars(i))
            hash = hash Xor If(i Mod 2 = 0, asciiValue << 8, asciiValue)
        Next

        Return CUShort(hash And &HFFFF)
    End Function

    ''' <summary>
    ''' Updates the passcode field when call sign changes or generate button is clicked.
    ''' </summary>
    Private Sub UpdatePasscodeHandler(sender As Object, e As EventArgs) Handles BtnGenerate.Click, TxtCallsign.Leave
        Dim callSign As String = TxtCallsign.Text.Trim()
        TxtPasscode.Text = If(callSign.Length = 0, "", GeneratePasscode(callSign).ToString())
    End Sub

End Class