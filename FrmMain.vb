Public Class FrmMain
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Me
            .Text = $"APRS Passcode Generator"
        End With
    End Sub

    Private Shared Function GenPc(pc As String) As Long
        'strip station designators. ex: "-5"  Only the real call sign is used
        Dim stophere As Integer = InStr(pc, "-") - 1
        If stophere > 0 Then
            pc = pc.Split("-"c)(0)
        End If

        ''the Hash must be 29666 (non-negotiable)
        Dim hash As Long = 29666

        For j = 1 To pc.Length
            If CBool(j Mod 2) Then
                hash = hash Xor (Asc(Mid(pc.ToUpper(), j, 1)) << 8)
            Else
                hash = hash Xor Asc(Mid(pc.ToUpper(), j, 1))
            End If
        Next

        ''mask the high bit so that the result is always positive
        GenPc = hash And 65535
    End Function

    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs) Handles BtnGenerate.Click
        TxtPasscode.Text = CType(GenPc(TxtCallsign.Text.Trim()), String)
    End Sub

    Private Sub TxtCallsign_Leave(sender As Object, e As EventArgs) Handles TxtCallsign.Leave
        TxtPasscode.Text = CType(GenPc(TxtCallsign.Text.Trim()), String)
    End Sub
End Class