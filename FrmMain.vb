Friend Class FrmMain

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim currentYear As Integer = Now.Year
        Dim cpy As String = $"©2018-{currentYear}, PAROLE Software{vbLf}All rights reserved."
        With Me
            .Text = "APRS Passcode Generator"
            .LblCpy.Text = cpy
        End With
    End Sub

    ''' <summary>
    ''' The following code was converted from PHP and Python to VB.Net. Pass the call sign to the function
    ''' and it will return the passcode as a Long integer.
    ''' The passcode is used to authenticate with the APRS-IS servers.
    '''
    ''' The passcode is generated from the call sign by XORing the ASCII values of the characters in the call sign.
    ''' The first character is shifted left by 8 bits, and the second character is not shifted.
    ''' This process continues for each character in the call sign.
    ''' The result is then masked to ensure it is always a positive number.
    '''
    ''' The hash must be 29666 (non-negotiable) and the result is masked to ensure it is always a positive number.
    '''
    ''' Example usage:
    ''' Dim passcode As Long = GenPc("K4DNM")
    ''' http://blog.eagleflint.com/wp-content/2012/05/APRS-IS_Passcode
    ''' https://github.com/PHP-APRS-PASSCODE
    ''' </summary>
    ''' <param name="pc"></param>
    ''' <returns></returns>
    '''
    Private Shared Function GenPc(pc As String) As Long
        If String.IsNullOrEmpty(pc) Then Return 0

        ' Strip station designators. For example, "K4DNM-5" becomes "K4DNM".
        Dim hyphenIndex As Integer = pc.IndexOf("-"c)
        If hyphenIndex > 0 Then
            pc = pc.Substring(0, hyphenIndex)
        End If

        ' Convert the entire string to uppercase once.
        pc = pc.ToUpper()

        ' The hash must begin at 29666 (this constant is non-negotiable).
        Dim hash As Long = 29666

        For j As Integer = 0 To pc.Length - 1
            Dim charValue As Integer = AscW(pc(j))
            ' For even positions, shift left by 8 bits; for odd positions, use the original value.
            If j Mod 2 = 0 Then
                hash = hash Xor (charValue << 8)
            Else
                hash = hash Xor charValue
            End If
        Next

        ' Mask the high bit so the result is always positive (i.e., within 0 to 65535).
        Return hash And &HFFFF
    End Function

    ''' <summary>
    ''' Updates the passcode textbox based on the current callsign.
    ''' </summary>
    Private Sub UpdatePasscode()
        Dim callSign As String = TxtCallsign.Text.Trim()
        ' Optionally handle empty input.
        If String.IsNullOrEmpty(callSign) Then
            TxtPasscode.Text = String.Empty
        Else
            TxtPasscode.Text = GenPc(callSign).ToString()
        End If
    End Sub

    Private Sub UpdatePasscodeHandler(sender As Object, e As EventArgs) Handles BtnGenerate.Click, TxtCallsign.Leave
        UpdatePasscode()
    End Sub

End Class