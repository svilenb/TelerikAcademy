namespace ATM.ConsoleClient
{
    using System;
    using System.Linq;
    using System.Transactions;

    using ATM.Data;
    using ATM.Model;

    class ATMSystemTester
    {
        static void Main(string[] args)
        {
            ShowCardAccounts();

            decimal amount = 200;
            string cardNumber = "1234567890";
            if (RetrieveMoney("1234", cardNumber, amount))
            {
                Console.WriteLine("Retrieved {0} from {1}", amount, cardNumber);
            }
            else
            {
                Console.WriteLine("Money couldn't be retrieved}");
            }

            ShowCardAccounts();
        }

        private static void ShowCardAccounts()
        {
            using (ATMContext db = new ATMContext())
            {
                foreach (var account in db.CardAccounts)
                {
                    Console.WriteLine("Id: {0}- Cash: {1}", account.Id, account.CardCash);
                }
            }
        }

        public static bool RetrieveMoney(string CardPIN, string cardNumber, decimal moneyToWithdraw)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.RepeatableRead
                }))
            {
                using (ATMContext db = new ATMContext())
                {
                    var card = db.CardAccounts
                        .Where(c => c.CardNumber == cardNumber).First();

                    bool success = true;
                    if (card == null || card.CardPIN != CardPIN || card.CardCash < moneyToWithdraw)
                    {
                        success = false;
                    }
                    else
                    {
                        card.CardCash -= moneyToWithdraw;
                    }

                    if (success)
                    {
                        RecordWithdrawal(cardNumber, moneyToWithdraw);
                        db.SaveChanges();
                        scope.Complete();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static void RecordWithdrawal(string cardNumber, decimal ammount)
        {
            using (var scope = new TransactionScope(
                  TransactionScopeOption.RequiresNew,
                  new TransactionOptions()
                  {
                      IsolationLevel = IsolationLevel.RepeatableRead
                  }))
            {
                using (ATMContext db = new ATMContext())
                {

                    db.TransactionsHistories.Add(new TransactionsHistory()
                    {
                        TransactionDate = DateTime.Now,
                        Ammount = ammount,
                        CardNumber = cardNumber
                    });

                    db.SaveChanges();
                    scope.Complete();
                }
            }
        }
    }
}
