Imports LinqDB.ConnectDB
Imports LinqDB.TABLE
Public Class PreRegister
    Public Shared Function SavePreRegister(UserName As String, dt As DataTable) As String
        Dim ret As Boolean = False
        Dim _err As String = ""
        Dim trans As New TransactionDB
        Try
            Dim lnq As New TksRegisterLinqDB
            If dt.Rows.Count > 0 Then
                With lnq
                    .GetDataByPK(dt.Rows(0)("ID").ToString, trans.Trans)
                    .BARCODE = dt.Rows(0)("BARCODE").ToString
                    .CUSTOMER_NAME_TH = dt.Rows(0)("CUSTOMER_NAME_TH").ToString
                    .CUSTOMER_NAME_EN = dt.Rows(0)("CUSTOMER_NAME_EN").ToString
                    .COMPANY_NAME = dt.Rows(0)("COMPANY_NAME").ToString
                    .POSITION_NAME = dt.Rows(0)("POSITION_NAME").ToString
                    .ADDRESS = dt.Rows(0)("ADDRESS").ToString
                    .POSTCODE = dt.Rows(0)("POSTCODE").ToString
                    .OWNER_NAME = dt.Rows(0)("OWNER").ToString
                    .GROUP_NAME = dt.Rows(0)("GROUP").ToString
                    .SUB_GROUP = dt.Rows(0)("SUB_GROUP").ToString
                    .TEL_NO = dt.Rows(0)("TEL_NO").ToString
                    .MOBILE_NO = dt.Rows(0)("MOBILE_NO").ToString
                    .EMAIL = dt.Rows(0)("EMAIL").ToString
                    .REF1 = dt.Rows(0)("REF1").ToString
                    .REF2 = dt.Rows(0)("REF2").ToString
                    .TAG_NO = dt.Rows(0)("TAG_NO").ToString
                    .IS_INVITE = dt.Rows(0)("IS_INVITE").ToString
                    .IS_REGISTER = dt.Rows(0)("IS_REGISTER").ToString
                    If IsDBNull(dt.Rows(0)("REGISTER_TIME")) = False Then
                        .REGISTER_TIME = Convert.ToDateTime(dt.Rows(0)("REGISTER_TIME"))
                    End If

                    .TITLE_NAME = dt.Rows(0)("title_name").ToString
                    .FIRST_NAME = dt.Rows(0)("first_name").ToString
                    .SURNAME = dt.Rows(0)("surname").ToString

                    If IsDBNull(dt.Rows(0)("current_station_no")) = False Then
                        .CURRENT_STATION_NO = dt.Rows(0)("current_station_no").ToString
                    End If


                    If lnq.ID < 0 Then
                        ret = .InsertData(UserName, trans.Trans)
                    Else
                        ret = .UpdateByPK(UserName, trans.Trans)
                    End If
                End With
            End If

            If ret Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
                _err = "Error! " & lnq.ErrorMessage
            End If
        Catch ex As Exception
            trans.RollbackTransaction()
            _err = "Error! " & ex.ToString
        End Try

        Return _err
    End Function

    Public Shared Function SaveRegister1to1Signage(UserName As String, TagNo As String, CustomerName As String, CompanyName As String) As String
        Dim ret As String = ""
        Try
            Dim trans As New TransactionDB
            Dim lnq As New TksRegister1to1SignageLinqDB
            lnq.TAG_NO = TagNo
            lnq.REGISTER_TIME = SqlDB.GetDateNowFromDB(trans.Trans)
            lnq.CUSTOMER_NAME = CustomerName
            lnq.COMPANY_NAME = CompanyName
            lnq.DISPLAY_STATUS = "N"

            Dim re As Boolean = lnq.InsertData(UserName, trans.Trans)
            If re = True Then
                trans.CommitTransaction()
            Else
                ret = lnq.ErrorMessage
                trans.RollbackTransaction()
            End If
        Catch ex As Exception
            ret = ex.Message
        End Try
        Return ret
    End Function


    Public Shared Function GetRegisterDataByBarcode(barcode As String) As DataTable
        Return GetRegisterData(" and barcode='" & barcode & "'")
    End Function

    Public Shared Function GetRegisterDataByTagNo(TagNo As String) As DataTable
        Return GetRegisterData(" and tag_no='" & TagNo & "'")
    End Function

    Private Shared Function GetRegisterData(wh As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim sql As String = "select  id,barcode,customer_name_th,customer_name_en,company_name,position_name,[address],postcode, "
            sql += " owner_name, group_name, sub_group, tel_no, mobile_no, email, ref1, ref2, tag_no,title_name,first_name,surname"
            sql += " from TKS_REGISTER"
            sql += " where 1=1 " & wh
            dt = SqlDB.ExecuteTable(sql)
        Catch ex As Exception

        End Try

        Return dt
    End Function

    Public Shared Function CheckConnection() As Boolean
        Dim ret As Boolean = SqlDB.ChkConnection()
        Return ret
    End Function

    Public Shared Function ImportExcelData(dt As DataTable) As Boolean
        Dim ret As Boolean = False
        Try
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim lnq As New LinqDB.TABLE.TksRegisterLinqDB
                    lnq.ChkDataByBARCODE(dr("barcode"), Nothing)

                    If Convert.IsDBNull(dr("barcode")) = False Then lnq.BARCODE = dr("barcode")
                    If Convert.IsDBNull(dr("OWNER")) = False Then lnq.OWNER_NAME = dr("OWNER")
                    If Convert.IsDBNull(dr("GROUP")) = False Then lnq.GROUP_NAME = dr("GROUP")
                    If Convert.IsDBNull(dr("SUB_GROUP")) = False Then lnq.SUB_GROUP = dr("SUB_GROUP")
                    If Convert.IsDBNull(dr("TITLE_NAME")) = False Then lnq.TITLE_NAME = dr("TITLE_NAME")
                    If Convert.IsDBNull(dr("NAME")) = False Then lnq.FIRST_NAME = dr("NAME")
                    If Convert.IsDBNull(dr("SURNAME")) = False Then lnq.SURNAME = dr("SURNAME")
                    If Convert.IsDBNull(dr("ADDRESS")) = False Then lnq.ADDRESS = dr("ADDRESS")
                    If Convert.IsDBNull(dr("POSTCODE")) = False Then lnq.POSTCODE = dr("POSTCODE")
                    If Convert.IsDBNull(dr("NAME_EN")) = False Then lnq.CUSTOMER_NAME_EN = dr("NAME_EN")
                    If Convert.IsDBNull(dr("POSITION")) = False Then lnq.POSITION_NAME = dr("POSITION")
                    If Convert.IsDBNull(dr("ORGANIZATION")) = False Then lnq.COMPANY_NAME = dr("ORGANIZATION")
                    If Convert.IsDBNull(dr("EMAIL")) = False Then lnq.EMAIL = dr("EMAIL")
                    If Convert.IsDBNull(dr("REF1")) = False Then lnq.REF1 = dr("REF1")
                    If Convert.IsDBNull(dr("REF2")) = False Then lnq.REF2 = dr("REF2")
                    If Convert.IsDBNull(dr("TITLE_NAME")) = False And Convert.IsDBNull(dr("NAME")) = False And Convert.IsDBNull(dr("SURNAME")) = False Then
                        lnq.CUSTOMER_NAME_TH = dr("TITLE_NAME") & " " & dr("NAME") & " " & dr("SURNAME")
                    End If

                    Dim re As Boolean = False
                    Dim trans As New TransactionDB
                    If lnq.ID > 0 Then
                        re = lnq.UpdateByPK("IMPORT", trans.Trans)
                    Else
                        re = lnq.InsertData("IMPORT", trans.Trans)
                    End If

                    If re = True Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                    End If
                Next
            End If
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function
End Class
