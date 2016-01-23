Imports Engine
Imports System.IO

Public Class frmRegisterSignage

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Try
            Dim ChkConnect As Boolean = False
            Do
                ChkConnect = PreRegister.CheckConnection
            Loop Until ChkConnect = True

            QueryData()
        Catch ex As Exception

        End Try
        Timer1.Enabled = True
    End Sub

    Private Sub QueryData()
        Dim dt As New DataTable
        dt = Engine.Register.GetDisplayRegister1To1Signage()

        Dim strPath As String = Application.StartupPath & "\txtFile.txt"
        If dt.Rows.Count > 0 Then
            Try
                For Each dr As DataRow In dt.Rows
                    Dim strText As String = ""
                    strText += "first_name=" & dr("customer_name")
                    strText += "&first_name_5=" & dr("company_name")

                    CreateTextFile(strPath, strText)

                    System.Threading.Thread.Sleep(5000)

                    Engine.Register.UpdateDisplayStatusRegister1To1(dr("id"))
                Next
            Catch ex As Exception

            End Try
        Else
            Dim strText As String = ""
            strText += "first_name="
            strText += "&first_name_5="
            CreateTextFile(strPath, strText)
        End If
        dt.Dispose()
    End Sub

    Private Sub CreateTextFile(strPath As String, strText As String)
        Dim ojbWriter As New StreamWriter(strPath, False)
        ojbWriter.WriteLine(strText)
        ojbWriter.Close()
    End Sub

    Private Sub frmRegisterSignage_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim Pross As New Process
        Pross.StartInfo.FileName = Application.StartupPath & "\tks_greeting1-1.exe"
        'Pross.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
        Pross.Start()


        QueryData()
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class
