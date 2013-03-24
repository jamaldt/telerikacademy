using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_1___Document_System
{
    public class Excel : OfficeDocument
    {

        private int rows;

        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        private int col;

        public int Col
        {
            get { return col; }
            set { col = value; }
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
    }
}
