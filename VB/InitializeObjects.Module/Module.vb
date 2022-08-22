Imports System
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Updating
Imports System.Data.Entity
Imports InitializeObjects.Module.BusinessObjects

Namespace InitializeObjects.Module

    ' For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppModuleBasetopic.
    Public NotInheritable Partial Class InitializeObjectsModule
        Inherits ModuleBase

        ' Uncomment this code to delete and recreate the database each time the data model has changed.
        ' Do not use this code in a production environment to avoid data loss.
#If DEBUG
        Shared Sub New()
            Call Database.SetInitializer(New DropCreateDatabaseIfModelChanges(Of InitializeObjectsDbContext)())
        End Sub

#End If
        Public Sub New()
            InitializeComponent()
        End Sub

        Public Overrides Function GetModuleUpdaters(ByVal objectSpace As IObjectSpace, ByVal versionFromDB As Version) As IEnumerable(Of ModuleUpdater)
            Dim updater As ModuleUpdater = New DatabaseUpdate.Updater(objectSpace, versionFromDB)
            Return New ModuleUpdater() {updater}
        End Function

        Public Overrides Sub Setup(ByVal application As XafApplication)
            MyBase.Setup(application)
        ' Manage various aspects of the application UI and behavior at the module level.
        End Sub
    End Class
End Namespace
