namespace CalendarSystemNS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Event : IComparable<Event>
    {
        public Event(DateTime date, string title)
            : this(date, title, null)
        {
        }

        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public override string ToString()
        {
            string form = "{0:yyyy-MM-ddTHH:mm:ss} | {1}";
            if (this.Location != null)
            {
                form += " | {2}";
            }

            string eventAsString = string.Format(form, this.Date, this.Title, this.Location);
            return eventAsString;
        }

        // bottleneck
        public int CompareTo(Event otherEvent)
        {
            int res = DateTime.Compare(this.Date, otherEvent.Date);

            if (res == 0)
            {
                res = string.Compare(this.Title, otherEvent.Title, StringComparison.InvariantCulture);
            }

            if (res == 0)
            {
               res = string.Compare(this.Location, otherEvent.Location, StringComparison.InvariantCulture);
            }

            return res;
        }
    }
}
