using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mbile_phone_device
{
    class Display
    {
        private string size;

        public string Size
        {
            get { return size; }
            set { size = value; }
        }
        private int numColors;

        public int NumColors
        {
            get { return numColors; }
            set { numColors = value; }
        }

        public Display(string displaySize, int displayNumColors)
        {
            this.Size = displaySize;
            this.NumColors = displayNumColors;
        }

        public override string ToString()
        {
            return "Display size: " + this.size + "\nNumber of Colorts: " + numColors;
        }

    }
}
