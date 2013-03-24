using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_Bank
{
    public abstract class Customer
    {
        protected int id;
        protected int Id { get; set; }
        private static int count = 1000;

        protected Customer(int id)
        {
            this.id = id;
        }

        protected Customer()
        {
            this.id = ++count;
        }
    }
}
