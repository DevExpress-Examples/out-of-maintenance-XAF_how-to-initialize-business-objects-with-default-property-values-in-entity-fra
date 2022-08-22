Imports System
Imports System.Configuration
Imports System.Web
Imports DevExpress.ExpressApp.Web
Imports DevExpress.Web

Namespace InitializeObjects.Web

    Public Class [Global]
        Inherits HttpApplication

        Public Sub New()
            InitializeComponent()
        End Sub

        Protected Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
            AddHandler ASPxWebControl.CallbackError, New EventHandler(AddressOf Application_Error)
#If EASYTEST
            DevExpress.ExpressApp.Web.TestScripts.TestScriptsManager.EasyTestEnabled = true;
#End If
        End Sub

        Protected Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
            Call WebApplication.SetInstance(Session, New InitializeObjectsAspNetApplication())
            If ConfigurationManager.ConnectionStrings("ConnectionString") IsNot Nothing Then
                WebApplication.Instance.ConnectionString = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
            End If

#If EASYTEST
            if(ConfigurationManager.ConnectionStrings["EasyTestConnectionString"] != null) {
                WebApplication.Instance.ConnectionString = ConfigurationManager.ConnectionStrings["EasyTestConnectionString"].ConnectionString;
            }
#End If
            Call WebApplication.Instance.Setup()
            Call WebApplication.Instance.Start()
        End Sub

        Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Protected Sub Application_EndRequest(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Protected Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
            Call ErrorHandling.Instance.ProcessApplicationError()
        End Sub

        Protected Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
            WebApplication.LogOff(Session)
            WebApplication.DisposeInstance(Session)
        End Sub

        Protected Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

'#Region "Web Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
        End Sub
'#End Region
    End Class
End Namespace
