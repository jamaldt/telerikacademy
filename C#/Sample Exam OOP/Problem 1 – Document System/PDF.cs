using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_1___Document_System
{
    public class PDF : Binary, IEncryptable
    {

        private int numberOfPages;

        public int NumberOfPages
        {
            get { return numberOfPages; }
            set { numberOfPages = value; }
        }


        public PDF(String name) : base(name) { }

        private bool isEncrypted;

        public bool IsEncrypted
        {
            get { return isEncrypted; }
        }

        public void Encrypt()
        {
            isEncrypted = true;
        }

        public void Decrypt()
        {
            isEncrypted = false;
        }

        public override void LoadProperty(string key, string value)
        {
            throw new NotImplementedException();
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            throw new NotImplementedException();
        }
    }
}
