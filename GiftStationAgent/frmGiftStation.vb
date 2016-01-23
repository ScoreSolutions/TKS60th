Imports Engine
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE
Imports System.IO
Imports System.Text
Imports ReaderModule

Public Class frmGiftStation

    Private Sub frmGiftStation_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            If ReadWriteIOEng.comm.IsOpen = True Then
                ReadWriteIOEng.comm.Close()
            End If
        Catch ex As Exception

        End Try
        
        Application.Exit()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Timer1.Enabled = True
        btnStop.Visible = True
        btnStart.Visible = False
        PanelYes.BackColor = Color.FromArgb(255, 192, 128)
        PanelNo.BackColor = Color.PaleGreen
    End Sub
    Private Sub PopulateData()
        Timer1.Enabled = True
        Dim strSQL As String = ""
        strSQL = "   select ROW_NUMBER() OVER(ORDER BY table1.log_date asc) AS rownumber  , table1.* from ("
        strSQL &= "   select"
        strSQL &= "   datediff(MINUTE,(select  max(tm.log_date) from tks_tag_movement tm where tm.tag_no=r.tag_no) ,getdate())  as timediff"
        strSQL &= "   ,r.customer_name_th"
        strSQL &= "   ,r.position_name"
        strSQL &= "   ,r.company_name"
        strSQL &= "   ,(select  max(tm.log_date) from tks_tag_movement tm where tm.tag_no=r.tag_no) as log_date"
        strSQL &= "   ,(select  (case when  max(tm.station_no) ='5' then '0' when max(tm.station_no)='6'  then '1' end ) from tks_tag_movement tm where tm.tag_no=r.tag_no) as IsStatus"
        strSQL &= "   from tks_register  r "
        strSQL &= "   where r.register_time Is Not null"
        strSQL &= "   and r.current_station_no in ('5','6')"
        strSQL &= "   ) as table1 "
        strSQL &= "   where table1.IsStatus Is Not null "
        strSQL &= "   and "
        strSQL &= "   0 = "
        strSQL &= "   CASE "
        strSQL &= "     WHEN table1.timediff >  1 THEN   "
        strSQL &= "   CASE "
        strSQL &= "     WHEN table1.IsStatus =  1 THEN 1"
        strSQL &= "   ELSE 0"

        strSQL &= "   End"
        strSQL &= "   ELSE 0"
        strSQL &= "   End"
        ' strSQL &= "   order by table1.log_date"
        Dim dt As DataTable = SqlDB.ExecuteTable(strSQL)
        Dim dv As DataView = dt.DefaultView
        'dv.RowFilter = "timediff < 1 and IsStatus='6'"
        ' DataGridView1.Dock = DockStyle.Fill
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.DataSource = dt

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Try
            Dim TagNo As String = ReaderModule.ReadWriteIOEng.ReadTag(2, 4)
            If TagNo.Trim <> "" Then
                ReaderModule.ReadWriteIOEng.BeefON()
                System.Threading.Thread.Sleep(300)
                ReaderModule.ReadWriteIOEng.BeefOFF()

                TagNo = Replace(TagNo, "-", "")

                Engine.ChooseImage.UpdateCurrentLocation("frmGiftStation.Timer1_Tick", TagNo, "6")
            End If

            PopulateData()
        Catch ex As Exception

        End Try
        Timer1.Enabled = True
    End Sub

    Private Sub DataGridView1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            Select Case DataGridView1.Rows(i).Cells("IsStatus").Value
                Case "1"
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 128)
                    DataGridView1.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                Case "0"
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
                    DataGridView1.Rows(i).DefaultCellStyle.ForeColor = Color.Black
            End Select
            DataGridView1.Rows(i).DefaultCellStyle.SelectionBackColor = DataGridView1.Rows(i).DefaultCellStyle.BackColor
            DataGridView1.Rows(i).DefaultCellStyle.SelectionForeColor = DataGridView1.Rows(i).DefaultCellStyle.ForeColor
        Next
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        Timer1.Enabled = False
        btnStop.Visible = False
        btnStart.Visible = True
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Timer1.Enabled = True
        btnStop.Visible = True
        btnStart.Visible = False
    End Sub

    Private Sub frmGiftStation_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            Dim ini As New Org.Mentalis.Files.IniReader(Application.StartupPath & "\config.ini")
            ini.Section = "ReaderSetting"

            ReaderParamsEng.CommIntSelectFlag = 1
            ReaderParamsEng.LanguageFlag = 1
            ReadWriteIOEng.comm.PortName = ini.ReadString("Comport")
            ReadWriteIOEng.comm.BaudRate = ini.ReadString("BaudRate")
            ReadWriteIOEng.comm.Open()

            ini = Nothing

            Dim ID(2) As UInt32
            Dim result As Integer = ReaderParamsEng.GetModuleID(ID)
            If result <> 0 Then
                ReadWriteIOEng.comm.Close()
                MessageBox.Show("Module Error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
End Class