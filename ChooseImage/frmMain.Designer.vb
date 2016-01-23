<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.txtTagNo = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.pbClear = New System.Windows.Forms.PictureBox()
        Me.pb = New System.Windows.Forms.PictureBox()
        Me.pnlMain = New System.Windows.Forms.Panel()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbClear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtTagNo
        '
        Me.txtTagNo.Location = New System.Drawing.Point(52, 50)
        Me.txtTagNo.Name = "txtTagNo"
        Me.txtTagNo.Size = New System.Drawing.Size(197, 20)
        Me.txtTagNo.TabIndex = 36
        Me.txtTagNo.Visible = False
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.Font = New System.Drawing.Font("Segoe Marker", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(71, 210)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(0, 31)
        Me.lblName.TabIndex = 35
        '
        'pbClose
        '
        Me.pbClose.BackgroundImage = CType(resources.GetObject("pbClose.BackgroundImage"), System.Drawing.Image)
        Me.pbClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbClose.Location = New System.Drawing.Point(760, 0)
        Me.pbClose.Name = "pbClose"
        Me.pbClose.Size = New System.Drawing.Size(40, 35)
        Me.pbClose.TabIndex = 38
        Me.pbClose.TabStop = False
        '
        'Timer2
        '
        '
        'pbClear
        '
        Me.pbClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbClear.Image = CType(resources.GetObject("pbClear.Image"), System.Drawing.Image)
        Me.pbClear.Location = New System.Drawing.Point(335, 1198)
        Me.pbClear.Name = "pbClear"
        Me.pbClear.Size = New System.Drawing.Size(160, 69)
        Me.pbClear.TabIndex = 40
        Me.pbClear.TabStop = False
        '
        'pb
        '
        Me.pb.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pb.BackgroundImage = CType(resources.GetObject("pb.BackgroundImage"), System.Drawing.Image)
        Me.pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pb.Location = New System.Drawing.Point(0, 0)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(800, 1280)
        Me.pb.TabIndex = 41
        Me.pb.TabStop = False
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Location = New System.Drawing.Point(53, 245)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(697, 933)
        Me.pnlMain.TabIndex = 33
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(800, 780)
        Me.Controls.Add(Me.pbClear)
        Me.Controls.Add(Me.pbClose)
        Me.Controls.Add(Me.txtTagNo)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pb)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbClear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtTagNo As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents pbClear As System.Windows.Forms.PictureBox
    Friend WithEvents pb As System.Windows.Forms.PictureBox
    Friend WithEvents pnlMain As System.Windows.Forms.Panel

End Class
