using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_1___Document_System
{
    public class TextDocument : Document, IEditable
    {

        private string charset;

        public string Charset
        {
            get { return charset; }
            set { charset = value; }
        }


        public void ChangeContent(string newContent)
        {
            content = newContent;
        }

        public TextDocument(String name) : base(name) { }

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
            str.Append("TextDocument[");

            AddPropToString(ref isFirstProp, str, "charset", charset);
            AddPropToString(ref isFirstProp, str, "content", content);
            AddPropToString(ref isFirstProp, str, "name", name);

            str.Append("]");
            return str.ToString();
        }
    }
}
