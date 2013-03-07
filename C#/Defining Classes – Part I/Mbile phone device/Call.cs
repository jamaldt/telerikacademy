using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mbile_phone_device
{
    class Call
    {
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public DateTime Time
        {
            get { return date; }
        }

        private int dialedNumber;

        public int DialedNumber
        {
            get { return dialedNumber; }
            set { dialedNumber = value; }
        }
        private int duration; // (in seconds).

        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }


    }
}
