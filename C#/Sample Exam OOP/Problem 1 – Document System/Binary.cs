using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_1___Document_System
{
    public abstract class Binary : Document
    {

        private int sizeInBytes;

        public int SizeInBytes
        {
            get { return sizeInBytes; }
            set { sizeInBytes = value; }
        }

        protected Binary(String name) : base(name) { }

    }
}
