<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLuckyDrawPlayer
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCompanyName = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblPlayerName = New System.Windows.Forms.Label()
        Me.lblTagNo = New System.Windows.Forms.Label()
        Me.lblCardTag = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Player Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(41, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Company"
        '
        'lblCompanyName
        '
        Me.lblCompanyName.AutoSize = True
        Me.lblCompanyName.Location = New System.Drawing.Point(154, 69)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Size = New System.Drawing.Size(0, 13)
        Me.lblCompanyName.TabIndex = 4
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'lblPlayerName
        '
        Me.lblPlayerName.AutoSize = True
        Me.lblPlayerName.Location = New System.Drawing.Point(154, 39)
        Me.lblPlayerName.Name = "lblPlayerName"
        Me.lblPlayerName.Size = New System.Drawing.Size(0, 13)
        Me.lblPlayerName.TabIndex = 3
        '
        'lblTagNo
        '
        Me.lblTagNo.AutoSize = True
        Me.lblTagNo.Location = New System.Drawing.Point(221, 124)
        Me.lblTagNo.Name = "lblTagNo"
        Me.lblTagNo.Size = New System.Drawing.Size(0, 13)
        Me.lblTagNo.TabIndex = 6
        Me.lblTagNo.Visible = False
        '
        'lblCardTag
        '
        Me.lblCardTag.AutoSize = True
        Me.lblCardTag.Location = New System.Drawing.Point(229, 132)
        Me.lblCardTag.Name = "lblCardTag"
        Me.lblCardTag.Size = New System.Drawing.Size(0, 13)
        Me.lblCardTag.TabIndex = 8
        Me.lblCardTag.Visible = False
        '
        'frmLuckyDrawPlayer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 261)
        Me.Controls.Add(Me.lblCardTag)
        Me.Controls.Add(Me.lblTagNo)
        Me.Controls.Add(Me.lblCompanyName)
        Me.Controls.Add(Me.lblPlayerName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmLuckyDrawPlayer"
        Me.Text = "Lucky Draw Player"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblCompanyName As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblPlayerName As System.Windows.Forms.Label
    Friend WithEvents lblTagNo As System.Windows.Forms.Label
    Friend WithEvents lblCardTag As System.Windows.Forms.Label

End Class
