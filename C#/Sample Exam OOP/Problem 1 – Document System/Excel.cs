using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_1___Document_System
{
    public class Excel : OfficeDocument
    {

        private string rows;

        public string Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        private string cols;

        public string Cols
        {
            get { return cols; }
            set { cols = value; }
        }

        public Excel(String name) : base(name) { }

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
            str.Append("ExcelDocument[");

            if (this.IsEncrypted)
            {
                str.Append("encrypted");
            }
            else
            {
                AddPropToString(ref isFirstProp, str, "cols", cols);
                AddPropToString(ref isFirstProp, str, "content", content);
                AddPropToString(ref isFirstProp, str, "name", name);
                AddPropToString(ref isFirstProp, str, "rows", rows);
                AddPropToString(ref isFirstProp, str, "size", SizeInBytes);
                AddPropToString(ref isFirstProp, str, "version", Version);
            }

            str.Append("]");
            return str.ToString();
        }

    }
}
