using System;
using System.Data;
using System.Linq;
using System.Data.Entity;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.ComponentModel;
using DevExpress.ExpressApp.EF.Updating;
using DevExpress.Persistent.BaseImpl.EF;
using Solution1.Module.BusinessObjects;

namespace  InitializeObjects.Module.BusinessObjects {
	public class InitializeObjectsDbContext : DbContext {
		public InitializeObjectsDbContext(String connectionString)
			: base(connectionString) {
		}
		public InitializeObjectsDbContext(DbConnection connection)
			: base(connection, false) {
		}
		public DbSet<ModuleInfo> ModulesInfo { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
		public DbSet<Country> Countries { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
	}
}