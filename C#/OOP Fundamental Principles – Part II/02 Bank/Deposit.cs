using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_Bank
{
    public class Deposit : Account
    {
        public Deposit(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }
        
        public void WithdrawMoney(int amount)
        {
            balance -= amount;
        }

        public override decimal CalcInterestAmount(int monthsCount)
        {
            decimal interest = 0;

            if (!(balance >= 0 && balance < 1000))
            {
                interest = monthsCount * interestRate * balance;
            }

            return interest;
        }
    }
}
