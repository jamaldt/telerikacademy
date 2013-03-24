using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_1___Document_System
{
    public abstract class Document : IDocument
    {
        protected string name;
        protected string content;

        public string Name
        {
            get { return name; }
        }

        public string Content
        {
            get { return content; }
        }


        protected Document(string name, string content = "")
        {
            this.name = name;
            this.content = content;
        }


        public abstract void LoadProperty(string key, string value);

        public abstract void SaveAllProperties(IList<KeyValuePair<string, object>> output);

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
