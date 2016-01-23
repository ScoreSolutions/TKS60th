Imports Facebook
Public Class FacebookUtilities
    Public Shared Function GenerateLoginUrl(appId As String, extendedPermissions As String) As Uri
        Dim parameters As New Dictionary(Of String, Object)
        parameters("client_id") = appId
        parameters("redirect_uri") = "https://www.facebook.com/connect/login_success.html"
        parameters("response_type") = "token"
        parameters("display") = "popup"
        parameters("client_id") = appId
        If String.IsNullOrEmpty(extendedPermissions) = False Then
            parameters("scope") = extendedPermissions
        End If
        Dim fb = New FacebookClient()
        Return fb.GetLoginUrl(parameters)
    End Function

End Class
