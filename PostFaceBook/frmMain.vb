Imports Facebook
Imports System.IO
Imports System.Drawing.Imaging
Imports Newtonsoft.Json.Linq
Imports System.Configuration

Public Class frmMain


    Private _accessToken As String
    Public Property accessToken() As String
        Get
            Return _accessToken
        End Get
        Set(ByVal value As String)
            _accessToken = value
        End Set
    End Property
    Public Sub New()
        Dim frm As New frmFbLogin
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            accessToken = frm.accessToken
        End If
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Interval = 30000
        Timer1.Start()

        Try
            Dim t As New System.Threading.Thread(AddressOf PostImageToFB)
            t.Start()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False

        Dim IsFinish As Boolean = False
        Do While IsFinish = False
            PostImageToFB()

            Application.DoEvents()
            IsFinish = True
        Loop
        Timer1.Enabled = True
    End Sub

#Region "FaceBook"

    'Private Sub PostImageToFB()
    '    Try


    '        Dim path As String = "D:/x.jpg" 'dt.Rows(i)("image_file").ToString
    '        Dim buffer As Byte() = File.ReadAllBytes(path)
    '        Dim ms As New MemoryStream(buffer)

    '        Dim id As String = "1" 'dt.Rows(i)("id").ToString
    '        Dim FileByte() As Byte
    '        FileByte = buffer 'DirectCast(dt.Rows(i)("image_file"), Byte())
    '        Dim mediaObject As New FacebookMediaObject()
    '        mediaObject.ContentType = "image/jpeg"
    '        mediaObject.FileName = id & ".jpg"
    '        mediaObject.SetValue(FileByte)
    '        FileByte = Nothing

    '        Dim fbParams As New Dictionary(Of String, Object)
    '        fbParams("req_perms") = "publish_stream"
    '        fbParams("scope") = "publish_stream"
    '        fbParams("source") = mediaObject
    '        Dim fbClient As New FacebookClient(GetPageAccessToken(Me.accessToken))
    '        fbClient.PostAsync("/" + ConfigurationManager.AppSettings("pageId") + "/photos", fbParams)


    '    Catch ex As Exception
    '    End Try

    'End Sub

    Private Sub PostImageToFB()
        Try

            Dim dt As New DataTable
            dt = Engine.ChooseImage.GetImageByForPostFB()
            If dt.Rows.Count > 0 Then

                For i As Integer = 0 To dt.Rows.Count - 1
                    Try
                        Dim id As String = dt.Rows(i)("id").ToString
                        If Convert.IsDBNull(dt.Rows(i)("image_file")) = True Then
                            Continue For
                        End If

                        Dim myBytes() As Byte
                        myBytes = DirectCast(dt.Rows(i)("image_file"), Byte())

                        Dim ResizePercent As Integer = 80
                        Dim myMemStream As System.IO.MemoryStream = New System.IO.MemoryStream(myBytes)
                        Dim fullsizeImage As System.Drawing.Image = System.Drawing.Image.FromStream(myMemStream)

                        Dim newWidth As Integer = fullsizeImage.Width * (ResizePercent / 100)
                        Dim newHeight As Integer = fullsizeImage.Height * (ResizePercent / 100)
                        Dim newImage As System.Drawing.Image = fullsizeImage.GetThumbnailImage(newWidth, newHeight, Nothing, IntPtr.Zero)
                        


                        Dim myResult As System.IO.MemoryStream = New System.IO.MemoryStream
                        newImage.Save(myResult, System.Drawing.Imaging.ImageFormat.Jpeg)
               
                        Dim mediaObject As New FacebookMediaObject()
                        mediaObject.ContentType = "image/jpeg"
                        mediaObject.FileName = id & ".jpg"
                        mediaObject.SetValue(myResult.ToArray)
                        myResult = Nothing

                        Dim fbParams As New Dictionary(Of String, Object)
                        fbParams("req_perms") = "publish_stream"
                        fbParams("scope") = "publish_stream"
                        fbParams("source") = mediaObject
                        Dim fbClient As New FacebookClient(GetPageAccessToken(Me.accessToken))
                        fbClient.PostAsync("/" + ConfigurationManager.AppSettings("pageId") + "/photos", fbParams)

                        Dim tag_no As String = dt.Rows(i)("tag_no").ToString
                        Dim image_id As String = dt.Rows(i)("id").ToString
                        Engine.ChooseImage.UpdateStatusPostFB("Engine.ChooseImage.UpdateStatusPostFB", tag_no, image_id)
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString)
                    End Try

                Next

            End If
        Catch ex As Exception
        End Try

    End Sub

    Public Shared Function GetPageAccessToken(ByVal userAccessToken As String) As String
        Try
            Dim iniReader As New Org.Mentalis.Files.IniReader(Application.StartupPath & "\config.ini")
            Dim appId, pageId As String
            appId = iniReader.ReadString("Setting", "appId")
            pageId = iniReader.ReadString("Setting", "pageId")

            Dim fbClient As New FacebookClient(userAccessToken)
            fbClient.AppId = appId
            Dim fbParams As New Dictionary(Of String, Object)
            Dim publishedResponse As JsonObject = DirectCast(fbClient.Get("/me/accounts", fbParams), JsonObject)
            Dim data As JArray = JArray.Parse(publishedResponse("data").ToString())
            For Each account In data
                If (account("id") = pageId) Then
                    Return account("access_token")
                End If
            Next
        Catch ex As Exception

        End Try

        Return String.Empty
    End Function

    'Private Sub PostImageToFB()
    '    Try

    '        Dim _tempByte() As Byte = Nothing
    '        Dim ImageFilePath = "D:\Images\20141112_201937.jpg"
    '        Dim _FStream As New IO.FileStream(ImageFilePath, IO.FileMode.Open, IO.FileAccess.Read)
    '        Dim _fileInfo As New IO.FileInfo(ImageFilePath)
    '        Dim _NumBytes As Long = _fileInfo.Length
    '        Dim _BinaryReader As New IO.BinaryReader(_FStream)
    '        _tempByte = _BinaryReader.ReadBytes(Convert.ToInt32(_NumBytes))


    '        Dim ResizePercent As Integer = 30
    '        Dim myMemStream As System.IO.MemoryStream = New System.IO.MemoryStream(_tempByte)
    '        Dim fullsizeImage As System.Drawing.Image = System.Drawing.Image.FromStream(myMemStream)
    '        Dim newWidth As Integer = fullsizeImage.Width * (ResizePercent / 100)
    '        Dim newHeight As Integer = fullsizeImage.Height * (ResizePercent / 100)
    '        Dim newImage As System.Drawing.Image = fullsizeImage.GetThumbnailImage(newWidth, newHeight, Nothing, IntPtr.Zero)
    '        Dim myResult As System.IO.MemoryStream = New System.IO.MemoryStream
    '        newImage.Save(myResult, System.Drawing.Imaging.ImageFormat.Jpeg)


    '        Dim mediaObject As New FacebookMediaObject()
    '        mediaObject.ContentType = "image/jpeg"
    '        mediaObject.FileName = "1.jpg"
    '        mediaObject.SetValue(myResult.ToArray)
    '        myResult = Nothing

    '        Dim fbParams As New Dictionary(Of String, Object)
    '        fbParams("req_perms") = "publish_stream"
    '        fbParams("scope") = "publish_stream"
    '        fbParams("source") = mediaObject
    '        Dim fbClient As New FacebookClient(GetPageAccessToken(Me.accessToken))
    '        'AddHandler fbClient.PostCompleted, AddressOf PostCompleted
    '        fbClient.PostAsync("/" + ConfigurationManager.AppSettings("pageId") + "/photos", fbParams)


    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString)
    '    End Try



    'End Sub
    'Public Sub PostCompleted(ByVal sender As Object, ByVal e As Facebook.FacebookApiEventArgs)

    '    If e.Error Is Nothing Then
    '        'ShowMessageBoxFromMainThread("Post เรียบร้อย", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    Else
    '        MessageBox.Show(e.Error.Message)
    '        'ShowMessageBoxFromMainThread(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End If
    'End Sub
#End Region



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PostImageToFB()
    End Sub
End Class
