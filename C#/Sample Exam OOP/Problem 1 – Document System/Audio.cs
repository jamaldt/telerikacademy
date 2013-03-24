using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_1___Document_System
{
    public class Audio : MultimediaDocuments
    {

        private string sampleRateHz;

        public string SampleRateHz
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

        public override string ToString()
        {
            bool isFirstProp = true;
            StringBuilder str = new StringBuilder();
            str.Append("AudioDocument[");

            AddPropToString(ref isFirstProp, str, "content", content);
            AddPropToString(ref isFirstProp, str, "length", LengthInSeconds);
            AddPropToString(ref isFirstProp, str, "name", name);
            AddPropToString(ref isFirstProp, str, "samplerate", sampleRateHz);
            AddPropToString(ref isFirstProp, str, "size", SizeInBytes);

            str.Append("]");
            return str.ToString();
        }

    }


}
