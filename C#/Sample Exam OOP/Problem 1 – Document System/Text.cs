using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_1___Document_System
{
    public class Text : Document, IEditable
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

        public Text(String name, String content) : base(name, content) { }

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
