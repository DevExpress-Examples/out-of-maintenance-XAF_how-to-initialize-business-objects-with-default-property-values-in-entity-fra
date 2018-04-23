Imports System
Imports System.Data
Imports System.Linq
Imports System.Data.Entity
Imports System.Data.Common
Imports System.Data.Entity.Core.Objects
Imports System.Data.Entity.Infrastructure
Imports System.ComponentModel
Imports DevExpress.ExpressApp.EF.Updating
Imports DevExpress.Persistent.BaseImpl.EF
Imports Solution1.Module.BusinessObjects

Namespace InitializeObjects.Module.BusinessObjects
    Public Class InitializeObjectsDbContext
        Inherits DbContext

        Public Sub New(ByVal connectionString As String)
            MyBase.New(connectionString)
        End Sub
        Public Sub New(ByVal connection As DbConnection)
            MyBase.New(connection, False)
        End Sub
        Public Property ModulesInfo() As DbSet(Of ModuleInfo)
        Public Property Contacts() As DbSet(Of Contact)
        Public Property Addresses() As DbSet(Of Address)
        Public Property Countries() As DbSet(Of Country)
        Public Property Parties() As DbSet(Of Party)
        Public Property PhoneNumbers() As DbSet(Of PhoneNumber)
    End Class
End Namespace