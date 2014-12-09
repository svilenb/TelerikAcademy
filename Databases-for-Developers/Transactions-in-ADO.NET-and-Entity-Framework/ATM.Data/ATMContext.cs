namespace ATM.Data
{
    using System.Data.Entity;

    using ATM.Model;
    using ATM.Data.Migrations;

    public class ATMContext : DbContext
    {
        public ATMContext()
            : base("ATMSystem")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ATMContext, Configuration>());
        }

        public DbSet<CardAccount> CardAccounts { get; set; }

        public DbSet<TransactionsHistory> TransactionsHistories { get; set; }
    }
}
