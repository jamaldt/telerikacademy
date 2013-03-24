using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_1___Document_System
{
    public class Audio : MultimediaDocuments
    {

        private int sampleRateHz;

        public int SampleRateHz
        {
            get { return sampleRateHz; }
            set { sampleRateHz = value; }
        }

        public Audio(String name) : base(name) { }

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
