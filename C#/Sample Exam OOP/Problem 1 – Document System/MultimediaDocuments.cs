using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_1___Document_System
{
    public abstract class MultimediaDocuments : Binary
    {

        private string lengthInSeconds;

        public string LengthInSeconds
        {
            get { return lengthInSeconds; }
            set { lengthInSeconds = value; }
        }

        protected MultimediaDocuments(String name) : base(name) { }

    }
}
