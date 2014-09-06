namespace Atm.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Atm.Models;
    using Atm.Data.Migrations;

    public class AtmEntities : DbContext
    {
        public AtmEntities()
            : base("name=AtmEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AtmEntities, Configuration>());
        }

        public virtual IDbSet<CardHolder> Accounts { get; set; }

        public virtual IDbSet<CardAccount> CardAccounts { get; set; }
    }
}