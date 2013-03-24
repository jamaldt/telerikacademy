using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_Bank
{
    public interface IDepositable
    {
        void DepositMoney(decimal amount);
    }
}
