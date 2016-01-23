<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMapTagPhoto
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
        Me.TimerCreateFolder = New System.Windows.Forms.Timer(Me.components)
        Me.lblCurrentTag = New System.Windows.Forms.Label()
        Me.TimerInsertFileName = New System.Windows.Forms.Timer(Me.components)
        Me.DeteleTempFile = New System.Windows.Forms.Timer(Me.components)
        Me.TimerResize = New System.Windows.Forms.Timer(Me.components)
        Me.TimerMovePhoto = New System.Windows.Forms.Timer(Me.components)
        Me.TimerCheckLastCurrentStatus = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'TimerCreateFolder
        '
        Me.TimerCreateFolder.Enabled = True
        Me.TimerCreateFolder.Interval = 500
        '
        'lblCurrentTag
        '
        Me.lblCurrentTag.AutoSize = True
        Me.lblCurrentTag.Location = New System.Drawing.Point(91, 75)
        Me.lblCurrentTag.Name = "lblCurrentTag"
        Me.lblCurrentTag.Size = New System.Drawing.Size(0, 13)
        Me.lblCurrentTag.TabIndex = 0
        '
        'TimerInsertFileName
        '
        Me.TimerInsertFileName.Enabled = True
        Me.TimerInsertFileName.Interval = 500
        '
        'DeteleTempFile
        '
        Me.DeteleTempFile.Enabled = True
        Me.DeteleTempFile.Interval = 500
        '
        'TimerResize
        '
        Me.TimerResize.Enabled = True
        Me.TimerResize.Interval = 500
        '
        'TimerMovePhoto
        '
        Me.TimerMovePhoto.Enabled = True
        Me.TimerMovePhoto.Interval = 500
        '
        'TimerCheckLastCurrentStatus
        '
        Me.TimerCheckLastCurrentStatus.Enabled = True
        Me.TimerCheckLastCurrentStatus.Interval = 500
        '
        'frmMapTagPhoto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(446, 261)
        Me.Controls.Add(Me.lblCurrentTag)
        Me.Name = "frmMapTagPhoto"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TimerCreateFolder As System.Windows.Forms.Timer
    Friend WithEvents lblCurrentTag As System.Windows.Forms.Label
    Friend WithEvents TimerInsertFileName As System.Windows.Forms.Timer
    Friend WithEvents DeteleTempFile As System.Windows.Forms.Timer
    Friend WithEvents TimerResize As System.Windows.Forms.Timer
    Friend WithEvents TimerMovePhoto As System.Windows.Forms.Timer
    Friend WithEvents TimerCheckLastCurrentStatus As System.Windows.Forms.Timer

End Class
