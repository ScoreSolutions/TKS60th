Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 
Imports DB = LinqDB.ConnectDB.SQLDB
Imports LinqDB.ConnectDB

Namespace TABLE
    'Represents a transaction for TKS_REGISTER table LinqDB.
    '[Create by  on Febuary, 10 2015]
    Public Class TksRegisterLinqDB
        Public sub TksRegisterLinqDB()

        End Sub 
        ' TKS_REGISTER
        Const _tableName As String = "TKS_REGISTER"
        Dim _deletedRow As Int16 = 0

        'Set Common Property
        Dim _error As String = ""
        Dim _information As String = ""
        Dim _haveData As Boolean = False

        Public ReadOnly Property TableName As String
            Get
                Return _tableName
            End Get
        End Property
        Public ReadOnly Property ErrorMessage As String
            Get
                Return _error
            End Get
        End Property
        Public ReadOnly Property InfoMessage As String
            Get
                Return _information
            End Get
        End Property
        Public ReadOnly Property HaveData As Boolean
            Get
                Return _haveData
            End Get
        End Property


        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATED_BY As String = ""
        Dim _CREATED_DATE As DateTime = New DateTime(1,1,1)
        Dim _UPDATED_BY As  String  = ""
        Dim _UPDATED_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _BARCODE As String = ""
        Dim _OWNER_NAME As  String  = ""
        Dim _GROUP_NAME As  String  = ""
        Dim _SUB_GROUP As  String  = ""
        Dim _CUSTOMER_NAME_TH As String = ""
        Dim _CUSTOMER_NAME_EN As  String  = ""
        Dim _ADDRESS As  String  = ""
        Dim _POSTCODE As  String  = ""
        Dim _POSITION_NAME As  String  = ""
        Dim _COMPANY_NAME As String = ""
        Dim _EMAIL As  String  = ""
        Dim _MOBILE_NO As  String  = ""
        Dim _TEL_NO As  String  = ""
        Dim _REF1 As  String  = ""
        Dim _REF2 As  String  = ""
        Dim _TAG_NO As  String  = ""
        Dim _IS_INVITE As Char = "Y"
        Dim _IS_REGISTER As Char = "N"
        Dim _REGISTER_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _CURRENT_STATION_NO As  String  = "0"
        Dim _TITLE_NAME As  String  = ""
        Dim _FIRST_NAME As  String  = ""
        Dim _SURNAME As  String  = ""

        'Generate Field Property 
        <Column(Storage:="_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ID() As Long
            Get
                Return _ID
            End Get
            Set(ByVal value As Long)
               _ID = value
            End Set
        End Property 
        <Column(Storage:="_CREATED_BY", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATED_BY() As String
            Get
                Return _CREATED_BY
            End Get
            Set(ByVal value As String)
               _CREATED_BY = value
            End Set
        End Property 
        <Column(Storage:="_CREATED_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATED_DATE() As DateTime
            Get
                Return _CREATED_DATE
            End Get
            Set(ByVal value As DateTime)
               _CREATED_DATE = value
            End Set
        End Property 
        <Column(Storage:="_UPDATED_BY", DbType:="VarChar(100)")>  _
        Public Property UPDATED_BY() As  String 
            Get
                Return _UPDATED_BY
            End Get
            Set(ByVal value As  String )
               _UPDATED_BY = value
            End Set
        End Property 
        <Column(Storage:="_UPDATED_DATE", DbType:="DateTime")>  _
        Public Property UPDATED_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _UPDATED_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _UPDATED_DATE = value
            End Set
        End Property 
        <Column(Storage:="_BARCODE", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property BARCODE() As String
            Get
                Return _BARCODE
            End Get
            Set(ByVal value As String)
               _BARCODE = value
            End Set
        End Property 
        <Column(Storage:="_OWNER_NAME", DbType:="VarChar(100)")>  _
        Public Property OWNER_NAME() As  String 
            Get
                Return _OWNER_NAME
            End Get
            Set(ByVal value As  String )
               _OWNER_NAME = value
            End Set
        End Property 
        <Column(Storage:="_GROUP_NAME", DbType:="VarChar(100)")>  _
        Public Property GROUP_NAME() As  String 
            Get
                Return _GROUP_NAME
            End Get
            Set(ByVal value As  String )
               _GROUP_NAME = value
            End Set
        End Property 
        <Column(Storage:="_SUB_GROUP", DbType:="VarChar(100)")>  _
        Public Property SUB_GROUP() As  String 
            Get
                Return _SUB_GROUP
            End Get
            Set(ByVal value As  String )
               _SUB_GROUP = value
            End Set
        End Property 
        <Column(Storage:="_CUSTOMER_NAME_TH", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property CUSTOMER_NAME_TH() As String
            Get
                Return _CUSTOMER_NAME_TH
            End Get
            Set(ByVal value As String)
               _CUSTOMER_NAME_TH = value
            End Set
        End Property 
        <Column(Storage:="_CUSTOMER_NAME_EN", DbType:="VarChar(255)")>  _
        Public Property CUSTOMER_NAME_EN() As  String 
            Get
                Return _CUSTOMER_NAME_EN
            End Get
            Set(ByVal value As  String )
               _CUSTOMER_NAME_EN = value
            End Set
        End Property 
        <Column(Storage:="_ADDRESS", DbType:="VarChar(255)")>  _
        Public Property ADDRESS() As  String 
            Get
                Return _ADDRESS
            End Get
            Set(ByVal value As  String )
               _ADDRESS = value
            End Set
        End Property 
        <Column(Storage:="_POSTCODE", DbType:="VarChar(50)")>  _
        Public Property POSTCODE() As  String 
            Get
                Return _POSTCODE
            End Get
            Set(ByVal value As  String )
               _POSTCODE = value
            End Set
        End Property 
        <Column(Storage:="_POSITION_NAME", DbType:="VarChar(255)")>  _
        Public Property POSITION_NAME() As  String 
            Get
                Return _POSITION_NAME
            End Get
            Set(ByVal value As  String )
               _POSITION_NAME = value
            End Set
        End Property 
        <Column(Storage:="_COMPANY_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property COMPANY_NAME() As String
            Get
                Return _COMPANY_NAME
            End Get
            Set(ByVal value As String)
               _COMPANY_NAME = value
            End Set
        End Property 
        <Column(Storage:="_EMAIL", DbType:="VarChar(255)")>  _
        Public Property EMAIL() As  String 
            Get
                Return _EMAIL
            End Get
            Set(ByVal value As  String )
               _EMAIL = value
            End Set
        End Property 
        <Column(Storage:="_MOBILE_NO", DbType:="VarChar(100)")>  _
        Public Property MOBILE_NO() As  String 
            Get
                Return _MOBILE_NO
            End Get
            Set(ByVal value As  String )
               _MOBILE_NO = value
            End Set
        End Property 
        <Column(Storage:="_TEL_NO", DbType:="VarChar(100)")>  _
        Public Property TEL_NO() As  String 
            Get
                Return _TEL_NO
            End Get
            Set(ByVal value As  String )
               _TEL_NO = value
            End Set
        End Property 
        <Column(Storage:="_REF1", DbType:="VarChar(100)")>  _
        Public Property REF1() As  String 
            Get
                Return _REF1
            End Get
            Set(ByVal value As  String )
               _REF1 = value
            End Set
        End Property 
        <Column(Storage:="_REF2", DbType:="VarChar(100)")>  _
        Public Property REF2() As  String 
            Get
                Return _REF2
            End Get
            Set(ByVal value As  String )
               _REF2 = value
            End Set
        End Property 
        <Column(Storage:="_TAG_NO", DbType:="VarChar(20)")>  _
        Public Property TAG_NO() As  String 
            Get
                Return _TAG_NO
            End Get
            Set(ByVal value As  String )
               _TAG_NO = value
            End Set
        End Property 
        <Column(Storage:="_IS_INVITE", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property IS_INVITE() As Char
            Get
                Return _IS_INVITE
            End Get
            Set(ByVal value As Char)
               _IS_INVITE = value
            End Set
        End Property 
        <Column(Storage:="_IS_REGISTER", DbType:="Char(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property IS_REGISTER() As Char
            Get
                Return _IS_REGISTER
            End Get
            Set(ByVal value As Char)
               _IS_REGISTER = value
            End Set
        End Property 
        <Column(Storage:="_REGISTER_TIME", DbType:="DateTime")>  _
        Public Property REGISTER_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _REGISTER_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _REGISTER_TIME = value
            End Set
        End Property 
        <Column(Storage:="_CURRENT_STATION_NO", DbType:="VarChar(50)")>  _
        Public Property CURRENT_STATION_NO() As  String 
            Get
                Return _CURRENT_STATION_NO
            End Get
            Set(ByVal value As  String )
               _CURRENT_STATION_NO = value
            End Set
        End Property 
        <Column(Storage:="_TITLE_NAME", DbType:="VarChar(100)")>  _
        Public Property TITLE_NAME() As  String 
            Get
                Return _TITLE_NAME
            End Get
            Set(ByVal value As  String )
               _TITLE_NAME = value
            End Set
        End Property 
        <Column(Storage:="_FIRST_NAME", DbType:="VarChar(100)")>  _
        Public Property FIRST_NAME() As  String 
            Get
                Return _FIRST_NAME
            End Get
            Set(ByVal value As  String )
               _FIRST_NAME = value
            End Set
        End Property 
        <Column(Storage:="_SURNAME", DbType:="VarChar(100)")>  _
        Public Property SURNAME() As  String 
            Get
                Return _SURNAME
            End Get
            Set(ByVal value As  String )
               _SURNAME = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _BARCODE = ""
            _OWNER_NAME = ""
            _GROUP_NAME = ""
            _SUB_GROUP = ""
            _CUSTOMER_NAME_TH = ""
            _CUSTOMER_NAME_EN = ""
            _ADDRESS = ""
            _POSTCODE = ""
            _POSITION_NAME = ""
            _COMPANY_NAME = ""
            _EMAIL = ""
            _MOBILE_NO = ""
            _TEL_NO = ""
            _REF1 = ""
            _REF2 = ""
            _TAG_NO = ""
            _IS_INVITE = "Y"
            _IS_REGISTER = "N"
            _REGISTER_TIME = New DateTime(1,1,1)
            _CURRENT_STATION_NO = "0"
            _TITLE_NAME = ""
            _FIRST_NAME = ""
            _SURNAME = ""
        End Sub

       'Define Public Method 
        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=orderBy>The fields for sort data.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetDataList(whClause As String, orderBy As String, trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(SqlSelect & IIf(whClause = "", "", " WHERE " & whClause) & IIF(orderBy = "", "", " ORDER BY  " & orderBy), trans)
        End Function


        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetListBySql(Sql As String, trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(Sql, trans)
        End Function


        '/// Returns an indication whether the current data is inserted into TKS_REGISTER table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _Created_By = LoginName
                _Created_Date = DateTime.Now
                Return doInsert(trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to TKS_REGISTER table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPK(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _Updated_By = LoginName
                _Updated_Date = DateTime.Now
                Return doUpdate("ID = " & DB.SetDouble(_ID), trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to TKS_REGISTER table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return (DB.ExecuteNonQuery(Sql, trans) > -1)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TKS_REGISTER table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByPK(cID As Long, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return doDelete("ID = " & DB.SetDouble(cID), trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the record of TKS_REGISTER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TKS_REGISTER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TksRegisterLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of TKS_REGISTER by specified BARCODE key is retrieved successfully.
        '/// <param name=cBARCODE>The BARCODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByBARCODE(cBARCODE As String, trans As SQLTransaction) As Boolean
            Return doChkData("BARCODE = " & DB.SetString(cBARCODE) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TKS_REGISTER by specified BARCODE key is retrieved successfully.
        '/// <param name=cBARCODE>The BARCODE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByBARCODE(cBARCODE As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("BARCODE = " & DB.SetString(cBARCODE) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TKS_REGISTER by specified TAG_NO key is retrieved successfully.
        '/// <param name=cTAG_NO>The TAG_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByTAG_NO(cTAG_NO As String, trans As SQLTransaction) As Boolean
            Return doChkData("TAG_NO = " & DB.SetString(cTAG_NO) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TKS_REGISTER by specified TAG_NO key is retrieved successfully.
        '/// <param name=cTAG_NO>The TAG_NO key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByTAG_NO(cTAG_NO As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("TAG_NO = " & DB.SetString(cTAG_NO) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TKS_REGISTER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TKS_REGISTER table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Private Function doInsert(trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If _haveData = False Then
                Try
                    Dim dt as DataTable = DB.ExecuteTable(SqlInsert, trans, SetParameterData())
                    If dt.Rows.Count = 0 Then
                        _error = DB.ErrorMessage
                        ret = False
                    Else
                        _ID = dt.Rows(0)("ID")
                        _haveData = True
                        ret = True
                    End If
                    _information = MessageResources.MSGIN001
                Catch ex As ApplicationException
                    ret = false
                    _error = ex.Message & "ApplicationException :" & ex.ToString() & "### SQL:" & SqlInsert
                Catch ex As Exception
                    ret = False
                    _error = MessageResources.MSGEC101 & " Exception :" & ex.ToString() & "### SQL: " & SqlInsert
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEN002 & "### SQL: " & SqlInsert
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is updated to TKS_REGISTER table successfully.
        '/// <param name=whText>The condition specify the updating record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Private Function doUpdate(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " Where " & whText
            If _haveData = True Then
                If whText.Trim() <> ""
                    Try
                        ret = DB.ExecuteNonQuery(SqlUpdate & tmpWhere, trans, SetParameterData())
                        If ret = False Then
                            _error = DB.ErrorMessage
                        End If
                        _information = MessageResources.MSGIU001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message & "ApplicationException :" & ex.ToString() & "### SQL:" & SqlUpdate & tmpWhere
                    Catch ex As Exception
                        ret = False
                        _error = MessageResources.MSGEC102 & " Exception :" & ex.ToString() & "### SQL: " & SqlUpdate & tmpWhere
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGEU003 & "### SQL: " & SqlUpdate & tmpWhere
                End If
            Else
                ret = True
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is deleted from TKS_REGISTER table successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Private Function doDelete(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " Where " & whText
            If doChkData(whText, trans) = True Then
                If whText.Trim() <> ""
                    Try
                        ret = (DB.ExecuteNonQuery(SqlDelete & tmpWhere, trans) > -1)
                        If ret = False Then
                            _error = MessageResources.MSGED001
                        End If
                        _information = MessageResources.MSGID001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message & "ApplicationException :" & ex.ToString() & "### SQL:" & SqlDelete & tmpWhere
                    Catch ex As Exception
                        ret = False
                        _error = MessageResources.MSGEC103 & " Exception :" & ex.ToString() & "### SQL: " & SqlDelete & tmpWhere
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGED003 & "### SQL: " & SqlDelete & tmpWhere
                End If
            Else
                ret = True
            End If

            Return ret
        End Function

        Private Function SetParameterData() As SqlParameter()
            Dim cmbParam(27) As SqlParameter
            cmbParam(0) = New SqlParameter("@_ID", SqlDbType.BigInt)
            cmbParam(0).Value = _ID

            cmbParam(1) = New SqlParameter("@_CREATED_BY", SqlDbType.VarChar)
            cmbParam(1).Value = _CREATED_BY

            cmbParam(2) = New SqlParameter("@_CREATED_DATE", SqlDbType.DateTime)
            cmbParam(2).Value = _CREATED_DATE

            cmbParam(3) = New SqlParameter("@_UPDATED_BY", SqlDbType.VarChar)
            If _UPDATED_BY.Trim <> "" Then 
                cmbParam(3).Value = _UPDATED_BY
            Else
                cmbParam(3).Value = DBNull.value
            End If

            cmbParam(4) = New SqlParameter("@_UPDATED_DATE", SqlDbType.DateTime)
            If _UPDATED_DATE.Value.Year > 1 Then 
                cmbParam(4).Value = _UPDATED_DATE.Value
            Else
                cmbParam(4).Value = DBNull.value
            End If

            cmbParam(5) = New SqlParameter("@_BARCODE", SqlDbType.VarChar)
            cmbParam(5).Value = _BARCODE

            cmbParam(6) = New SqlParameter("@_OWNER_NAME", SqlDbType.VarChar)
            If _OWNER_NAME.Trim <> "" Then 
                cmbParam(6).Value = _OWNER_NAME
            Else
                cmbParam(6).Value = DBNull.value
            End If

            cmbParam(7) = New SqlParameter("@_GROUP_NAME", SqlDbType.VarChar)
            If _GROUP_NAME.Trim <> "" Then 
                cmbParam(7).Value = _GROUP_NAME
            Else
                cmbParam(7).Value = DBNull.value
            End If

            cmbParam(8) = New SqlParameter("@_SUB_GROUP", SqlDbType.VarChar)
            If _SUB_GROUP.Trim <> "" Then 
                cmbParam(8).Value = _SUB_GROUP
            Else
                cmbParam(8).Value = DBNull.value
            End If

            cmbParam(9) = New SqlParameter("@_CUSTOMER_NAME_TH", SqlDbType.VarChar)
            cmbParam(9).Value = _CUSTOMER_NAME_TH

            cmbParam(10) = New SqlParameter("@_CUSTOMER_NAME_EN", SqlDbType.VarChar)
            If _CUSTOMER_NAME_EN.Trim <> "" Then 
                cmbParam(10).Value = _CUSTOMER_NAME_EN
            Else
                cmbParam(10).Value = DBNull.value
            End If

            cmbParam(11) = New SqlParameter("@_ADDRESS", SqlDbType.VarChar)
            If _ADDRESS.Trim <> "" Then 
                cmbParam(11).Value = _ADDRESS
            Else
                cmbParam(11).Value = DBNull.value
            End If

            cmbParam(12) = New SqlParameter("@_POSTCODE", SqlDbType.VarChar)
            If _POSTCODE.Trim <> "" Then 
                cmbParam(12).Value = _POSTCODE
            Else
                cmbParam(12).Value = DBNull.value
            End If

            cmbParam(13) = New SqlParameter("@_POSITION_NAME", SqlDbType.VarChar)
            If _POSITION_NAME.Trim <> "" Then 
                cmbParam(13).Value = _POSITION_NAME
            Else
                cmbParam(13).Value = DBNull.value
            End If

            cmbParam(14) = New SqlParameter("@_COMPANY_NAME", SqlDbType.VarChar)
            cmbParam(14).Value = _COMPANY_NAME

            cmbParam(15) = New SqlParameter("@_EMAIL", SqlDbType.VarChar)
            If _EMAIL.Trim <> "" Then 
                cmbParam(15).Value = _EMAIL
            Else
                cmbParam(15).Value = DBNull.value
            End If

            cmbParam(16) = New SqlParameter("@_MOBILE_NO", SqlDbType.VarChar)
            If _MOBILE_NO.Trim <> "" Then 
                cmbParam(16).Value = _MOBILE_NO
            Else
                cmbParam(16).Value = DBNull.value
            End If

            cmbParam(17) = New SqlParameter("@_TEL_NO", SqlDbType.VarChar)
            If _TEL_NO.Trim <> "" Then 
                cmbParam(17).Value = _TEL_NO
            Else
                cmbParam(17).Value = DBNull.value
            End If

            cmbParam(18) = New SqlParameter("@_REF1", SqlDbType.VarChar)
            If _REF1.Trim <> "" Then 
                cmbParam(18).Value = _REF1
            Else
                cmbParam(18).Value = DBNull.value
            End If

            cmbParam(19) = New SqlParameter("@_REF2", SqlDbType.VarChar)
            If _REF2.Trim <> "" Then 
                cmbParam(19).Value = _REF2
            Else
                cmbParam(19).Value = DBNull.value
            End If

            cmbParam(20) = New SqlParameter("@_TAG_NO", SqlDbType.VarChar)
            If _TAG_NO.Trim <> "" Then 
                cmbParam(20).Value = _TAG_NO
            Else
                cmbParam(20).Value = DBNull.value
            End If

            cmbParam(21) = New SqlParameter("@_IS_INVITE", SqlDbType.Char)
            cmbParam(21).Value = _IS_INVITE

            cmbParam(22) = New SqlParameter("@_IS_REGISTER", SqlDbType.Char)
            cmbParam(22).Value = _IS_REGISTER

            cmbParam(23) = New SqlParameter("@_REGISTER_TIME", SqlDbType.DateTime)
            If _REGISTER_TIME.Value.Year > 1 Then 
                cmbParam(23).Value = _REGISTER_TIME.Value
            Else
                cmbParam(23).Value = DBNull.value
            End If

            cmbParam(24) = New SqlParameter("@_CURRENT_STATION_NO", SqlDbType.VarChar)
            If _CURRENT_STATION_NO.Trim <> "" Then 
                cmbParam(24).Value = _CURRENT_STATION_NO
            Else
                cmbParam(24).Value = DBNull.value
            End If

            cmbParam(25) = New SqlParameter("@_TITLE_NAME", SqlDbType.VarChar)
            If _TITLE_NAME.Trim <> "" Then 
                cmbParam(25).Value = _TITLE_NAME
            Else
                cmbParam(25).Value = DBNull.value
            End If

            cmbParam(26) = New SqlParameter("@_FIRST_NAME", SqlDbType.VarChar)
            If _FIRST_NAME.Trim <> "" Then 
                cmbParam(26).Value = _FIRST_NAME
            Else
                cmbParam(26).Value = DBNull.value
            End If

            cmbParam(27) = New SqlParameter("@_SURNAME", SqlDbType.VarChar)
            If _SURNAME.Trim <> "" Then 
                cmbParam(27).Value = _SURNAME
            Else
                cmbParam(27).Value = DBNull.value
            End If

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of TKS_REGISTER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doChkData(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " WHERE " & whText
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("created_by")) = False Then _created_by = Rdr("created_by").ToString()
                        If Convert.IsDBNull(Rdr("created_date")) = False Then _created_date = Convert.ToDateTime(Rdr("created_date"))
                        If Convert.IsDBNull(Rdr("updated_by")) = False Then _updated_by = Rdr("updated_by").ToString()
                        If Convert.IsDBNull(Rdr("updated_date")) = False Then _updated_date = Convert.ToDateTime(Rdr("updated_date"))
                        If Convert.IsDBNull(Rdr("barcode")) = False Then _barcode = Rdr("barcode").ToString()
                        If Convert.IsDBNull(Rdr("owner_name")) = False Then _owner_name = Rdr("owner_name").ToString()
                        If Convert.IsDBNull(Rdr("group_name")) = False Then _group_name = Rdr("group_name").ToString()
                        If Convert.IsDBNull(Rdr("sub_group")) = False Then _sub_group = Rdr("sub_group").ToString()
                        If Convert.IsDBNull(Rdr("customer_name_th")) = False Then _customer_name_th = Rdr("customer_name_th").ToString()
                        If Convert.IsDBNull(Rdr("customer_name_en")) = False Then _customer_name_en = Rdr("customer_name_en").ToString()
                        If Convert.IsDBNull(Rdr("address")) = False Then _address = Rdr("address").ToString()
                        If Convert.IsDBNull(Rdr("postcode")) = False Then _postcode = Rdr("postcode").ToString()
                        If Convert.IsDBNull(Rdr("position_name")) = False Then _position_name = Rdr("position_name").ToString()
                        If Convert.IsDBNull(Rdr("company_name")) = False Then _company_name = Rdr("company_name").ToString()
                        If Convert.IsDBNull(Rdr("email")) = False Then _email = Rdr("email").ToString()
                        If Convert.IsDBNull(Rdr("mobile_no")) = False Then _mobile_no = Rdr("mobile_no").ToString()
                        If Convert.IsDBNull(Rdr("tel_no")) = False Then _tel_no = Rdr("tel_no").ToString()
                        If Convert.IsDBNull(Rdr("ref1")) = False Then _ref1 = Rdr("ref1").ToString()
                        If Convert.IsDBNull(Rdr("ref2")) = False Then _ref2 = Rdr("ref2").ToString()
                        If Convert.IsDBNull(Rdr("tag_no")) = False Then _tag_no = Rdr("tag_no").ToString()
                        If Convert.IsDBNull(Rdr("is_invite")) = False Then _is_invite = Rdr("is_invite").ToString()
                        If Convert.IsDBNull(Rdr("is_register")) = False Then _is_register = Rdr("is_register").ToString()
                        If Convert.IsDBNull(Rdr("register_time")) = False Then _register_time = Convert.ToDateTime(Rdr("register_time"))
                        If Convert.IsDBNull(Rdr("current_station_no")) = False Then _current_station_no = Rdr("current_station_no").ToString()
                        If Convert.IsDBNull(Rdr("title_name")) = False Then _title_name = Rdr("title_name").ToString()
                        If Convert.IsDBNull(Rdr("first_name")) = False Then _first_name = Rdr("first_name").ToString()
                        If Convert.IsDBNull(Rdr("surname")) = False Then _surname = Rdr("surname").ToString()
                    Else
                        ret = False
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    ret = False
                    _error = MessageResources.MSGEC104 & " #### " & ex.ToString()
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEV001
            End If

            Return ret
        End Function


        '/// Returns an indication whether the record of TKS_REGISTER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As TksRegisterLinqDB
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("created_by")) = False Then _created_by = Rdr("created_by").ToString()
                        If Convert.IsDBNull(Rdr("created_date")) = False Then _created_date = Convert.ToDateTime(Rdr("created_date"))
                        If Convert.IsDBNull(Rdr("updated_by")) = False Then _updated_by = Rdr("updated_by").ToString()
                        If Convert.IsDBNull(Rdr("updated_date")) = False Then _updated_date = Convert.ToDateTime(Rdr("updated_date"))
                        If Convert.IsDBNull(Rdr("barcode")) = False Then _barcode = Rdr("barcode").ToString()
                        If Convert.IsDBNull(Rdr("owner_name")) = False Then _owner_name = Rdr("owner_name").ToString()
                        If Convert.IsDBNull(Rdr("group_name")) = False Then _group_name = Rdr("group_name").ToString()
                        If Convert.IsDBNull(Rdr("sub_group")) = False Then _sub_group = Rdr("sub_group").ToString()
                        If Convert.IsDBNull(Rdr("customer_name_th")) = False Then _customer_name_th = Rdr("customer_name_th").ToString()
                        If Convert.IsDBNull(Rdr("customer_name_en")) = False Then _customer_name_en = Rdr("customer_name_en").ToString()
                        If Convert.IsDBNull(Rdr("address")) = False Then _address = Rdr("address").ToString()
                        If Convert.IsDBNull(Rdr("postcode")) = False Then _postcode = Rdr("postcode").ToString()
                        If Convert.IsDBNull(Rdr("position_name")) = False Then _position_name = Rdr("position_name").ToString()
                        If Convert.IsDBNull(Rdr("company_name")) = False Then _company_name = Rdr("company_name").ToString()
                        If Convert.IsDBNull(Rdr("email")) = False Then _email = Rdr("email").ToString()
                        If Convert.IsDBNull(Rdr("mobile_no")) = False Then _mobile_no = Rdr("mobile_no").ToString()
                        If Convert.IsDBNull(Rdr("tel_no")) = False Then _tel_no = Rdr("tel_no").ToString()
                        If Convert.IsDBNull(Rdr("ref1")) = False Then _ref1 = Rdr("ref1").ToString()
                        If Convert.IsDBNull(Rdr("ref2")) = False Then _ref2 = Rdr("ref2").ToString()
                        If Convert.IsDBNull(Rdr("tag_no")) = False Then _tag_no = Rdr("tag_no").ToString()
                        If Convert.IsDBNull(Rdr("is_invite")) = False Then _is_invite = Rdr("is_invite").ToString()
                        If Convert.IsDBNull(Rdr("is_register")) = False Then _is_register = Rdr("is_register").ToString()
                        If Convert.IsDBNull(Rdr("register_time")) = False Then _register_time = Convert.ToDateTime(Rdr("register_time"))
                        If Convert.IsDBNull(Rdr("current_station_no")) = False Then _current_station_no = Rdr("current_station_no").ToString()
                        If Convert.IsDBNull(Rdr("title_name")) = False Then _title_name = Rdr("title_name").ToString()
                        If Convert.IsDBNull(Rdr("first_name")) = False Then _first_name = Rdr("first_name").ToString()
                        If Convert.IsDBNull(Rdr("surname")) = False Then _surname = Rdr("surname").ToString()
                    Else
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    _error = MessageResources.MSGEC104 & " #### " & ex.ToString()
                End Try
            Else
                _error = MessageResources.MSGEV001
            End If
            Return Me
        End Function



        ' SQL Statements


        'Get Insert Statement for table TKS_REGISTER
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, BARCODE, OWNER_NAME, GROUP_NAME, SUB_GROUP, CUSTOMER_NAME_TH, CUSTOMER_NAME_EN, ADDRESS, POSTCODE, POSITION_NAME, COMPANY_NAME, EMAIL, MOBILE_NO, TEL_NO, REF1, REF2, TAG_NO, IS_INVITE, IS_REGISTER, REGISTER_TIME, CURRENT_STATION_NO, TITLE_NAME, FIRST_NAME, SURNAME)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.BARCODE, INSERTED.OWNER_NAME, INSERTED.GROUP_NAME, INSERTED.SUB_GROUP, INSERTED.CUSTOMER_NAME_TH, INSERTED.CUSTOMER_NAME_EN, INSERTED.ADDRESS, INSERTED.POSTCODE, INSERTED.POSITION_NAME, INSERTED.COMPANY_NAME, INSERTED.EMAIL, INSERTED.MOBILE_NO, INSERTED.TEL_NO, INSERTED.REF1, INSERTED.REF2, INSERTED.TAG_NO, INSERTED.IS_INVITE, INSERTED.IS_REGISTER, INSERTED.REGISTER_TIME, INSERTED.CURRENT_STATION_NO, INSERTED.TITLE_NAME, INSERTED.FIRST_NAME, INSERTED.SURNAME
                Sql += " VALUES("
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_UPDATED_BY" & ", "
                sql += "@_UPDATED_DATE" & ", "
                sql += "@_BARCODE" & ", "
                sql += "@_OWNER_NAME" & ", "
                sql += "@_GROUP_NAME" & ", "
                sql += "@_SUB_GROUP" & ", "
                sql += "@_CUSTOMER_NAME_TH" & ", "
                sql += "@_CUSTOMER_NAME_EN" & ", "
                sql += "@_ADDRESS" & ", "
                sql += "@_POSTCODE" & ", "
                sql += "@_POSITION_NAME" & ", "
                sql += "@_COMPANY_NAME" & ", "
                sql += "@_EMAIL" & ", "
                sql += "@_MOBILE_NO" & ", "
                sql += "@_TEL_NO" & ", "
                sql += "@_REF1" & ", "
                sql += "@_REF2" & ", "
                sql += "@_TAG_NO" & ", "
                sql += "@_IS_INVITE" & ", "
                sql += "@_IS_REGISTER" & ", "
                sql += "@_REGISTER_TIME" & ", "
                sql += "@_CURRENT_STATION_NO" & ", "
                sql += "@_TITLE_NAME" & ", "
                sql += "@_FIRST_NAME" & ", "
                sql += "@_SURNAME"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TKS_REGISTER
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATED_BY = " & "@_CREATED_BY" & ", "
                Sql += "CREATED_DATE = " & "@_CREATED_DATE" & ", "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "BARCODE = " & "@_BARCODE" & ", "
                Sql += "OWNER_NAME = " & "@_OWNER_NAME" & ", "
                Sql += "GROUP_NAME = " & "@_GROUP_NAME" & ", "
                Sql += "SUB_GROUP = " & "@_SUB_GROUP" & ", "
                Sql += "CUSTOMER_NAME_TH = " & "@_CUSTOMER_NAME_TH" & ", "
                Sql += "CUSTOMER_NAME_EN = " & "@_CUSTOMER_NAME_EN" & ", "
                Sql += "ADDRESS = " & "@_ADDRESS" & ", "
                Sql += "POSTCODE = " & "@_POSTCODE" & ", "
                Sql += "POSITION_NAME = " & "@_POSITION_NAME" & ", "
                Sql += "COMPANY_NAME = " & "@_COMPANY_NAME" & ", "
                Sql += "EMAIL = " & "@_EMAIL" & ", "
                Sql += "MOBILE_NO = " & "@_MOBILE_NO" & ", "
                Sql += "TEL_NO = " & "@_TEL_NO" & ", "
                Sql += "REF1 = " & "@_REF1" & ", "
                Sql += "REF2 = " & "@_REF2" & ", "
                Sql += "TAG_NO = " & "@_TAG_NO" & ", "
                Sql += "IS_INVITE = " & "@_IS_INVITE" & ", "
                Sql += "IS_REGISTER = " & "@_IS_REGISTER" & ", "
                Sql += "REGISTER_TIME = " & "@_REGISTER_TIME" & ", "
                Sql += "CURRENT_STATION_NO = " & "@_CURRENT_STATION_NO" & ", "
                Sql += "TITLE_NAME = " & "@_TITLE_NAME" & ", "
                Sql += "FIRST_NAME = " & "@_FIRST_NAME" & ", "
                Sql += "SURNAME = " & "@_SURNAME" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TKS_REGISTER
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TKS_REGISTER
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, BARCODE, OWNER_NAME, GROUP_NAME, SUB_GROUP, CUSTOMER_NAME_TH, CUSTOMER_NAME_EN, ADDRESS, POSTCODE, POSITION_NAME, COMPANY_NAME, EMAIL, MOBILE_NO, TEL_NO, REF1, REF2, TAG_NO, IS_INVITE, IS_REGISTER, REGISTER_TIME, CURRENT_STATION_NO, TITLE_NAME, FIRST_NAME, SURNAME FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace
