using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_Bank
{
    public abstract class Account : IDepositable
    {
        protected Customer customer;
        protected decimal balance;
        protected decimal interestRate;

        protected Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.customer = customer;
            this.balance = balance;
            this.interestRate = interestRate;
        }

        public virtual void DepositMoney(decimal amount)
        {
            balance += amount;
        }

        public abstract decimal CalcInterestAmount(int monthsCount);
    }
}
