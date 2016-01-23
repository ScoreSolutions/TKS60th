Imports Engine
Imports System.IO
Imports ReaderModule
Imports System.Drawing.Imaging

Public Class frmMain


    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Timer2.Interval = 100
        Timer2.Start()

        Dim FormWidth As Integer = 800 'Screen.PrimaryScreen.Bounds.Width
        Dim FormHeight As Integer = 1280 'Screen.PrimaryScreen.Bounds.Height
        Me.Size = New Size(FormWidth, FormHeight)
        Me.Location = New Point(0, 0)

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

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        If txtTagNo.Text <> "" Then
            Exit Sub
        End If
        Try
            txtTagNo.Text = ReadWriteIOEng.ReadTag(2, 4)
            txtTagNo.Text = Replace(txtTagNo.Text.Trim, "-", "")

            If txtTagNo.Text <> "" Then
                ReadWriteIOEng.BeefON()
                System.Threading.Thread.Sleep(300)
                ReadWriteIOEng.BeefOFF()
            End If
        Catch ex As Exception
            MessageBox.Show(ReadWriteIOEng.ErrorMessage)
        End Try

        Try
            ' txtTagNo.Text = "2015022016275700"
            If txtTagNo.Text <> "" Then
                ShowImage(txtTagNo.Text)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Function UpdateCurrentLocation() As Boolean
        Dim ret As Boolean = False
        ret = Engine.ChooseImage.UpdateCurrentLocation("Engine.ChooseImage.UpdateCurrentLocation", txtTagNo.Text)
        If ret = False Then
            Return False
        End If
        Return True
    End Function

    Sub ShowImage(tag_no As String)
        Dim ret As Boolean = False
        ret = UpdateCurrentLocation()
        If ret = False Then
            MessageBox.Show("Can't Update Current Location.")
            txtTagNo.Text = ""
            Exit Sub
        End If

        Dim name As String
        name = Engine.ChooseImage.GetNameByTagNo(tag_no)
        lblName.Text = name


        Dim countrow As Integer = 0
        Dim iHor, iVer As Int64
        iHor = 350
        iVer = 170

        Dim btnX As Integer = pnlMain.AutoScrollPosition.X
        Dim btnY As Integer = pnlMain.AutoScrollPosition.Y

        Dim ini As New Org.Mentalis.Files.IniReader(Application.StartupPath & "\config.ini")
        ini.Section = "ReaderSetting"
        Dim path As String = ini.ReadString("path")
        Dim strFileSize As String = ""

        If Directory.Exists(path & tag_no & "\Resize\") = False Then
            MessageBox.Show("ไม่พบไฟล์รูปภาพ")
            Exit Sub
        End If
        Dim di As New IO.DirectoryInfo(path & tag_no & "\Resize\")
        Dim aryFi As IO.FileInfo() = di.GetFiles("*.*")

        If aryFi.Length = 0 Then
            MessageBox.Show("ไม่พบไฟล์รูปภาพ")
            Exit Sub
        End If

        Dim fi As IO.FileInfo
        Dim cnt As Integer = 0
        For Each fi In aryFi

            If fi.Extension.ToLower = ".jpg" Then
                Dim mycallback As New Image.GetThumbnailImageAbort(AddressOf tnCallback)
                'Dim myimage As Bitmap = _
                'CType(Drawing.Image.FromFile(fi.FullName, True), Bitmap)
                'Dim img As Image = myimage.GetThumbnailImage(40, 40, mycallback, IntPtr.Zero)

                Dim stream1 As FileStream = File.OpenRead(fi.FullName)
                Dim img1 As Image = Image.FromStream(stream1, False, False)
                Dim imgname As String = fi.Name

                'Dim mybytearray As Byte() = DirectCast(dt.Rows(cnt)("image_file"), Byte())
                'Dim myimage As Image
                'Dim ms As System.IO.MemoryStream = New System.IO.MemoryStream(mybytearray)
                'myimage = System.Drawing.Image.FromStream(ms)

                Dim PicBox As New PictureBox
                With PicBox
                    .Image = img1
                    .Width = 300
                    .Height = 300
                    .SizeMode = PictureBoxSizeMode.StretchImage
                    .BorderStyle = BorderStyle.FixedSingle
                    '.Image = myimage
                    .Name = imgname
                    If cnt Mod 2 = 0 Then
                        .Location = New Point(btnX + 20, (btnY + (iVer * cnt)) + 20)
                    Else
                        .Location = New Point(btnX + iHor, (btnY + (iVer * cnt) - iVer) + 20)
                    End If
                    .Cursor = Cursors.Hand
                    AddHandler PicBox.Click, AddressOf PicBox_Click
                End With

                pnlMain.Controls.Add(PicBox)

            End If
            cnt += 1
        Next

        Application.DoEvents()

        pnlMain.AutoScroll = True

    End Sub

    Public Function tnCallback() As Boolean
        Return False
    End Function

    Private Sub PicBox_Click(sender As Object, e As EventArgs)
        Dim pb As PictureBox = DirectCast(sender, System.Windows.Forms.PictureBox)
        Dim frm As New frmDisplayImage
        frm.Image = pb.Image
        frm.Tag_no = txtTagNo.Text
        frm.image_id = pb.Name
        frm.Show()
        Timer2.Start()
    End Sub

    Private Sub pbClose_Click(sender As Object, e As EventArgs) Handles pbClose.Click
        Application.Exit()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        pnlMain.Controls.Clear()
        txtTagNo.Text = ""
        lblName.Text = ""
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles pbClear.Click
        pnlMain.Controls.Clear()
        txtTagNo.Text = ""
        lblName.Text = ""
    End Sub
End Class
