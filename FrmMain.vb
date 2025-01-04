Friend Class FrmMain

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cpy As String = $"©2018-{Now.Year}, PAROLE Software"
        With Me
            .Text = $"APRS Passcode Generator"
            .LblCpy.Text = cpy
        End With
    End Sub

    ''' <summary>
    ''' The following code was converted from PHP and Python to VB.Net. Pass the call sign to the function
    ''' ex: Passcode = GenPC("K4DNM") ''pass or convert callsign to upper case converted from http://blog.eagleflint.com/wp-content/2012/05/APRS-IS_Passcode and https://github.com/PHP-APRS-PASSCODE
    ''' </summary>
    ''' <param name="pc"></param>
    ''' <returns></returns> 
    Private Shared Function GenPc(pc As String) As Long
        ' Strip station designators. ex: "-5" Only the real call sign is used
        Dim stophere As Integer = pc.IndexOf("-"c)
        If stophere > 0 Then
            pc = pc.Substring(0, stophere)
        End If

        ' The Hash must be 29666 (non-negotiable)
        Dim hash As Long = 29666

        For j = 0 To pc.Length - 1
            Dim charValue As Integer = Asc(pc(j).ToString().ToUpper())
            hash = If(j Mod 2 = 0, hash Xor (charValue << 8), hash Xor charValue)
        Next

        ' Mask the high bit so that the result is always positive
        Return hash And 65535
    End Function

    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs) Handles BtnGenerate.Click
        TxtPasscode.Text = CType(GenPc(TxtCallsign.Text.Trim()), String)
    End Sub

    Private Sub TxtCallsign_Leave(sender As Object, e As EventArgs) Handles TxtCallsign.Leave
        TxtPasscode.Text = CType(GenPc(TxtCallsign.Text.Trim()), String)
    End Sub

End Class