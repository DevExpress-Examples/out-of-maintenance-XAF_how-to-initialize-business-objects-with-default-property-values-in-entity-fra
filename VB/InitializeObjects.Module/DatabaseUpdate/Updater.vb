Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Persistent.BaseImpl.EF
Imports Solution1.Module.BusinessObjects

Namespace InitializeObjects.Module.DatabaseUpdate

    ' For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppUpdatingModuleUpdatertopic
    Public Class Updater
        Inherits ModuleUpdater

        Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
            MyBase.New(objectSpace, currentDBVersion)
        End Sub

        Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
            MyBase.UpdateDatabaseAfterUpdateSchema()
            Dim phone1 As PhoneNumber = ObjectSpace.FindObject(Of PhoneNumber)(CriteriaOperator.Parse("Number = '555-0101'"))
            If phone1 Is Nothing Then
                phone1 = ObjectSpace.CreateObject(Of PhoneNumber)()
                phone1.Number = "555-0101"
                phone1.PhoneType = "Home"
            End If

            Dim phone2 As PhoneNumber = ObjectSpace.FindObject(Of PhoneNumber)(CriteriaOperator.Parse("Number = '555-0102'"))
            If phone2 Is Nothing Then
                phone2 = ObjectSpace.CreateObject(Of PhoneNumber)()
                phone2.Number = "555-0102"
                phone2.PhoneType = "Work"
            End If

            Dim johnDoe As Contact = ObjectSpace.FindObject(Of Contact)(CriteriaOperator.Parse("FirstName = 'John' && LastName = 'Doe'"))
            If johnDoe Is Nothing Then
                johnDoe = ObjectSpace.CreateObject(Of Contact)()
                johnDoe.FirstName = "John"
                johnDoe.LastName = "Doe"
            End If

            ObjectSpace.CommitChanges()
        End Sub

        Public Overrides Sub UpdateDatabaseBeforeUpdateSchema()
            MyBase.UpdateDatabaseBeforeUpdateSchema()
        End Sub
    End Class
End Namespace
