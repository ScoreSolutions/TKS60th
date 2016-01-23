Imports System.Data
Imports System.IO
Imports LuckyDrawAgent.Org.Mentalis.Files
Imports Engine
Imports ReaderModule

Public Class frmLuckyDrawPlayer
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Try
            Dim ChkConnect As Boolean = False
            Do
                ChkConnect = PreRegister.CheckConnection
            Loop Until ChkConnect = True

            If lblTagNo.Text.Trim = "" Then
                ReadAndFillData()
            Else
                'ถ้าเป็นบัตรใหม่มาแตะ
                Dim NewTagNo As String = ReadWriteIOEng.ReadTag(2, 4)
                NewTagNo = Replace(NewTagNo, "-", "")
                If NewTagNo <> lblTagNo.Text.Trim And NewTagNo <> "" Then
                    ClearForm()
                    ReadAndFillData()
                End If
            End If
        Catch ex As Exception

        End Try
        Timer1.Enabled = True
    End Sub

    Private Sub ReadAndFillData()
        lblTagNo.Text = ReadWriteIOEng.ReadTag(2, 4)
        If lblTagNo.Text.Trim <> "" Then
            lblTagNo.Text = Replace(lblTagNo.Text, "-", "")
            ReadWriteIOEng.BeefON()
            System.Threading.Thread.Sleep(300)
            ReadWriteIOEng.BeefOFF()

            Dim dt As New DataTable
            dt = Engine.PreRegister.GetRegisterDataByTagNo(lblTagNo.Text)
            If dt.Rows.Count > 0 Then
                lblPlayerName.Text = dt.Rows(0)("customer_name_th").ToString
                lblCompanyName.Text = dt.Rows(0)("company_name").ToString
                'chkWaitForCardTag.Checked = True
                CreateLuckyDrawTextFile(lblPlayerName.Text, lblCompanyName.Text)

                dt.Dispose()
            End If
        End If
    End Sub

    Private Sub ClearForm()
        lblPlayerName.Text = ""
        lblCompanyName.Text = ""
        lblTagNo.Text = ""
    End Sub

    Private Sub CreateLuckyDrawTextFile(PlayerName As String, CompanyName As String)
        'Dim strPath As String = Application.StartupPath & "\"
        'If (Not System.IO.Directory.Exists(strPath)) Then
        '    System.IO.Directory.CreateDirectory(strPath)
        'End If

        Dim strFullText As String = "CustomerName=" & PlayerName & "&CompanyName=" & CompanyName

        Dim ojbWriter As New StreamWriter(Application.StartupPath & "\LuckyDrawTextData.txt", False)
        ojbWriter.WriteLine(strFullText)
        ojbWriter.Close()
    End Sub

    Private Sub frmLuckyDrawPlayer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If ReadWriteIOEng.comm.IsOpen = True Then
            ReadWriteIOEng.comm.Close()
        End If
    End Sub

    Private Sub frmLuckyDrawPlayer_Shown(sender As Object, e As EventArgs) Handles Me.Shown
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
