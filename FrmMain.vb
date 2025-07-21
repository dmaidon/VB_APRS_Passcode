Friend Class FrmMain

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim currentYear As Integer = DateTime.Now.Year
        Dim cpy As String = $"©2018-{currentYear}, PAROLE Software{vbLf}All rights reserved."

        Text = "APRS Passcode Generator"
        LblCpy.Text = cpy
    End Sub

    ''' <summary>
    ''' Generates APRS-IS passcode from amateur radio call sign.
    ''' Converted from PHP/Python implementations with performance optimizations.
    '''
    ''' The passcode authenticates with APRS-IS servers using a standardized algorithm:
    ''' - Starts with hash value 29666 (APRS standard)
    ''' - XORs ASCII values: even positions shifted left 8 bits, odd positions unchanged
    ''' - Result masked to 16-bit positive integer (0-65535)
    '''
    ''' Example: GenPc("K4DNM") returns the appropriate passcode
    ''' References:
    ''' - http://blog.eagleflint.com/wp-content/2012/05/APRS-IS_Passcode
    ''' - https://github.com/PHP-APRS-PASSCODE
    ''' </summary>
    ''' <param name="callSign">Amateur radio call sign (station designators like -5 are automatically stripped)</param>
    ''' <returns>16-bit APRS passcode (0-65535)</returns>
    Private Shared Function GenPc(callSign As String) As Integer
        If String.IsNullOrEmpty(callSign) Then Return 0

        ' Extract base call sign (remove SSID like "-5")
        Dim baseCallSign As String = callSign.Split("-"c)(0).ToUpperInvariant()

        ' Initialize with APRS standard hash seed
        Const APRS_HASH_SEED As Integer = 29666
        Dim hash As Integer = APRS_HASH_SEED

        ' Process each character without intermediate allocations
        For i As Integer = 0 To baseCallSign.Length - 1
            Dim asciiValue As Integer = AscW(baseCallSign(i))

            ' XOR: even positions (0,2,4...) shift left 8 bits, odd positions (1,3,5...) unchanged
            hash = hash Xor If(i Mod 2 = 0, asciiValue << 8, asciiValue)
        Next

        ' Return 16-bit positive result
        Return hash And &HFFFF
    End Function

    ''' <summary>
    ''' Updates the passcode field when call sign changes or generate button is clicked.
    ''' </summary>
    Private Sub UpdatePasscodeHandler(sender As Object, e As EventArgs) Handles BtnGenerate.Click, TxtCallsign.Leave
        Dim callSign As String = TxtCallsign.Text?.Trim()
        TxtPasscode.Text = If(String.IsNullOrWhiteSpace(callSign), "", GenPc(callSign).ToString())
    End Sub

End Class