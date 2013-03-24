using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_1___Document_System
{
    public class Word : OfficeDocument, IEditable
    {

        private string numberOfCharacters;

        public string NumberOfCharacters
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

        public override string ToString()
        {
            bool isFirstProp = true;
            StringBuilder str = new StringBuilder();
            str.Append("WordDocument[");

            if (this.IsEncrypted)
            {
                str.Append("encrypted");
            }
            else
            {
                AddPropToString(ref isFirstProp, str, "chars", numberOfCharacters);
                AddPropToString(ref isFirstProp, str, "content", content);
                AddPropToString(ref isFirstProp, str, "name", name);
                AddPropToString(ref isFirstProp, str, "size", SizeInBytes);
                AddPropToString(ref isFirstProp, str, "version", Version);
            }

            str.Append("]");
            return str.ToString();
        }
    }
}
