namespace ATM.Data.Migrations
{
    using ATM.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ATM.Data.ATMContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ATM.Data.ATMContext context)
        {
            this.SeedCardAccounts(context);
        }

        private void SeedCardAccounts(ATMContext context)
        {
            if (context.CardAccounts.Any())
            {
                return;
            }

            context.CardAccounts.Add(new CardAccount
            {
                CardNumber = "1234567890",
                CardPIN = "1234",
                CardCash = 20000
            });

            context.CardAccounts.Add(new CardAccount
            {
                CardNumber = "1234567891",
                CardPIN = "1235",
                CardCash = 4500
            });
        }
    }
}
