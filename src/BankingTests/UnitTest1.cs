using BankLibrary;

namespace BankingTests
{
    public class Basic
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        [Fact]
        public void OverwithdrawTest()
        {
            var account = new BankAccount("Kendra", 100);

            //Test for a negative balance

            Assert.Throws<InvalidOperationException>(

                () => account.MakeWithdrawal(300, DateTime.Now, "Attempt to overwithdraw")
            );
        }

        [Fact]
        public void CreatingAccountWithNegativeBalance()
        {
            Assert.Throws<ArgumentOutOfRangeException>(

                () => new BankAccount("invalid", -55)
                );
        }




    }
}