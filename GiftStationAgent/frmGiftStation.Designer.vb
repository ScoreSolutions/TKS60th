<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGiftStation
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.rownumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.customer_name_th = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.company_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.lblNo = New System.Windows.Forms.Label()
        Me.lblYes = New System.Windows.Forms.Label()
        Me.PanelNo = New System.Windows.Forms.Panel()
        Me.PanelYes = New System.Windows.Forms.Panel()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rownumber, Me.customer_name_th, Me.company_name, Me.IsStatus})
        Me.DataGridView1.Location = New System.Drawing.Point(41, 229)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.DataGridView1.RowTemplate.Height = 40
        Me.DataGridView1.Size = New System.Drawing.Size(1206, 411)
        Me.DataGridView1.TabIndex = 0
        '
        'rownumber
        '
        Me.rownumber.DataPropertyName = "rownumber"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rownumber.DefaultCellStyle = DataGridViewCellStyle2
        Me.rownumber.HeaderText = "ลำดับ"
        Me.rownumber.Name = "rownumber"
        Me.rownumber.ReadOnly = True
        Me.rownumber.Width = 80
        '
        'customer_name_th
        '
        Me.customer_name_th.DataPropertyName = "customer_name_th"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.customer_name_th.DefaultCellStyle = DataGridViewCellStyle3
        Me.customer_name_th.HeaderText = "ชื่อ - นามสกุล"
        Me.customer_name_th.Name = "customer_name_th"
        Me.customer_name_th.ReadOnly = True
        Me.customer_name_th.Width = 350
        '
        'company_name
        '
        Me.company_name.DataPropertyName = "company_name"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.company_name.DefaultCellStyle = DataGridViewCellStyle4
        Me.company_name.HeaderText = "หน่วยงาน/บริษัท"
        Me.company_name.Name = "company_name"
        Me.company_name.ReadOnly = True
        Me.company_name.Width = 500
        '
        'IsStatus
        '
        Me.IsStatus.DataPropertyName = "IsStatus"
        Me.IsStatus.HeaderText = "IsStatus"
        Me.IsStatus.Name = "IsStatus"
        Me.IsStatus.ReadOnly = True
        Me.IsStatus.Visible = False
        '
        'Timer1
        '
        '
        'btnStart
        '
        Me.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnStart.BackgroundImage = Global.GiftStationAgent.My.Resources.Resources.srtBtn
        Me.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnStart.Location = New System.Drawing.Point(508, 678)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(164, 59)
        Me.btnStart.TabIndex = 1
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnStop.BackgroundImage = Global.GiftStationAgent.My.Resources.Resources.stpBtn
        Me.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnStop.Location = New System.Drawing.Point(508, 678)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(164, 59)
        Me.btnStop.TabIndex = 2
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'lblNo
        '
        Me.lblNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblNo.AutoSize = True
        Me.lblNo.Location = New System.Drawing.Point(178, 715)
        Me.lblNo.Name = "lblNo"
        Me.lblNo.Size = New System.Drawing.Size(58, 13)
        Me.lblNo.TabIndex = 3
        Me.lblNo.Text = "ยังไม่ได้รับ"
        '
        'lblYes
        '
        Me.lblYes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblYes.AutoSize = True
        Me.lblYes.Location = New System.Drawing.Point(80, 715)
        Me.lblYes.Name = "lblYes"
        Me.lblYes.Size = New System.Drawing.Size(40, 13)
        Me.lblYes.TabIndex = 4
        Me.lblYes.Text = "รับแล้ว"
        '
        'PanelNo
        '
        Me.PanelNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelNo.Location = New System.Drawing.Point(139, 710)
        Me.PanelNo.Name = "PanelNo"
        Me.PanelNo.Size = New System.Drawing.Size(33, 18)
        Me.PanelNo.TabIndex = 5
        '
        'PanelYes
        '
        Me.PanelYes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelYes.Location = New System.Drawing.Point(41, 710)
        Me.PanelYes.Name = "PanelYes"
        Me.PanelYes.Size = New System.Drawing.Size(33, 18)
        Me.PanelYes.TabIndex = 6
        '
        'frmGiftStation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.GiftStationAgent.My.Resources.Resources.bg_05
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1284, 741)
        Me.Controls.Add(Me.PanelYes)
        Me.Controls.Add(Me.PanelNo)
        Me.Controls.Add(Me.lblYes)
        Me.Controls.Add(Me.lblNo)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "frmGiftStation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gift Station"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents lblNo As System.Windows.Forms.Label
    Friend WithEvents lblYes As System.Windows.Forms.Label
    Friend WithEvents PanelNo As System.Windows.Forms.Panel
    Friend WithEvents PanelYes As System.Windows.Forms.Panel
    Friend WithEvents rownumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents customer_name_th As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents company_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsStatus As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
