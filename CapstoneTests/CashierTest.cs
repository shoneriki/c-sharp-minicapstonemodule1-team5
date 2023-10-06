using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;
using System;

namespace CapstoneTests
{
    [TestClass]
    public class CashierTests
    {
        [TestMethod]
        public void TakeMoneyHappyPathTest()
        {
            //arrange
            Cashier cashier = new Cashier();
            int moneyGiven = 10;
            decimal expectedOutcome = 10.0M;
            //act
            cashier.TakeMoney(moneyGiven);
            //assert
            Assert.AreEqual(expectedOutcome, cashier.Balance);

            //arrange1
            cashier = new Cashier();
            int moneyGiven1 = 0;
            //act1
            cashier.TakeMoney(moneyGiven1);
            //assert1
            Assert.AreEqual(0, cashier.Balance);


            //arrange2
            cashier = new Cashier();
            int moneyGiven2 = -5;
            //act2
            cashier.TakeMoney(moneyGiven2);
            //assert2
            Assert.AreEqual(0, cashier.Balance);
        }

        [TestMethod()]

        public void TransactionHappyPathTests()
        {
            //arrange
            Cashier cashier = new();
            // decimal price, string codeinput
            var vendingMachine = new VendingMachine();
            decimal inputPrice = .90M;
            string inputCodeInput = "A1";
            cashier.TakeMoney(10);
            //act
            cashier.Transaction(inputPrice, inputCodeInput);
            //assert
            Assert.AreEqual(9.10M, cashier.Balance);

            cashier = new();
            vendingMachine = new();
            inputPrice = 3.55M;
            inputCodeInput = "C4";
            cashier.TakeMoney(2);

            cashier.Transaction(inputPrice, inputCodeInput);

            Assert.AreEqual(2, cashier.Balance);
        }

        [TestMethod()]

        public void GetChangeHappyPath()
        {
            Cashier cashier = new();
            cashier.TakeMoney(10);
            decimal inputPrice = 3.55M;
            string inputCodeInput = "C4";

            cashier.Transaction(inputPrice, inputCodeInput);

            Assert.AreEqual("25 2 0",cashier.GetChange());

        }
    }
}
