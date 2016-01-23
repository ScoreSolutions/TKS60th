Imports System
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Engine
Imports System.IO

Public Class frmDisplayImage

#Region "Property"
    Dim _tag_no As String
    Dim _image_id As String
    WriteOnly Property Tag_no As String
        Set(value As String)
            _tag_no = value
        End Set
    End Property

    WriteOnly Property image_id As String
        Set(value As String)
            _image_id = value
        End Set
    End Property

    WriteOnly Property Image As Image
        Set(value As Image)
            Me.pbDisplay.BackgroundImage = value
            'Me.FormBorderStyle = FormBorderStyle.None
            'Me.BackgroundImageLayout = ImageLayout.Stretch
            Me.Opacity = 0.3

            'Dim rect As Rectangle = Me.ClientRectangle
            'rect.Inflate(-5, -5)
            'Me.Region = RoundedRectangleRegion(rect, 30)
        End Set
    End Property
#End Region

    Private Sub frmDisplayImage_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim FormWidth As Integer = 800
        Dim FormHeight As Integer = 1280
        Me.Size = New Size(FormWidth, FormHeight)
        Me.Location = New Point(0, 0)
    End Sub

    Private Sub frmDisplayImage_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Timer1.Interval = 100
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If (Me.Opacity < 1) Then
            Me.Opacity += 0.12
        Else
            Timer1.Stop()
        End If
    End Sub


    Private Function RoundedRectangleRegion(ByVal rect As Rectangle, ByVal radius As Integer) As Drawing.Region
        Dim path As New Drawing2D.GraphicsPath
        'top left corner:
        path.AddArc(rect.Left, rect.Top, radius * 2, radius * 2, 180, 90)
        'top edge:
        path.AddLine(rect.Left + radius, rect.Top, rect.Right - radius, rect.Top)
        'top right corner:
        path.AddArc(rect.Right - radius * 2, rect.Top, radius * 2, radius * 2, 270, 90)
        'right edge:
        path.AddLine(rect.Right, rect.Top + radius, rect.Right, rect.Bottom - radius)
        'bottom right corner:
        path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90)
        'bottom edge:
        path.AddLine(rect.Left + radius, rect.Bottom, rect.Right - radius, rect.Bottom)
        'bottom left corner:
        path.AddArc(rect.Left, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90)
        'left edge:
        path.AddLine(rect.Left, rect.Top + radius, rect.Left, rect.Bottom - radius)
        Return New Region(path)
    End Function

    Private Sub pbPostFacebook_Click(sender As Object, e As EventArgs) Handles pbPostFacebook.Click

        Dim ret As Boolean = True
        Dim imageByte() As Byte = ImageToByteArraybyMemoryStream(pbDisplay.BackgroundImage)
        ret = MapTagPhotoENG.SaveTakePhoto(_tag_no, imageByte, "jpg")
        ' ret = Engine.ChooseImage.UpdateSelectedStatus("Engine.ChooseImage.UpdateSelectedStatus", _tag_no, _image_id)
        If ret Then
            Me.Close()

            With frmMain
                .pnlMain.Controls.Clear()
                .txtTagNo.Text = ""
                .lblName.Text = ""
                .Timer2.Start()
            End With
        Else
            MessageBox.Show("Choose Image Failed.")
        End If
    End Sub

    Private Sub pbClose_Click(sender As Object, e As EventArgs) Handles pbClose.Click
        Me.Close()
    End Sub

    Private Shared Function ImageToByteArraybyMemoryStream(ByVal image As Image) As Byte()
        Dim ms As MemoryStream = New MemoryStream
        image.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
        Return ms.ToArray
    End Function

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim ret As Boolean = True
        Dim imageByte() As Byte = ImageToByteArraybyMemoryStream(pbDisplay.BackgroundImage)
        ret = MapTagPhotoENG.SaveTakePhoto(_tag_no, imageByte, "jpg")                     

        'ret = Engine.ChooseImage.UpdateSelectedStatus("Engine.ChooseImage.UpdateSelectedStatus", _tag_no, _image_id)
        If ret Then
            Me.Close()

            With frmMain
                .pnlMain.Controls.Clear()
                .txtTagNo.Text = ""
                .lblName.Text = ""
                .Timer2.Start()
            End With
        Else
            MessageBox.Show("Choose Image Failed.")
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub
End Class