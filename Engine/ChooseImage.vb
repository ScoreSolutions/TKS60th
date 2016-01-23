Imports LinqDB.ConnectDB
Imports LinqDB.TABLE
Public Class ChooseImage
    Public Shared Function UpdateSelectedStatus(UserName As String, tag_no As String, image_id As String) As Boolean
        Dim ret As Boolean = False
        'Dim _err As String = ""
        Dim trans As New TransactionDB
        Try
            Dim sql As String = "update TKS_TAKE_PHOTO set is_selected ='Y',is_post_facebook ='N',updated_date = getdate(),updated_by='" & UserName & "' where tag_no ='" & tag_no & "' and id ='" & image_id & "'"
            ret = SqlDB.ExecuteNonQuery(sql, trans.Trans)

            If ret = False Then
                trans.RollbackTransaction()
                Return False
            End If

            sql = "update TKS_TAKE_PHOTO_JOB set end_time = getdate(),updated_date=getdate(),updated_by='" & UserName & "' where tag_no ='" & tag_no & "' and end_time is null "
            ret = SqlDB.ExecuteNonQuery(sql, trans.Trans)

            If ret Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
                '_err = "Error! "
            End If
        Catch ex As Exception
            trans.RollbackTransaction()
            '_err = "Error! " & ex.ToString
        End Try

        Return ret
    End Function

    Public Shared Function GetImageByForPostFB() As DataTable
        Dim dt As New DataTable
        Try
            Dim sql As String = "select id,tag_no,image_file,is_selected,is_post_facebook from TKS_TAKE_PHOTO PH where is_selected='Y' and is_post_facebook ='N'"
            dt = SqlDB.ExecuteTable(sql)
        Catch ex As Exception
            dt = New DataTable
        End Try

        Return dt
    End Function

    Public Shared Function UpdateStatusPostFB(UserName As String, tag_no As String, image_id As String) As Boolean
        Dim ret As Boolean = False
        Dim trans As New TransactionDB
        Try
            Dim sql As String = "update TKS_TAKE_PHOTO set is_post_facebook ='Y',updated_date = getdate(),updated_by='" & UserName & "' where tag_no ='" & tag_no & "'  and id ='" & image_id & "'"
            ret = SqlDB.ExecuteNonQuery(sql, trans.Trans)

            If ret Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
        Catch ex As Exception
            trans.RollbackTransaction()
        End Try
        Return ret
    End Function

    Public Shared Function UpdateCurrentLocation(UserName As String, tag_no As String) As Boolean
        Return UpdateCurrentStation(UserName, tag_no, "3.1")
    End Function

    Public Shared Function UpdateCurrentLocation(UserName As String, tag_no As String, StationNo As String) As Boolean
        Return UpdateCurrentStation(UserName, tag_no, StationNo)
    End Function

    Private Shared Function UpdateCurrentStation(UserName As String, tag_no As String, StationNo As String) As Boolean
        Dim ret As Boolean = False
        Dim trans As New TransactionDB
        Try
            Dim sql As String = "update TKS_REGISTER set current_station_no ='" & StationNo & "',updated_date=getdate(),updated_by='" & UserName & "' where tag_no ='" & tag_no & "'"
            ret = SqlDB.ExecuteNonQuery(sql, trans.Trans)

            If ret Then
                trans.CommitTransaction()

                ret = TagMovementENG.InsertTagMovement(tag_no, "ReaderModule", "1", "-1", StationNo)
            Else
                trans.RollbackTransaction()
            End If
        Catch ex As Exception
            trans.RollbackTransaction()
        End Try

        Return ret
    End Function

    Public Shared Function GetImagesByTagNo(tag_no As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim sql As String = "select id,tag_no ,image_file from TKS_TAKE_PHOTO PH where tag_no='" & tag_no & "'"
            dt = SqlDB.ExecuteTable(sql)
        Catch ex As Exception
        End Try

        Return dt
    End Function

    Public Shared Function GetNameByTagNo(tag_no As String) As String
        Dim dt As New DataTable
        Dim name As String = ""
        Try
            Dim sql As String = "select id,tag_no ,customer_name_th from TKS_REGISTER  where tag_no='" & tag_no & "'"
            dt = SqlDB.ExecuteTable(sql)
            If dt.Rows.Count > 0 Then
                name = dt.Rows(0)("customer_name_th").ToString
            End If
        Catch ex As Exception
        End Try

        Return name
    End Function

    Public Shared Function GetRegisterDataByTagNo(tag_no As String) As DataTable
        Dim dt As New DataTable

        Try
            Dim sql As String = "select customer_name_th from TKS_REGISTER PH where tag_no='" & tag_no & "'"
            dt = SqlDB.ExecuteTable(sql)
        Catch ex As Exception

        End Try

        Return dt
    End Function
End Class
