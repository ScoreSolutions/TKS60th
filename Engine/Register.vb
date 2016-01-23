Imports LinqDB.ConnectDB
Imports LinqDB.TABLE
Public Class Register

    Public Shared Function GetInviteName() As DataTable
        Dim dt As New DataTable
        Try
            Dim sql As String = "select id,case title_name when 'OT' then title_name_other + ' '+  first_name + ' ' + last_name  "
            sql += " else title_name + ' '+  first_name + ' ' + last_name  end name from TKS_REGISTER  where is_invite='Y' order by first_name, last_name"
            dt = SqlDB.ExecuteTable(sql)
        Catch ex As Exception
        End Try

        Return dt

    End Function

    Public Shared Function GetRegisterData(wh As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim sql As String = "select id, isnull(title_name + ' '+  first_name + ' ' + surname,customer_name_th)  name,is_invite,position_name,company_name, tag_no,barcode from TKS_REGISTER where 1 = 1 " & wh
            sql += " order by first_name,surname"
            dt = SqlDB.ExecuteTable(sql)
        Catch ex As Exception

        End Try

        Return dt
    End Function

    Public Shared Function GetRegisterDataByID(register_id As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim sql As String = "select  id, title_name,title_name_other,first_name ,last_name  "
            sql += " ,is_invite,position_name,company_name,tag_no,tel_no,mobile_no,email"
            sql += " from TKS_REGISTER where id ='" & register_id & "'"
            dt = SqlDB.ExecuteTable(sql)
        Catch ex As Exception

        End Try

        Return dt
    End Function

    Public Shared Function GetDisplayRegister1To1Signage() As DataTable
        Dim dt As New DataTable
        Try
            Dim lnq As New TksRegister1to1SignageLinqDB
            dt = lnq.GetDataList("display_status='N'", "register_time", Nothing)
            lnq = Nothing
        Catch ex As Exception
            dt = New DataTable
        End Try
        Return dt
    End Function

    Public Shared Function UpdateDisplayStatusRegister1To1(vID As Long) As Boolean
        Dim ret As Boolean = False
        Try
            Dim lnq As New TksRegister1to1SignageLinqDB
            lnq.GetDataByPK(vID, Nothing)

            lnq.DISPLAY_STATUS = "Y"
            Dim trans As New TransactionDB
            ret = lnq.UpdateByPK("SYSTEM", trans.Trans)
            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
            lnq = Nothing
        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function

    Public Shared Function SaveRegister(UserName As String, dt As DataTable, id As String) As Boolean
        Dim ret As Boolean = False
        Dim trans As New TransactionDB
        Try
            If dt.Rows.Count > 0 Then
                Dim lnq As New TksRegisterLinqDB
                lnq.GetDataByPK(id, trans.Trans)
                With lnq
                    '.IDCARD_NO = dt.Rows(0)("IDCARD_NO").ToString
                    '.TITLE_NAME = dt.Rows(0)("TITLE_NAME").ToString
                    '.TITLE_NAME_OTHER = dt.Rows(0)("TITLE_NAME_OTHER").ToString
                    '.FIRST_NAME = dt.Rows(0)("FIRST_NAME").ToString
                    '.LAST_NAME = dt.Rows(0)("LAST_NAME").ToString
                    '.POSITION_NAME = dt.Rows(0)("POSITION_NAME").ToString
                    '.COMPANY_NAME = dt.Rows(0)("COMPANY_NAME").ToString
                    '.EMAIL = dt.Rows(0)("EMAIL").ToString
                    '.MOBILE_NO = dt.Rows(0)("MOBILE_NO").ToString
                    '.TEL_NO = dt.Rows(0)("TEL_NO").ToString
                    '.TAG_NO = dt.Rows(0)("TAG_NO").ToString
                    '.IS_INVITE = dt.Rows(0)("IS_INVITE").ToString
                    '.IS_REGISTER = dt.Rows(0)("IS_REGISTER").ToString
                    '.IS_FOLLOWER = dt.Rows(0)("IS_FOLLOWER").ToString
                    'If dt.Rows(0)("TS_REGISTER_ID").ToString <> "" Then
                    '    .TS_REGISTER_ID = dt.Rows(0)("TS_REGISTER_ID").ToString
                    'End If


                    'If lnq.ID = 0 Then
                    '    ret = .InsertData(UserName, trans.Trans)
                    'Else
                    '    ret = .UpdateByPK(UserName, trans.Trans)
                    'End If

                End With
            End If

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

    Public Shared Function CheckDupplicateTagNo(tag_no As String, register_id As String) As Boolean
        Dim dt As New DataTable
        Try
            Dim sql As String = "select  id from TKS_REGISTER where tag_no ='" & tag_no & "' and id <> '" & register_id & "'"
            dt = SqlDB.ExecuteTable(sql)
            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
        End Try

        Return False
    End Function

    Public Shared Function UpdateRegisterTime(TagNo As String) As Boolean
        Dim ret As Boolean = False
        Try
            Dim trans As New TransactionDB
            Dim lnq As New TksRegisterLinqDB
            lnq.ChkDataByTAG_NO(TagNo, trans.Trans)
            If lnq.ID > 0 Then
                lnq.IS_REGISTER = "Y"
                lnq.REGISTER_TIME = SqlDB.GetDateNowFromDB(trans.Trans)

                ret = lnq.UpdateByPK("Register.UpdateRegisterTime", trans.Trans)
                If ret = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
            Else
                ret = False
            End If
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function

End Class
