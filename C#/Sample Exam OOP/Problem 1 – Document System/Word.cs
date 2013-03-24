using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_1___Document_System
{
    public class Word : OfficeDocument, IEditable
    {

        private int numberOfCharacters;

        public int NumberOfCharacters
        {
            get { return numberOfCharacters; }
            set { numberOfCharacters = value; }
        }

        public Word(String name) : base(name) { }

        public void ChangeContent(string newContent)
        {
            content = newContent;
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
