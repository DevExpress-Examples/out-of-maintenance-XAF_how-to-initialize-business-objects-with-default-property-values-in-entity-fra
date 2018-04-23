using System;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Data.Filtering;


namespace Solution1.Module.BusinessObjects {
    [DefaultClassOptions]
    public class Contact : Person, IXafEntityObject, IObjectSpaceLink {
        public virtual Contact Manager { get; set; }
        public TitleOfCourtesy TitleOfCourtesy { get; set; }
        #region IXafEntityObject members
        void IXafEntityObject.OnCreated() {
            FirstName = "Sam";
            TitleOfCourtesy = TitleOfCourtesy.Mr;

            Address1 = objectSpace.CreateObject<Address>();
            Address1.Country = objectSpace.FindObject<Country>(CriteriaOperator.Parse("Name = 'USA'"));
            if (Address1.Country == null) {
                Address1.Country = objectSpace.CreateObject<Country>();
                Address1.Country.Name = "USA";
            }
            Manager = objectSpace.FindObject<Contact>(CriteriaOperator.Parse("FirstName = 'John' && LastName = 'Doe'"));
            PhoneNumber phone1 = objectSpace.FindObject<PhoneNumber>(CriteriaOperator.Parse("Number = '555-0101'"));
            PhoneNumber phone2 = objectSpace.FindObject<PhoneNumber>(CriteriaOperator.Parse("Number = '555-0102'"));
            PhoneNumbers.Add(phone1);
            PhoneNumbers.Add(phone2);
        }
        void IXafEntityObject.OnLoaded() { }
        void IXafEntityObject.OnSaving() { }
        #endregion
        #region IObjectSpaceLink members
        private IObjectSpace objectSpace;
        IObjectSpace IObjectSpaceLink.ObjectSpace {
            get { return objectSpace; }
            set { objectSpace = value; }
        }
        #endregion
    }
    public enum TitleOfCourtesy { Dr, Miss, Mr, Mrs, Ms };
}
