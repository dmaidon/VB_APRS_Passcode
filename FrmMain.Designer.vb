<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtCallsign = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtPasscode = New System.Windows.Forms.TextBox()
        Me.BtnGenerate = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(11, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Callsign:"
        '
        'TxtCallsign
        '
        Me.TxtCallsign.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCallsign.Location = New System.Drawing.Point(57, 9)
        Me.TxtCallsign.Name = "TxtCallsign"
        Me.TxtCallsign.Size = New System.Drawing.Size(100, 20)
        Me.TxtCallsign.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(11, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Passcode:"
        '
        'TxtPasscode
        '
        Me.TxtPasscode.Location = New System.Drawing.Point(70, 41)
        Me.TxtPasscode.Name = "TxtPasscode"
        Me.TxtPasscode.Size = New System.Drawing.Size(74, 20)
        Me.TxtPasscode.TabIndex = 1
        '
        'BtnGenerate
        '
        Me.BtnGenerate.Location = New System.Drawing.Point(47, 73)
        Me.BtnGenerate.Name = "BtnGenerate"
        Me.BtnGenerate.Size = New System.Drawing.Size(75, 23)
        Me.BtnGenerate.TabIndex = 2
        Me.BtnGenerate.Text = "Generate"
        Me.BtnGenerate.UseVisualStyleBackColor = true
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
        Me.Label3.Location = New System.Drawing.Point(13, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "©2018, PAROLE Software"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(169, 128)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnGenerate)
        Me.Controls.Add(Me.TxtPasscode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtCallsign)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = false
        Me.Name = "FrmMain"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "APRS Passcode Generator"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TxtCallsign As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtPasscode As TextBox
    Friend WithEvents BtnGenerate As Button
    Friend WithEvents Label3 As Label
End Class
