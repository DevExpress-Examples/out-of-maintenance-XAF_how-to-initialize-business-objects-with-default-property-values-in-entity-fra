using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.EF;
using DevExpress.Persistent.BaseImpl.EF;
using Solution1.Module.BusinessObjects;

namespace InitializeObjects.Module.DatabaseUpdate {
    // For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppUpdatingModuleUpdatertopic
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
        }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();

            PhoneNumber phone1 = ObjectSpace.FindObject<PhoneNumber>(CriteriaOperator.Parse("Number = '555-0101'"));
            if (phone1 == null) {
                phone1 = ObjectSpace.CreateObject<PhoneNumber>();
                phone1.Number = "555-0101";
                phone1.PhoneType = "Home";
            }
            PhoneNumber phone2 = ObjectSpace.FindObject<PhoneNumber>(CriteriaOperator.Parse("Number = '555-0102'"));
            if (phone2 == null) {
                phone2 = ObjectSpace.CreateObject<PhoneNumber>();
                phone2.Number = "555-0102";
                phone2.PhoneType = "Work";
            }
            Contact johnDoe = ObjectSpace.FindObject<Contact>(CriteriaOperator.Parse("FirstName = 'John' && LastName = 'Doe'"));
            if (johnDoe == null) {
                johnDoe = ObjectSpace.CreateObject<Contact>();
                johnDoe.FirstName = "John";
                johnDoe.LastName = "Doe";
            }
            ObjectSpace.CommitChanges();
        }
        public override void UpdateDatabaseBeforeUpdateSchema() {
            base.UpdateDatabaseBeforeUpdateSchema();
        }
    }
}
