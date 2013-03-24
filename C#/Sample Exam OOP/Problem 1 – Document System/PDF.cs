using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_1___Document_System
{
    public class PDF : Binary, IEncryptable
    {

        private string numberOfPages;

        public string NumberOfPages
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

        public override string ToString()
        {
            bool isFirstProp = true;
            StringBuilder str = new StringBuilder();
            str.Append("PDFDocument[");

            if (this.IsEncrypted)
            {
                str.Append("encrypted");
            }
            else
            {
                AddPropToString(ref isFirstProp, str, "content", content);
                AddPropToString(ref isFirstProp, str, "name", name);
                AddPropToString(ref isFirstProp, str, "pages", numberOfPages);
                AddPropToString(ref isFirstProp, str, "size", SizeInBytes);
            }

            str.Append("]");
            return str.ToString();
        }
    }
}
