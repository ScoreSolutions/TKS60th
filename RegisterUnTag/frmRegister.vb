Imports Engine
Imports System.IO
Imports ReaderModule

Public Class frmRegister

    Private Sub frmPreRegister_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If ReadWriteIOEng.comm.IsOpen = True Then
            ReadWriteIOEng.comm.Close()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Engine.PreRegister.CheckConnection = False Then
            MessageBox.Show("ไม่สามารถติดต่อฐานข้อมูลได้")
            Application.Exit()
        End If

        clear()
    End Sub

    Sub CreateTempLogFile(msg As String)
        Try
            'Dim iniReader As New Org.Mentalis.Files.IniReader(Application.StartupPath & "\config.ini")
            'Dim templogfile As String
            'templogfile = iniReader.ReadString("Setting", "templogfile")

            Dim file_name As String = Application.StartupPath & "\tkslog.txt"
            'If Directory.Exists(templogfile) = False Then
            '    Directory.CreateDirectory(templogfile)
            'End If
            If File.Exists(file_name) = False Then
                File.Create(file_name).Close()
            Else
            End If
            Dim objWriter As New System.IO.StreamWriter(file_name, True)
            objWriter.Write(msg)
            objWriter.Close()
            objWriter.Dispose()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Try
            Dim val As String = Validate()
            If val <> "" Then
                MessageBox.Show(val)
                Exit Sub
            End If


            Dim id As String = txtid.Text
            Dim barcode As String = txtBarcode.Text.Trim
            Dim title_name As String = txtTitleName.Text.Trim
            Dim first_name As String = txtName.Text.Trim
            Dim last_name As String = txtLastName.Text.Trim
            Dim name_thai As String = txtTitleName.Text.Trim & " " & txtName.Text.Trim & " " & txtLastName.Text.Trim
            Dim name_eng As String = txtNameEng.Text.Trim
            Dim company As String = txtCompany.Text.Trim
            Dim position As String = txtPosition.Text.Trim
            Dim address As String = txtAddress.Text.Trim
            Dim postcode As String = txtpostcode.Text.Trim
            Dim owner As String = txtOwner.Text.Trim
            Dim group As String = txtGroup.Text.Trim
            Dim sub_group As String = txtSubGroup.Text.Trim
            Dim tel As String = txtTel.Text.Trim
            Dim mobile_no As String = txtMobileNo.Text.Trim
            Dim email As String = txtEmail.Text.Trim
            Dim ref1 As String = txtref1.Text.Trim
            Dim ref2 As String = txtref2.Text.Trim
            Dim tag_no As String = txtTagNo.Text.Trim
            Dim is_invite As String = "Y"
            Dim is_register As String = "Y"
            ' Dim is_follower As String = "N"

            Dim ret As String = ""
            Dim dt As New DataTable
            With dt
                .Columns.Add("id")
                .Columns.Add("BARCODE")
                .Columns.Add("CUSTOMER_NAME_TH")
                .Columns.Add("CUSTOMER_NAME_EN")
                .Columns.Add("COMPANY_NAME")
                .Columns.Add("POSITION_NAME")
                .Columns.Add("ADDRESS")
                .Columns.Add("POSTCODE")
                .Columns.Add("OWNER")
                .Columns.Add("GROUP")
                .Columns.Add("SUB_GROUP")
                .Columns.Add("TEL_NO")
                .Columns.Add("MOBILE_NO")
                .Columns.Add("EMAIL")
                .Columns.Add("REF1")
                .Columns.Add("REF2")
                .Columns.Add("TAG_NO")
                .Columns.Add("IS_INVITE")
                .Columns.Add("IS_REGISTER")
                .Columns.Add("REGISTER_TIME", GetType(DateTime))
                .Columns.Add("title_name")
                .Columns.Add("first_name")
                .Columns.Add("surname")
                .Columns.Add("current_station_no")
            End With
            Dim dr As DataRow
            dr = dt.NewRow
            dr("id") = id
            dr("BARCODE") = barcode
            dr("CUSTOMER_NAME_TH") = name_thai
            dr("CUSTOMER_NAME_EN") = name_eng
            dr("COMPANY_NAME") = company
            dr("POSITION_NAME") = position
            dr("ADDRESS") = address
            dr("POSTCODE") = postcode
            dr("OWNER") = owner
            dr("GROUP") = group
            dr("SUB_GROUP") = sub_group
            dr("TEL_NO") = tel
            dr("MOBILE_NO") = mobile_no
            dr("EMAIL") = email
            dr("REF1") = ref1
            dr("REF2") = ref2
            dr("TAG_NO") = tag_no
            dr("IS_INVITE") = is_invite
            dr("IS_REGISTER") = is_register
            dr("REGISTER_TIME") = LinqDB.ConnectDB.SqlDB.GetDateNowFromDB(Nothing)
            dr("title_name") = title_name
            dr("first_name") = first_name
            dr("surname") = last_name
            dr("current_station_no") = "2"
            dt.Rows.Add(dr)

            If dt.Rows.Count > 0 Then
                ret = Engine.PreRegister.SavePreRegister("SYSTEM", dt)
            End If

            If ret = "" Then
                'ret = Engine.PreRegister.SaveRegister1to1Signage("SYSTEM", tag_no, title_name & " " & first_name & " " & last_name, company)
                If ret = "" Then
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อย")
                    clear()
                End If
            Else
                MessageBox.Show("Network connection failed.")
                CreateTempLogFile(ret)
            End If
        Catch ex As Exception
            MessageBox.Show("Network connection failed.")
            CreateTempLogFile(ex.ToString)
            ' MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Function Validate() As String
        If txtBarcode.Text.Trim = "" Then
            Return "กรุณาระบุ บาร์โค้ด"
        End If

        If txtTitleName.Text.Trim = "" Or txtName.Text.Trim = "" Or txtLastName.Text.Trim = "" Then
            Return "กรุณาระบุ คำนำหน้าชื่อ ชื่อ และนามสกุล"
        End If

        If txtCompany.Text.Trim = "" Then
            Return "กรุณาระบุ บริษัท"
        End If

        'If txtTagNo.Text.Trim = "" Then
        '    Return "กรุณาระบุ Tag No"
        'End If

        If txtEmail.Text.Trim <> "" Then
            If InStr(txtEmail.Text.Trim, "@") = 0 Then
                Return "กรุณาระบุ Email ให้ถูกต้อง"
            End If
        End If


        Return ""
    End Function

    Sub clear()
        txtBarcode.Text = ""
        txtTitleName.Text = ""
        txtName.Text = ""
        txtLastName.Text = ""
        txtNameEng.Text = ""
        txtCompany.Text = ""
        txtPosition.Text = ""
        txtAddress.Text = ""
        txtpostcode.Text = ""
        txtOwner.Text = ""
        txtGroup.Text = ""
        txtSubGroup.Text = ""
        txtTel.Text = ""
        txtMobileNo.Text = ""
        txtEmail.Text = ""
        txtref1.Text = ""
        txtref2.Text = ""
        txtTagNo.Text = ""
        txtid.Text = "0"
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Private Sub btnTag_Click(sender As Object, e As EventArgs) Handles btnTag.Click
        Try

            Dim TagNo As String = DateTime.Now.Year.ToString.Substring(0, 2) & "-" & DateTime.Now.Year.ToString.Substring(2, 2) & "-" & DateTime.Now.ToString("MM-dd-HH-mm-ss") & "-00"
            ' Write Tag  TagNo

            If ReadWriteIOEng.WriteTag(TagNo, 2, 4) = True Then
                ReadWriteIOEng.BeefON()
                txtTagNo.Text = ReadWriteIOEng.ReadTag(2, 4)
                ReadWriteIOEng.BeefOFF()


                txtTagNo.Text = Replace(txtTagNo.Text, "-", "")
            Else
                MessageBox.Show(ReadWriteIOEng.ErrorMessage)
            End If

        Catch ex As Exception
            txtTagNo.Text = ""
            ReadWriteIOEng.BeefOFF()
            MessageBox.Show(ex.Message & vbNewLine)
        End Try
    End Sub

    'Private Sub frmPreRegister_Shown(sender As Object, e As EventArgs) Handles Me.Shown
    '    Try
    '        Dim ini As New Org.Mentalis.Files.IniReader(Application.StartupPath & "\config.ini")
    '        ini.Section = "ReaderSetting"

    '        ReaderParamsEng.CommIntSelectFlag = 1
    '        ReaderParamsEng.LanguageFlag = 1
    '        ReadWriteIOEng.comm.PortName = ini.ReadString("Comport")
    '        ReadWriteIOEng.comm.BaudRate = ini.ReadString("BaudRate")
    '        ReadWriteIOEng.comm.Open()

    '        ini = Nothing

    '        Dim ID(2) As UInt32
    '        Dim result As Integer = ReaderParamsEng.GetModuleID(ID)
    '        If result <> 0 Then
    '            ReadWriteIOEng.comm.Close()
    '            MessageBox.Show("Module Error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '    End Try
    'End Sub

    Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtBarcode.Text.Trim = "" Then
                Exit Sub
            End If

            Dim barcode As String = txtBarcode.Text.Trim
            Dim dt As New DataTable
            dt = Engine.PreRegister.GetRegisterDataByBarcode(barcode)
            FillData(dt)
            dt.Dispose()
        End If
    End Sub

    Private Sub FillData(dt As DataTable)
        If dt.Rows.Count > 0 Then
            txtid.Text = dt.Rows(0)("id").ToString
            txtBarcode.Text = dt.Rows(0)("barcode").ToString
            txtTitleName.Text = dt.Rows(0)("title_name").ToString
            txtName.Text = dt.Rows(0)("first_name").ToString
            txtLastName.Text = dt.Rows(0)("surname").ToString
            txtNameEng.Text = dt.Rows(0)("customer_name_en").ToString
            txtCompany.Text = dt.Rows(0)("company_name").ToString
            txtPosition.Text = dt.Rows(0)("position_name").ToString
            txtAddress.Text = dt.Rows(0)("address").ToString
            txtpostcode.Text = dt.Rows(0)("postcode").ToString
            txtOwner.Text = dt.Rows(0)("Owner_name").ToString
            txtGroup.Text = dt.Rows(0)("group_name").ToString
            txtSubGroup.Text = dt.Rows(0)("sub_group").ToString
            txtTel.Text = dt.Rows(0)("tel_no").ToString
            txtMobileNo.Text = dt.Rows(0)("mobile_no").ToString
            txtEmail.Text = dt.Rows(0)("email").ToString
            txtref1.Text = dt.Rows(0)("ref1").ToString
            txtref2.Text = dt.Rows(0)("ref2").ToString
            ' txtTagNo.Text = dt.Rows(0)("tag_no").ToString
        End If
    End Sub



    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim frm As New frmSearchName
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim dt As New DataTable
            dt = Engine.PreRegister.GetRegisterDataByBarcode(frm.Barcode)
            FillData(dt)
            dt.Dispose()
        End If
    End Sub
End Class
