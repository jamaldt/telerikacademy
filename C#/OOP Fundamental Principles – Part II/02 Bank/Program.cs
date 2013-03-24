using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Account[] accounts = {
                new Loan(new Individual(), 1000, 10),
                new Loan(new Company(9001), 9000, 10),
                new Deposit(new Individual(), 3333, 3),
            };

            foreach (var account in accounts)
            {
                Console.WriteLine(account.CalcInterestAmount(12));
            }
        }
    }
}
