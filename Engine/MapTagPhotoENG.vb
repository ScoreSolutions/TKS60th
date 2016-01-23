Imports LinqDB.ConnectDB
Imports LinqDB.TABLE
Public Class MapTagPhotoENG

#Region "Single Photo"

    Public Shared Function GetCurrentCustomerSingle(FlagFolderStatus As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim sql As String = "select pj.id, pj.tag_no "
            sql += " from TKS_TAKE_PHOTO_JOB pj "
            sql += " where  pj.end_time is null"
            sql += " and pj.flag_folder_status='" & FlagFolderStatus & "'"

            dt = SqlDB.ExecuteTable(sql)
        Catch ex As Exception
            dt = New DataTable
        End Try
        Return dt
    End Function
#End Region


#Region "Group Photo"
    Public Shared Function GetCurrentCustomerGroup(FlagFolderStatus As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim sql As String = "select pj.id, pj.tag_no "
            sql += " from TKS_TAKE_PHOTO_GROUP_JOB pj "
            sql += " where pj.end_time is null"
            sql += " and pj.flag_folder_status='" & FlagFolderStatus & "'"

            dt = SqlDB.ExecuteTable(sql)
        Catch ex As Exception
            dt = New DataTable
        End Try
        Return dt
    End Function
#End Region

    Public Shared Function SaveTakePhoto(TagNo As String, ImageByteData As Byte(), FileExt As String) As Boolean
        Dim ret As Boolean = False
        Try
            Dim trans As New TransactionDB
            Dim lnq As New TksTakePhotoLinqDB
            lnq.TAG_NO = TagNo
            lnq.TAKE_DATE = SqlDB.GetDateNowFromDB(trans.Trans)
            lnq.IMAGE_FILE = ImageByteData
            lnq.FILE_EXT = FileExt
            lnq.IS_SELECTED = "Y"
            lnq.IS_POST_FACEBOOK = "N"

            ret = lnq.InsertData("Engine.MapTagPhotoENG.SaveTakePhoto", trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function



    Public Shared Sub UpdateLastCurrentJob()
        Try
            Dim sql As String = "select distinct tag_no "
            sql += " from TKS_TAG_MOVEMENT"
            sql += " where station_no='3.2' and DATEDIFF(s,log_date,getdate())>60"

            Dim dt As New DataTable
            Dim lnq As New TksTagMovementLinqDB
            dt = lnq.GetListBySql(sql, Nothing)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim uSql As String = "update TKS_TAKE_PHOTO_JOB "
                    uSql += " set eng_time=getdate()"
                    uSql += " where tag_no='" & dr("tag_no") & "' and end_time is null and station_no='3.2'"

                    Dim trans As New TransactionDB
                    If SqlDB.ExecuteNonQuery(sql, trans.Trans) = True Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                    End If
                Next
            End If
            lnq = Nothing

            dt.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    'Public Shared Function InsertTakePhotoJob(TagNo As String, StationNo As String, Create As Integer) As Boolean
    '    Dim ret As Boolean = False
    '    Try
    '        Dim lnq As New TksTakePhotoJobLinqDB
    '        lnq.ChkDataByWhere("tag_no='" & TagNo & "' and end_time is null and station_no='" & StationNo & "'", Nothing)
    '        lnq.TAG_NO = TagNo
    '        lnq.START_TIME = SqlDB.GetDateNowFromDB(Nothing)
    '        lnq.STATION_NO = StationNo
    '        Dim strSQL As String
    '        Dim trans As New TransactionDB
    '        If lnq.ID > 0 Then
    '            strSQL = "update TKS_TAKE_PHOTO_JOB"
    '            strSQL &= "set updated_date = getdate()"
    '            strSQL &= ",updated_by='admin'"
    '            strSQL &= ",start_time=getdate()"
    '            strSQL &= ",station_no='" & StationNo & "'"
    '            strSQL &= ",flag_folder_status=" & Create
    '            strSQL &= "where tag_no='" & StationNo & "'"
    '            ret = SqlDB.ExecuteNonQuery(strSQL, trans.Trans)
    '            'ret = lnq.InsertData("MapTagPhotoENG.InsertTakePhotoJob", trans.Trans)
    '        Else
    '            strSQL = "INSERT INTO dbo.TKS_TAKE_PHOTO_JOB"
    '            strSQL &= "(created_by"
    '            strSQL &= ",created_date"
    '            strSQL &= ",start_time"
    '            strSQL &= ",tag_no"
    '            strSQL &= ",station_no"
    '            strSQL &= ",flag_folder_status)"
    '            strSQL &= "select "
    '            strSQL &= "'admin'"
    '            strSQL &= ",getdate()"
    '            strSQL &= ",getdate()"
    '            strSQL &= ",'" & TagNo & "'"
    '            strSQL &= ",'" & StationNo & "'"
    '            strSQL &= "," & Create
    '            ret = SqlDB.ExecuteNonQuery(strSQL, trans.Trans)
    '            ' ret = lnq.UpdateByPK("MapTagPhotoENG.InsertTakePhotoJob", trans.Trans)
    '        End If

    '        If ret = True Then
    '            trans.CommitTransaction()

    '            trans = New TransactionDB
    '            Dim sql As String = "update tks_take_photo_job "
    '            sql += " set end_time = getdate() "
    '            sql += " where tag_no <> '" & TagNo & "' and end_time is null and station_no='" & StationNo & "'"

    '            ret = SqlDB.ExecuteNonQuery(sql, trans.Trans)
    '            If ret = True Then
    '                trans.CommitTransaction()
    '            Else
    '                trans.RollbackTransaction()
    '            End If
    '        Else
    '            trans.RollbackTransaction()
    '        End If
    '    Catch ex As Exception
    '        ret = False
    '    End Try
    '    Return ret
    'End Function
    '    Public Shared Function InsertJobMultiple(TagNo As String, StationNo As String, Create As String) As Boolean
    '        Dim ret As Boolean = False
    '        Try
    '            'Dim lnq As New TksTakePhotoJobLinqDB
    '            'lnq.ChkDataByWhere("tag_no='" & TagNo & "' and end_time is null and station_no='" & StationNo & "'", Nothing)
    '            'lnq.TAG_NO = TagNo
    '            'lnq.START_TIME = SqlDB.GetDateNowFromDB(Nothing)
    '            'lnq.STATION_NO = StationNo
    '            Dim strSQL, strSQLCheck As String
    '            Dim trans As New TransactionDB

    '            strSQLCheck = "select * from TKS_TAKE_PHOTO_GROUP_JOB where tag_no='" & TagNo & "' and end_time is null and station_no='" & StationNo & "'"
    '            Dim dt As DataTable = SqlDB.ExecuteTable(strSQLCheck, trans.Trans)

    '<<<<<<< .mine
    '            Dim trans As New TransactionDB
    '            If SqlDB.ExecuteNonQuery(sql, trans.Trans) = True Then
    '                trans.CommitTransaction()
    '            Else
    '                trans.RollbackTransaction()
    '            End If
    '                Next '
    '=======
    '            If dt.Rows.Count = 0 Then
    '                strSQL = "INSERT INTO dbo.TKS_TAKE_PHOTO_GROUP_JOB"
    '                strSQL &= "(created_by"
    '                strSQL &= ",created_date"
    '                strSQL &= ",start_time"
    '                strSQL &= ",tag_no"
    '                strSQL &= ",flag_folder_status)"
    '                strSQL &= "select "
    '                strSQL &= "'admin'"
    '                strSQL &= ",getdate()"
    '                strSQL &= ",getdate()"
    '                strSQL &= ",'" & TagNo & "'"
    '                strSQL &= ",'" & StationNo & "'"
    '                strSQL &= "," & Create
    '                ' ret = lnq.UpdateByPK("MapTagPhotoENG.InsertTakePhotoJob", trans.Trans)
    '                ret = SqlDB.ExecuteNonQuery(strSQL, trans.Trans)
    '            Else
    '                strSQL = "update TKS_TAKE_PHOTO_GROUP_JOB"
    '                strSQL &= "set updated_date = getdate()"
    '                strSQL &= ",updated_by='admin'"
    '                strSQL &= ",start_time=getdate()"
    '                strSQL &= ",flag_folder_status=" & Create
    '                strSQL &= "where tag_no='" & StationNo & "'"
    '                ret = SqlDB.ExecuteNonQuery(strSQL, trans.Trans)
    '                'ret = lnq.InsertData("MapTagPhotoENG.InsertTakePhotoJob", trans.Trans)
    '>>>>>>> .r181
    '            End If
    '            'If lnq.ID > 0 Then
    '            '    ret = lnq.UpdateByPK("MapTagPhotoENG.InsertTakePhotoJob", trans.Trans)
    '            'Else
    '            '    ret = lnq.InsertData("MapTagPhotoENG.InsertTakePhotoJob", trans.Trans)
    '            'End If

    '            If ret = True Then
    '                trans.CommitTransaction()
    '            Else
    '                trans.RollbackTransaction()
    '            End If
    '        Catch ex As Exception
    '            ret = False
    '        End Try
    '<<<<<<< .mine
    '    End Sub

    Public Shared Function InsertTakePhotoJob(TagNo As String, StationNo As String, Create As Integer) As Boolean
        Dim ret As Boolean = False
        Try
            Dim lnq As New TksTakePhotoJobLinqDB
            'lnq.ChkDataByWhere("tag_no='" & TagNo & "' and end_time is null and station_no='" & StationNo & "'", Nothing)
            lnq.ChkDataByWhere("tag_no='" & TagNo & "' and station_no='" & StationNo & "'", Nothing)
            lnq.TAG_NO = TagNo
            lnq.START_TIME = SqlDB.GetDateNowFromDB(Nothing)
            lnq.STATION_NO = StationNo
            Dim strSQL As String
            Dim trans As New TransactionDB
            If lnq.ID > 0 Then
                strSQL = "update TKS_TAKE_PHOTO_JOB"
                strSQL &= "set updated_date = getdate()"
                strSQL &= ",updated_by='admin'"
                strSQL &= ",start_time=getdate()"
                strSQL &= ",station_no='" & StationNo & "'"
                strSQL &= ",flag_folder_status=" & Create
                strSQL &= "where tag_no='" & StationNo & "'"
                ret = SqlDB.ExecuteNonQuery(strSQL, trans.Trans)
                'ret = lnq.InsertData("MapTagPhotoENG.InsertTakePhotoJob", trans.Trans)
            Else
                strSQL = "INSERT INTO dbo.TKS_TAKE_PHOTO_JOB"
                strSQL &= "(created_by"
                strSQL &= ",created_date"
                strSQL &= ",start_time"
                strSQL &= ",tag_no"
                strSQL &= ",station_no"
                strSQL &= ",flag_folder_status)"
                strSQL &= "select "
                strSQL &= "'admin'"
                strSQL &= ",getdate()"
                strSQL &= ",getdate()"
                strSQL &= ",'" & TagNo & "'"
                strSQL &= ",'" & StationNo & "'"
                strSQL &= "," & Create
                ret = SqlDB.ExecuteNonQuery(strSQL, trans.Trans)
                ' ret = lnq.UpdateByPK("MapTagPhotoENG.InsertTakePhotoJob", trans.Trans)
            End If

            If ret = True Then
                trans.CommitTransaction()

                trans = New TransactionDB
                Dim sql As String = "update tks_take_photo_job "
                sql += " set end_time = getdate() "
                sql += " where tag_no <> '" & TagNo & "' and end_time is null and station_no='" & StationNo & "'"

                ret = SqlDB.ExecuteNonQuery(sql, trans.Trans)
                If ret = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
            Else
                trans.RollbackTransaction()
            End If
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function
    Public Shared Function InsertJobMultiple(TagNo As String, StationNo As String, Create As String) As Boolean
        Dim ret As Boolean = False
        Try
            'Dim lnq As New TksTakePhotoJobLinqDB
            'lnq.ChkDataByWhere("tag_no='" & TagNo & "' and end_time is null and station_no='" & StationNo & "'", Nothing)
            'lnq.TAG_NO = TagNo
            'lnq.START_TIME = SqlDB.GetDateNowFromDB(Nothing)
            'lnq.STATION_NO = StationNo
            Dim strSQL, strSQLCheck As String
            Dim trans As New TransactionDB

            strSQLCheck = "select * from TKS_TAKE_PHOTO_GROUP_JOB where tag_no='" & TagNo & "'  and station_no='" & StationNo & "'"
            Dim dt As DataTable = SqlDB.ExecuteTable(strSQLCheck, trans.Trans)

            If dt.Rows.Count = 0 Then
                strSQL = "INSERT INTO dbo.TKS_TAKE_PHOTO_GROUP_JOB"
                strSQL &= "(created_by"
                strSQL &= ",created_date"
                strSQL &= ",start_time"
                strSQL &= ",tag_no"
                strSQL &= ",flag_folder_status)"
                strSQL &= "select "
                strSQL &= "'admin'"
                strSQL &= ",getdate()"
                strSQL &= ",getdate()"
                strSQL &= ",'" & TagNo & "'"
                strSQL &= ",'" & StationNo & "'"
                strSQL &= "," & Create
                ' ret = lnq.UpdateByPK("MapTagPhotoENG.InsertTakePhotoJob", trans.Trans)
                ret = SqlDB.ExecuteNonQuery(strSQL, trans.Trans)
            Else
                strSQL = "update TKS_TAKE_PHOTO_GROUP_JOB"
                strSQL &= "set updated_date = getdate()"
                strSQL &= ",updated_by='admin'"
                strSQL &= ",start_time=getdate()"
                strSQL &= ",flag_folder_status=" & Create
                strSQL &= "where tag_no='" & StationNo & "'"
                ret = SqlDB.ExecuteNonQuery(strSQL, trans.Trans)
                'ret = lnq.InsertData("MapTagPhotoENG.InsertTakePhotoJob", trans.Trans)
            End If
            'If lnq.ID > 0 Then
            '    ret = lnq.UpdateByPK("MapTagPhotoENG.InsertTakePhotoJob", trans.Trans)
            'Else
            '    ret = lnq.InsertData("MapTagPhotoENG.InsertTakePhotoJob", trans.Trans)
            'End If

            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function
End Class
