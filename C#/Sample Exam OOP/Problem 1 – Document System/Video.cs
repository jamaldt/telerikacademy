using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_1___Document_System
{
    public class Video : MultimediaDocuments
    {

        private int frameRateFPS;

        public int FrameRateFPS
        {
            get { return frameRateFPS; }
            set { frameRateFPS = value; }
        }

        public Video(String name) : base(name) { }

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
