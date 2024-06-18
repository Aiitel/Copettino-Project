﻿Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.Owin.Security
Imports Microsoft.AspNet.Identity

' È possibile aggiungere dati del profilo specificando altre proprietà per la classe utente. Per altre informazioni, vedere https://go.microsoft.com/fwlink/?LinkID=317594.
Public Class ApplicationUser
    Inherits IdentityUser

End Class

Public Class ApplicationDbContext
    Inherits IdentityDbContext(Of ApplicationUser)
    Public Sub New()
        MyBase.New("DefaultConnection")
    End Sub
End Class

#Region "Helpers"
Public Class UserManager
    Inherits UserManager(Of ApplicationUser)
    Public Sub New()
        MyBase.New(New UserStore(Of ApplicationUser)(New ApplicationDbContext()))
    End Sub
End Class
Public Class IdentityHelper
    'Utilizzati per XSRF durante il collegamento degli account di accesso esterni
    Public Const XsrfKey As String = "xsrfKey"

    Public Shared Sub SignIn(manager As UserManager, user As ApplicationUser, isPersistent As Boolean)
        Dim authenticationManager As IAuthenticationManager = HttpContext.Current.GetOwinContext().Authentication
        authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie)
        Dim identity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie)
        authenticationManager.SignIn(New AuthenticationProperties() With {.IsPersistent = isPersistent}, identity)
    End Sub

    Public Const ProviderNameKey As String = "providerName"
    Public Shared Function GetProviderNameFromRequest(request As HttpRequest) As String
        Return request(ProviderNameKey)
    End Function

    Private Shared Function IsLocalUrl(url As String) As Boolean
        Return Not String.IsNullOrEmpty(url) AndAlso ((url(0) = "/"c AndAlso (url.Length = 1 OrElse (url(1) <> "/"c AndAlso url(1) <> "\"c))) OrElse (url.Length > 1 AndAlso url(0) = "~"c AndAlso url(1) = "/"c))
    End Function

    Public Shared Sub RedirectToReturnUrl(returnUrl As String, response As HttpResponse)
        If Not [String].IsNullOrEmpty(returnUrl) AndAlso IsLocalUrl(returnUrl) Then
            response.Redirect(returnUrl)
        Else
            response.Redirect("~/")
        End If
    End Sub
End Class
#End Region