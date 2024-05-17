using BankLibrary;
using System.Security.Principal;
using Humanizer;

namespace MyBankingApp
{
    internal class Program
    {

        //Testowanie();
        static void Main(string[] args)
        {
            Console.WriteLine("Test Humanizer NuGet:");
            Console.WriteLine(2225.ToWords());
            Console.WriteLine();

            var account1 = new BankAccount("Wiktor", 5000);

            Console.WriteLine($"Konto {account1.Number} zostało utworzone dla {account1.Owner} z {account1.Balance} początkowym kapitałem.");

            account1.MakeWithdrawal(250, DateTime.Now, "Opłata za mieszkanie");

            Console.WriteLine($"Na koncie {account1.Owner} zostało {account1.Balance}");

            account1.MakeDeposit(100, DateTime.Now, "Artykuły spożywcze");

            Console.WriteLine($"A teraz zostało {account1.Balance}");


            void Testing()
            {
                try
                {
                    var invalidAccount = new BankAccount("invalid", -55);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Exception caught creating account with negative balance");
                    Console.WriteLine(e.ToString());
                }


                try
                {
                    account1.MakeWithdrawal(77750, DateTime.Now, "Attempt to overdraw");
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine("Exception caught trying to overdraw");
                    Console.WriteLine(e.ToString());
                }

            }

            Console.WriteLine();
            Console.WriteLine(account1.GetAccountHistory());


            var giftCard = new GiftCardAccount("Karta prezentowa", 100, 50);
            giftCard.MakeWithdrawal(20, DateTime.Now, "Bardzo droga kawa");
            giftCard.MakeWithdrawal(50, DateTime.Now, "Zakupy");
            giftCard.PerformMonthEndTransactions();
            giftCard.MakeDeposit(25, DateTime.Now, "Na dodatkowe wydatki :)");
            Console.WriteLine(giftCard.GetAccountHistory());

            Console.WriteLine();

            var savings = new InterestEarningAccount("Oszczędności", 10000);
            savings.MakeDeposit(750, DateTime.Now, "Dodatkowa kasa");
            savings.MakeWithdrawal(200, DateTime.Now, "Na rachunki");
            savings.PerformMonthEndTransactions();
            Console.WriteLine(savings.GetAccountHistory());

            Console.WriteLine();

            var kredytowka = new LineOfCreditAccount("Karta kredytowa", 0, 2000);
            kredytowka.MakeWithdrawal(1000m, DateTime.Now, "Na ważne sprawy");
            kredytowka.MakeDeposit(50m, DateTime.Now, "Mała spłata");
            kredytowka.MakeWithdrawal(5000m, DateTime.Now, "Awaryjna wypłata");
            kredytowka.MakeDeposit(200m, DateTime.Now, "Drobna spłata awarii");
            kredytowka.PerformMonthEndTransactions();
            Console.WriteLine(kredytowka.GetAccountHistory());
            
        }
    }
}