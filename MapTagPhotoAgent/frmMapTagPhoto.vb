Imports System.Data
Imports System.IO
Imports MapTagPhotoAgent.Org.Mentalis.Files
Imports Engine
Imports LinqDB.ConnectDB


Public Class frmMapTagPhoto


    Dim ini As New MapTagPhotoAgent.Org.Mentalis.Files.IniReader(Application.StartupPath & "\Config.ini")
    '#Region "Camera Group"
    '    Private Sub TimerPhotoGroup_Tick(sender As Object, e As EventArgs) Handles TimerPhotoGroup.Tick
    '        TimerPhotoGroup.Enabled = False
    '        Try
    '            Dim ChkConnect As Boolean = False
    '            Do
    '                ChkConnect = PreRegister.CheckConnection
    '            Loop Until ChkConnect = True

    '            ini.Section = "PhotoPath"
    '            Dim PhotoPath As String = ini.ReadString("PhotoPath")
    '            Dim dt As New DataTable
    '            dt = MapTagPhotoENG.GetCurrentCustomerGroup("0")
    '            If dt.Rows.Count > 0 Then

    '                'Create Folder
    '                For Each dr As DataRow In dt.Rows
    '                    If Directory.Exists(dt.Rows(0)("tag_no")) = False Then
    '                        Directory.CreateDirectory(PhotoPath & "\" & dr("tag_no"))
    '                    End If
    '                Next
    '            End If

    '            'Move Photo
    '            dt = MapTagPhotoENG.GetCurrentCustomerGroup("1")
    '            If dt.Rows.Count > 0 Then
    '                For Each dr As DataRow In dt.Rows
    '                    Dim dtFile As New DataTable
    '                    Dim sql As String = "select id, file_name from TKS_TAKE_PHOTO_GROUP_FILE where tag_no='" & dr("tag_no") & "' and is_copy='N'"
    '                    dtFile = SqlDB.ExecuteTable(sql)
    '                    For Each drFile As DataRow In dtFile.Rows
    '                        Dim FleInfo As New FileInfo(drFile("file_name"))

    '                        Try
    '                            File.Copy(FleInfo.FullName, PhotoPath & dr("tag_no") & "\" & drFile("id") & "_GROUP_" & FleInfo.Name)

    '                            Dim uSql As String = "update TKS_TAKE_PHOTO_GROUP_FILE"
    '                            uSql += " set is_copy='Y'"
    '                            uSql += " where id='" & drFile("id") & "'"

    '                            Dim ret As Boolean = SqlDB.ExecuteNonQuery(uSql)

    '                        Catch ex As Exception
    '                            CreateLogFile("TimerPhotoGroup_Tick 1" & ex.Message)
    '                        End Try

    '                        FleInfo = Nothing
    '                    Next
    '                    dtFile.Dispose()
    '                Next
    '            End If
    '            dt.Dispose()
    '        Catch ex As Exception

    '        End Try
    '        TimerPhotoGroup.Enabled = True
    '    End Sub

    '    Private Sub TimerInsertGroupFileName_Tick(sender As Object, e As EventArgs) Handles TimerInsertGroupFileName.Tick
    '        TimerInsertGroupFileName.Enabled = False
    '        Try
    '            ini.Section = "PhotoPath"
    '            Dim CameraGroupPath As String = ini.ReadString("CameraGroupPath")
    '            If Directory.Exists(CameraGroupPath) = True Then
    '                For Each fle As String In Directory.GetFiles(CameraGroupPath, "*.jpg")
    '                    Dim cDt = MapTagPhotoENG.GetCurrentCustomerGroup("0")
    '                    If cDt.Rows.Count > 0 Then
    '                        For Each cDr As DataRow In cDt.Rows
    '                            Dim dt As New DataTable
    '                            Dim sql As String = "select id from TKS_TAKE_PHOTO_GROUP_FILE"
    '                            sql += " where file_name ='" & fle & "' and tag_no='" & cDr("tag_no") & "'"

    '                            dt = SqlDB.ExecuteTable(sql)
    '                            If dt.Rows.Count = 0 Then
    '                                Dim iSql As String = "insert into TKS_TAKE_PHOTO_GROUP_FILE (created_by,created_date,tag_no,file_name)"
    '                                iSql += " values('frmMapTagPhoto.TimerInsertGroupFileName_Tick',getdate(),'" & cDr("tag_no") & "','" & fle & "')"
    '                                SqlDB.ExecuteNonQuery(iSql)
    '                            End If
    '                            dt.Dispose()
    '                        Next
    '                    End If
    '                    cDt.Dispose()
    '                Next
    '            End If
    '        Catch ex As Exception
    '            CreateLogFile("TimerInsertGroupFileName_Tick" & ex.Message)
    '        End Try

    '        TimerInsertGroupFileName.Enabled = True
    '    End Sub
    '#End Region


#Region "Camera Single"
    Private Sub TimerInsertFileName_Tick(sender As Object, e As EventArgs) Handles TimerInsertFileName.Tick
        TimerInsertFileName.Enabled = False
        Try
            If lblCurrentTag.Text.Trim <> "" Then
                ini.Section = "PhotoPath"

                Dim CameraSinglePath As String = ini.ReadString("CameraSinglePath")
                If Directory.Exists(CameraSinglePath) = True Then
                    For Each fle As String In Directory.GetFiles(CameraSinglePath, "*.jpg")
                        Dim dt As New DataTable
                        Dim sql As String = "select id from TKS_TAKE_PHOTO_FILE"
                        sql += " where file_name ='" & fle & "' and station_no='3'"

                        dt = SqlDB.ExecuteTable(sql)
                        If dt.Rows.Count = 0 Then
                            Dim iSql As String = "insert into TKS_TAKE_PHOTO_FILE (created_by,created_date,tag_no,file_name,station_no)"
                            iSql += " values('frmMapTagPhoto.TimerInsertFileName_Tick',getdate(),'" & lblCurrentTag.Text & "','" & fle & "','3')"
                            SqlDB.ExecuteNonQuery(iSql)
                        End If
                        dt.Dispose()
                    Next
                End If
            End If
        Catch ex As Exception
            CreateLogFile("TimerInsertFileName_Tick" & ex.Message)
        End Try
        TimerInsertFileName.Enabled = True
    End Sub

    Private Sub TimerCreateFolder_Tick(sender As Object, e As EventArgs) Handles TimerCreateFolder.Tick
        TimerCreateFolder.Enabled = False
        Try
            Dim ChkConnect As Boolean = False
            Do
                ChkConnect = PreRegister.CheckConnection
            Loop Until ChkConnect = True

            ini.Section = "PhotoPath"
            Dim PhotoPath As String = ini.ReadString("PhotoPath")
            Dim dt As New DataTable
            dt = MapTagPhotoENG.GetCurrentCustomerSingle("0")
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("tag_no").ToString.Substring(0, 1) <> "3" Then
                    'Create Folder
                    If dt.Rows.Count > 0 Then
                        If Directory.Exists(dt.Rows(0)("tag_no")) = False Then
                            Directory.CreateDirectory(PhotoPath & "\" & dt.Rows(0)("tag_no"))
                        End If

                        lblCurrentTag.Text = dt.Rows(0)("tag_no")
                    End If
                End If
            End If
            dt.Dispose()

        Catch ex As Exception
            CreateLogFile("TimerCreateFolder_Tick 3" & ex.Message)
        End Try
        TimerCreateFolder.Enabled = True
    End Sub
#End Region
    Private Sub DeteleTempFile_Tick(sender As Object, e As EventArgs) Handles DeteleTempFile.Tick
        Try
            Dim dt As New DataTable
            dt = SqlDB.ExecuteTable("select file_name from TKS_TAKE_PHOTO_FILE where is_copy='Y'")
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    Try
                        If File.Exists(dr("file_name")) = True Then
                            File.SetAttributes(dr("file_name"), FileAttributes.Normal)
                            File.Delete(dr("file_name"))
                        End If
                    Catch ex As Exception
                        'CreateLogFile("DeteleTempFile_Tick " & ex.Message)
                    End Try
                Next
            End If
            dt.Dispose()
        Catch ex As Exception

        End Try
    End Sub


    Public Sub CreateLogFile(ByVal TextMsg As String)
        Try
            Dim LogDir As String = Application.StartupPath & "\Log\"
            If Directory.Exists(LogDir) = False Then
                Directory.CreateDirectory(LogDir)
            End If

            Dim FILE_NAME As String = LogDir & DateTime.Now.ToString("yyyyMMddHH") & ".log"
            Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
            objWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") & " " & TextMsg & Chr(13) & Chr(13))
            objWriter.Close()
        Catch ex As Exception

        End Try

    End Sub

    Public Shared Function SetImage(ImageIn As Image) As Byte()
        Dim ret As Byte() = Nothing
        If ImageIn IsNot Nothing Then
            Dim imageConverter As New ImageConverter()
            ret = DirectCast(imageConverter.ConvertTo(ImageIn, GetType(Byte())), Byte())
        End If

        Return ret
    End Function


    Private Sub TimerResize_Tick(sender As Object, e As EventArgs) Handles TimerResize.Tick
        Try
            ini.Section = "PhotoPath"
            Dim PhotoPath As String = ini.ReadString("PhotoPath")
            For Each d As String In Directory.GetDirectories(PhotoPath)

                If Directory.Exists(d & "\Resize") = False Then
                    Directory.CreateDirectory(d & "\Resize")
                End If

                For Each f As String In Directory.GetFiles(d, "*.jpg")
                    
                    Dim fInfo As New FileInfo(f)

                    If File.Exists(d & "\Resize\" & fInfo.Name) = False Then
                        'Dim ResizePercent As Integer = 60
                        'Dim bm As New Bitmap(f)


                        'Dim newWidth As Integer = bm.Width * (ResizePercent / 100)
                        'Dim newHeight As Integer = bm.Height * (ResizePercent / 100)
                        'Dim newImage As New Bitmap(newWidth, newHeight)

                        'Dim g As Graphics = Graphics.FromImage(newImage)
                        'g.InterpolationMode = Drawing2D.InterpolationMode.Default
                        'g.DrawImage(bm, New Rectangle(0, 0, newWidth, newHeight), New Rectangle(0, 0, bm.Width, bm.Height), GraphicsUnit.Pixel)
                        'g.Dispose()

                        ''If bm.Height < bm.Width Then
                        ''    newImage.RotateFlip(RotateFlipType.Rotate270FlipNone)
                        ''End If
                        'bm.Dispose()

                        'newImage.Save(d & "\Resize\" & fInfo.Name, System.Drawing.Imaging.ImageFormat.Jpeg)

                        File.Copy(f, d & "\Resize\" & fInfo.Name)
                    End If
                Next
            Next
        Catch ex As Exception
            CreateLogFile("Resize " & ex.Message)
        End Try
        
    End Sub

    Private Sub TimerMovePhoto_Tick(sender As Object, e As EventArgs) Handles TimerMovePhoto.Tick
        TimerMovePhoto.Enabled = False
        Try
            ini.Section = "PhotoPath"
            Dim PhotoPath As String = ini.ReadString("PhotoPath")

            'Move Photo
            Dim dt As DataTable = MapTagPhotoENG.GetCurrentCustomerSingle("1")
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim dtFile As New DataTable
                    Dim sql As String = "select id, file_name from TKS_TAKE_PHOTO_FILE where tag_no='" & dr("tag_no") & "' and station_no='3' and is_copy='N'"
                    dtFile = SqlDB.ExecuteTable(sql)
                    For Each drFile As DataRow In dtFile.Rows
                        Dim FleInfo As New FileInfo(drFile("file_name"))
                        Try
                            File.Copy(FleInfo.FullName, PhotoPath & dr("tag_no") & "\" & drFile("id") & "_" & FleInfo.Name)

                            Dim uSql As String = "update TKS_TAKE_PHOTO_FILE"
                            uSql += " set is_copy='Y'"
                            uSql += " where id='" & drFile("id") & "'"

                            Dim ret As Boolean = SqlDB.ExecuteNonQuery(uSql)

                        Catch ex As Exception
                            CreateLogFile("TimerMovePhoto_Tick 1" & ex.Message)
                        End Try

                        FleInfo = Nothing
                    Next
                    dtFile.Dispose()
                Next
            End If
        Catch ex As Exception
            CreateLogFile("TimerMovePhoto_Tick 2" & ex.Message)
        End Try
        TimerMovePhoto.Enabled = True
    End Sub

    Private Sub TimerCheckLastCurrentStatus_Tick(sender As Object, e As EventArgs) Handles TimerCheckLastCurrentStatus.Tick
        Try
            ini.Section = "PhotoPath"
            Dim UpdateLastLogTime As String = ini.ReadString("UpdateLastLogTime")
            If UpdateLastLogTime = "" Then
                UpdateLastLogTime = "10"
            End If

            Dim chkTime As Int16 = Convert.ToInt16(UpdateLastLogTime)

            Dim dt As New DataTable
            Dim sql As String = " select max(log_date) log_date from TKS_TAG_MOVEMENT"
            sql += " where station_no='3'"
            dt = SqlDB.ExecuteTable(sql)
            If dt.Rows.Count > 0 Then
                If DateDiff(DateInterval.Second, Convert.ToDateTime(dt.Rows(0)("log_date")), DateTime.Now) > chkTime Then
                    sql = "update TKS_TAKE_PHOTO_JOB"
                    sql += " set flag_folder_status=1"
                    sql += " where flag_folder_status=0 "

                    SqlDB.ExecuteNonQuery(sql)
                End If
            End If
            dt.Dispose()
        Catch ex As Exception

        End Try
    End Sub
End Class
