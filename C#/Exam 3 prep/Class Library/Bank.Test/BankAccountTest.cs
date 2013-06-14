using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace Bank.Test
{
    [TestClass]
    public class BankAccountTest
    {
        [TestMethod]
        public void DebitTest()
        {
            BankAccount target = new BankAccount("Mr. Bryan Walton", 11.99);
            double amount = 11.22;
            target.Debit(amount);
            Assert.AreEqual((System.Convert.ToDouble(0.77)), target.Balance, 0.05);
        }
    }
}
