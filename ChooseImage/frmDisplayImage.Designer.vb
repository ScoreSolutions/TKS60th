<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDisplayImage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDisplayImage))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pbPostFacebook = New System.Windows.Forms.PictureBox()
        Me.pbClose = New System.Windows.Forms.PictureBox()
        Me.pb = New System.Windows.Forms.PictureBox()
        Me.pbDisplay = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.pbPostFacebook, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'pbPostFacebook
        '
        Me.pbPostFacebook.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbPostFacebook.Image = CType(resources.GetObject("pbPostFacebook.Image"), System.Drawing.Image)
        Me.pbPostFacebook.Location = New System.Drawing.Point(191, 997)
        Me.pbPostFacebook.Name = "pbPostFacebook"
        Me.pbPostFacebook.Size = New System.Drawing.Size(163, 69)
        Me.pbPostFacebook.TabIndex = 5
        Me.pbPostFacebook.TabStop = False
        '
        'pbClose
        '
        Me.pbClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbClose.Image = CType(resources.GetObject("pbClose.Image"), System.Drawing.Image)
        Me.pbClose.Location = New System.Drawing.Point(408, 997)
        Me.pbClose.Name = "pbClose"
        Me.pbClose.Size = New System.Drawing.Size(162, 69)
        Me.pbClose.TabIndex = 6
        Me.pbClose.TabStop = False
        '
        'pb
        '
        Me.pb.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pb.BackgroundImage = CType(resources.GetObject("pb.BackgroundImage"), System.Drawing.Image)
        Me.pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pb.Location = New System.Drawing.Point(0, 0)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(800, 1280)
        Me.pb.TabIndex = 43
        Me.pb.TabStop = False
        '
        'pbDisplay
        '
        Me.pbDisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbDisplay.Location = New System.Drawing.Point(43, 202)
        Me.pbDisplay.Name = "pbDisplay"
        Me.pbDisplay.Size = New System.Drawing.Size(700, 700)
        Me.pbDisplay.TabIndex = 44
        Me.pbDisplay.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(395, 70)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(162, 69)
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(178, 70)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(163, 69)
        Me.PictureBox2.TabIndex = 45
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'frmDisplayImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(800, 780)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.pbDisplay)
        Me.Controls.Add(Me.pbClose)
        Me.Controls.Add(Me.pbPostFacebook)
        Me.Controls.Add(Me.pb)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDisplayImage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.pbPostFacebook, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents pbPostFacebook As System.Windows.Forms.PictureBox
    Friend WithEvents pbClose As System.Windows.Forms.PictureBox
    Friend WithEvents pb As System.Windows.Forms.PictureBox
    Friend WithEvents pbDisplay As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class
