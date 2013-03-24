using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_Bank
{
    public class Mortage : Account
    {
        public Mortage(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalcInterestAmount(int monthsCount)
        {
            decimal interest = 0;

            if (customer is Company)
            {
                if (monthsCount > 12)
                {
                    interest = (monthsCount - 12) * interestRate * balance;
                    interest = 12 * (interestRate / 2) * balance;
                }
                else
                {
                    interest = monthsCount * interestRate * balance;
                }
            }
            else if (customer is Individual)
            {
                if (monthsCount > 6)
                {
                    interest = (monthsCount - 6) * interestRate * balance;
                }
            }

            return interest;
        }
    }
}
