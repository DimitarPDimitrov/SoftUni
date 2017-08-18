using NUnit.Framework;
using System;
using QA01Homework;


namespace HomeworkTests
{
    [TestFixture]
    public class BankAcountShould
    {
        //2. BankAccount
        [Test]
        public void InitializeAcountWithNegaiveValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new BankAcount(-1m));
        }

        [Test]
        public void WithdrawAcountLessThan1000_GetRightAmount()
        {
            BankAcount acount = new BankAcount(3000m);
            acount.Withdraw(500m);

            Assert.AreEqual(2475m, acount.Amount);
        }

        [Test]
        public void WithdrawAcountMoreThan1000_GetRightAmount()
        {
            BankAcount acount = new BankAcount(3000m);
            acount.Withdraw(1500m);

            Assert.AreEqual(1470m, acount.Amount);
        }

        //3. Asserts 5 more tests____________________________________

        [Test]
        public void InitializeAcount_WhenObjectIsConstructed()
        {
            BankAcount acount = new BankAcount(1000m);

            Assert.IsNotNull(acount.Amount);
        }

        [Test]
        public void InitializeAcountWithDecimalMaxValue()
        {
            BankAcount acount = new BankAcount(Decimal.MaxValue);

            Assert.AreEqual(Decimal.MaxValue, acount.Amount);
        }

        [Test]
        public void InitializeAcountWithDecimalMaxValuePlusOne_ThrowsOverflowException()
        {
            BankAcount account = new BankAcount(Decimal.MaxValue);
            
            Assert.Throws<OverflowException>(() => account.Deposit(1m));
        }

        [Test]
        public void DepositAcountWithPositiveValue_GetRightAmount()
        {
            BankAcount acount = new BankAcount(3000m);
            acount.Deposit(200m);

            Assert.AreEqual(3200, acount.Amount);
        }

        [Test]
        public void DepositAcountWithNegativeValue_ThrowsArgumentException()
        {
            BankAcount acount = new BankAcount(3000m);

            Assert.Throws<ArgumentException>(() => acount.Deposit(-2000m));
        }

        [Test]
        public void WithdrawAcountWithMoreThatAreInAcount_ThrowsArgumentException()
        {
            BankAcount acount = new BankAcount(1000m);

            Assert.Throws<ArgumentException>(() => acount.Withdraw(2000m));
        }
    }
}
