using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_Bank
{
    public class Loan : Account
    {
        public Loan(Customer customer, decimal balance, decimal interestRate) 
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalcInterestAmount(int monthsCount)
        {
            decimal interest = 0;

            if (customer is Company)
            {
                if (monthsCount > 2)
                {
                    interest = (monthsCount - 2) * interestRate * balance;
                }
            }
            else if (customer is Individual)
            {
                if (monthsCount > 3)
                {
                    interest = (monthsCount - 3) * interestRate * balance;
                }
            }

            return interest;
        }
    }
}
