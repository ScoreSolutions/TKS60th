Imports Engine
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE
Imports System.IO
Imports System.Text
Imports Impinj.OctaneSdk
Imports Org.Mentalis.Files
Imports System.Collections.Generic

Public Class Form1

    'bool isInteractive = false;
    '    bool isActive = false;
    'Dim IsContent As Boolean = False
    '    String TagAll = "";
    '    int cntTag = 0;
    '    int cntNo = 0;
    '    //public List<string> list = new List<string>();
    '    Array[] TagA = null;
    '    private object MyLock = new object();
    '    string TagNo = null;
    '    public SpeedwayReader Reader = new SpeedwayReader();
    '    public String readerName = "";
    '    private Custom.Control.SortListView m_sortListView;
    Dim ini As New IniReader(Application.StartupPath & "\Config.ini")

    Public ReaderNames As New List(Of String)()
    Public TagTable As New Dictionary(Of String, List(Of Tag))
    Public readerIP As String = ""

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Try
            Dim GC As New SpeedwayReaderENG(readerIP)
            For i As Integer = 0 To VariablesENG.list.Count - 1
                If VariablesENG.list(i) <> "" Then
                    Dim strData() As String
                    Try
                        strData = Split(VariablesENG.list(i), "##")
                        If strData.Length = 4 Then
                            Dim TagNo As String = ""
                            If strData(0) <> "" Then
                                TagNo = strData(0).Replace(" ", "").Substring(0, 16)
                            End If

                            Dim AntNo As String = strData(1)
                            Dim Rssi As String = strData(2)
                            Dim SpeedwaySerialNo As String = strData(3)
                            Dim StationNo As String = TagMovementENG.GetSpeedwayStationNo(SpeedwaySerialNo)

                            Dim ret As Boolean = TagMovementENG.InsertTagMovement(TagNo, SpeedwaySerialNo, AntNo, Rssi, StationNo)
                            If ret = True Then
                                If StationNo = "1" Then   'ประตูทางเข้างาน ตรงป้อมยาม
                                    'Dim dt As New DataTable
                                    'dt = Register.GetRegisterData(" and tag_no='" & TagNo & "' and register_time is not null and is_register='Y'")
                                    'If dt.Rows.Count = 0 Then
                                    ret = Register.UpdateRegisterTime(TagNo)
                                    If VariablesENG.list(i).Contains(strData(0)) Then
                                        VariablesENG.list.RemoveAt(i)
                                    End If


                                    'End If
                                    'dt.Dispose()
                                End If
                            Else
                                '  MsgBox("Update False")
                            End If
                        End If
                    Catch ex As Exception
                        '  MsgBox("try-sub" & ex.Message)
                    End Try
                End If
            Next
            ' CreateSignageTextFile()
        Catch ex As Exception
            ' MsgBox("try-main" & ex.Message)
        End Try
        Timer1.Enabled = True
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            GoStart()
            ini.Section = "SpeedwaySetting"
            readerIP = ini.ReadString("IP")

            ConvertNameToConnect(Split(readerIP, ","))

            Dim GC As New SpeedwayReaderENG(readerIP)
            Dim nThread As New System.Threading.Thread(AddressOf GC.Run)
            nThread.Start()


            ini = Nothing
        Catch ex As Exception

        End Try


        'GoStart()
    End Sub


    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        '  Environment.Exit(1)
        'Application.Exit()
        System.Environment.Exit(0)
    End Sub

    Private Sub ConvertNameToConnect(args() As String)
        ReaderNames = New List(Of String)(args)
    End Sub



    Private Sub CreateSignageTextFile()
        Try
            btnStart.Enabled = False
            btnStop.Enabled = True
            Dim strSQL As String = ""

            strSQL = " select top 4 "
            strSQL &= " r.customer_name_th"
            strSQL &= " ,r.position_name"
            strSQL &= " ,r.company_name"
            strSQL &= " ,register_time"
            strSQL &= " from tks_register  r "
            strSQL &= " where r.register_time Is Not null and current_station_no='1' and is_register='Y'"
            strSQL &= " order by register_time desc"
            Dim dt As DataTable = SqlDB.ExecuteTable(strSQL)
            Dim strFullText As String = ""
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Select Case dt.Rows.Count
                        Case 4
                            Select Case i
                                Case 0
                                    strFullText &= IIf(strFullText = "", "", "&") & "first_name_4=" & dt.Rows(i)("customer_name_th") & "&first_name_8=" & dt.Rows(i)("company_name")
                                Case 1
                                    strFullText &= IIf(strFullText = "", "", "&") & "first_name_3=" & dt.Rows(i)("customer_name_th") & "&first_name_7=" & dt.Rows(i)("company_name")
                                Case 2
                                    strFullText &= IIf(strFullText = "", "", "&") & "first_name_2=" & dt.Rows(i)("customer_name_th") & "&first_name_6=" & dt.Rows(i)("company_name")
                                Case 3
                                    strFullText &= IIf(strFullText = "", "", "&") & "first_name=" & dt.Rows(i)("customer_name_th") & "&first_name_5=" & dt.Rows(i)("company_name")
                            End Select
                        Case 3
                            Select Case i
                                Case 0
                                    strFullText &= IIf(strFullText = "", "", "&") & "first_name_3=" & dt.Rows(i)("customer_name_th") & "&first_name_7=" & dt.Rows(i)("company_name")
                                Case 1
                                    strFullText &= IIf(strFullText = "", "", "&") & "first_name_2=" & dt.Rows(i)("customer_name_th") & "&first_name_6=" & dt.Rows(i)("company_name")
                                Case 2
                                    strFullText &= IIf(strFullText = "", "", "&") & "first_name=" & dt.Rows(i)("customer_name_th") & "&first_name_5=" & dt.Rows(i)("company_name")
                                    strFullText &= IIf(strFullText = "", "", "&") & "first_name_4=&first_name_8="

                            End Select
                        Case 2
                            Select Case i
                                Case 0
                                    strFullText &= IIf(strFullText = "", "", "&") & "first_name_2=" & dt.Rows(i)("customer_name_th") & "&first_name_6=" & dt.Rows(i)("company_name")
                                Case 1
                                    strFullText &= IIf(strFullText = "", "", "&") & "first_name=" & dt.Rows(i)("customer_name_th") & "&first_name_5=" & dt.Rows(i)("company_name")
                                    strFullText &= IIf(strFullText = "", "", "&") & "first_name_3=&first_name_7="
                                    strFullText &= IIf(strFullText = "", "", "&") & "first_name_4=&first_name_8="
                            End Select

                        Case 1
                            strFullText &= IIf(strFullText = "", "", "&") & "first_name=" & dt.Rows(i)("customer_name_th") & "&first_name_5=" & dt.Rows(i)("company_name")
                            strFullText &= IIf(strFullText = "", "", "&") & "first_name_2=&first_name_6="
                            strFullText &= IIf(strFullText = "", "", "&") & "first_name_3=&first_name_7="
                            strFullText &= IIf(strFullText = "", "", "&") & "first_name_4=&first_name_8="
                    End Select
                Next
            Else
                strFullText &= IIf(strFullText = "", "", "&") & "first_name=&first_name_5="
                strFullText &= IIf(strFullText = "", "", "&") & "first_name_2=&first_name_6="
                strFullText &= IIf(strFullText = "", "", "&") & "first_name_3=&first_name_7="
                strFullText &= IIf(strFullText = "", "", "&") & "first_name_4=&first_name_8="
            End If
            Dim strStartUp As String = Application.StartupPath
            ' Dim strPath As String = "D:\TKS_TEXTFILE"
            'If (Not System.IO.Directory.Exists(strPath)) Then
            '    System.IO.Directory.CreateDirectory(strPath)
            'End If
            Try

                Using ojbWriter As New StreamWriter(strStartUp & "\txtFile.txt", False)
                    ojbWriter.WriteLine(strFullText)
                    ojbWriter.Close()
                End Using

            Catch ex As Exception

            End Try
            'Application.Run(New Form1)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GoStart()
        btnStart.Enabled = False
        btnStop.Enabled = True
        Timer1.Enabled = True
        TimerWriteFile.Enabled = True
    End Sub

    Private Sub GoStop()
        btnStart.Enabled = True
        btnStop.Enabled = False
        Timer1.Enabled = False
        TimerWriteFile.Enabled = False
    End Sub


    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        GoStop()
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        GoStart()
    End Sub

    Private Sub TimerWriteFile_Tick(sender As Object, e As EventArgs) Handles TimerWriteFile.Tick
        CreateSignageTextFile()
    End Sub
End Class