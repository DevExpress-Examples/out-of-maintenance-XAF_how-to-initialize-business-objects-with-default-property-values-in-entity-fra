Imports System
Imports System.Linq
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations.Schema
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl.EF
Imports DevExpress.Data.Filtering


Namespace Solution1.Module.BusinessObjects
    <DefaultClassOptions> _
    Public Class Contact
        Inherits Person
        Implements IXafEntityObject, IObjectSpaceLink

        Public Overridable Property Manager() As Contact
        Public Property TitleOfCourtesy() As TitleOfCourtesy
        #Region "IXafEntityObject members"
        Private Sub IXafEntityObject_OnCreated() Implements IXafEntityObject.OnCreated
            FirstName = "Sam"
            TitleOfCourtesy = TitleOfCourtesy.Mr

            Address1 = objectSpace_Renamed.CreateObject(Of Address)()
            Address1.Country = objectSpace_Renamed.FindObject(Of Country)(CriteriaOperator.Parse("Name = 'USA'"))
            If Address1.Country Is Nothing Then
                Address1.Country = objectSpace_Renamed.CreateObject(Of Country)()
                Address1.Country.Name = "USA"
            End If
            Manager = objectSpace_Renamed.FindObject(Of Contact)(CriteriaOperator.Parse("FirstName = 'John' && LastName = 'Doe'"))
            Dim phone1 As PhoneNumber = objectSpace_Renamed.FindObject(Of PhoneNumber)(CriteriaOperator.Parse("Number = '555-0101'"))
            Dim phone2 As PhoneNumber = objectSpace_Renamed.FindObject(Of PhoneNumber)(CriteriaOperator.Parse("Number = '555-0102'"))
            PhoneNumbers.Add(phone1)
            PhoneNumbers.Add(phone2)
        End Sub
        Private Sub IXafEntityObject_OnLoaded() Implements IXafEntityObject.OnLoaded
        End Sub
        Private Sub IXafEntityObject_OnSaving() Implements IXafEntityObject.OnSaving
        End Sub
        #End Region
        #Region "IObjectSpaceLink members"

        Private objectSpace_Renamed As IObjectSpace
        Private Property IObjectSpaceLink_ObjectSpace() As IObjectSpace Implements IObjectSpaceLink.ObjectSpace
            Get
                Return objectSpace_Renamed
            End Get
            Set(ByVal value As IObjectSpace)
                objectSpace_Renamed = value
            End Set
        End Property
        #End Region
    End Class
    Public Enum TitleOfCourtesy
        Dr
        Miss
        Mr
        Mrs
        Ms
    End Enum
End Namespace
