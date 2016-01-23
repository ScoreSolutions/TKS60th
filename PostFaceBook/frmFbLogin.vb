Imports System.Configuration
Imports Facebook
Public Class frmFbLogin
    Private _IsAuthorized As Boolean
    Private _accessToken As String
    Private _CanClose As Boolean
    Public Property IsAuthorized() As Boolean
        Get
            Return _accessToken
        End Get
        Set(ByVal value As Boolean)
            _accessToken = value
        End Set
    End Property
    Public Property accessToken() As String
        Get
            Return _accessToken
        End Get
        Set(ByVal value As String)
            _accessToken = value
        End Set
    End Property
    Public Property CanClose() As Boolean
        Get
            Return _CanClose
        End Get
        Set(ByVal value As Boolean)
            _CanClose = value
        End Set
    End Property
    Private Sub frmFbLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim iniReader As New Org.Mentalis.Files.IniReader(Application.StartupPath & "\config.ini")
        Dim appId As String
        appId = iniReader.ReadString("Setting", "appId")

        Dim fbLoginUrl = FacebookUtilities.GenerateLoginUrl(appId, "manage_pages,publish_stream,read_stream")
        webBrowser1.Navigate(fbLoginUrl)
    End Sub

    Private Sub webBrowser1_Navigated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserNavigatedEventArgs) Handles webBrowser1.Navigated
        Dim fb As New FacebookClient()
        Dim oauthResult As FacebookOAuthResult = Nothing
        If fb.TryParseOAuthCallbackUrl(e.Url, oauthResult) Then
            If oauthResult.IsSuccess Then
                IsAuthorized = True
                accessToken = oauthResult.AccessToken
                Me.CanClose = True
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                Dim errorDescription As String = oauthResult.ErrorDescription
                Dim errorReason As String = oauthResult.ErrorReason
                MessageBox.Show(errorDescription + ";" + errorReason)
            End If
        End If

    End Sub

    Private Sub frmFbLogin_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If CanClose = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.CanClose = True
        Application.Exit()
    End Sub
End Class