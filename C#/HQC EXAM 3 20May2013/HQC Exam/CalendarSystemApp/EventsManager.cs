namespace CalendarSystemNS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EventsManager : IEventsManager
    {
        private readonly List<Event> events;

        public EventsManager()
        {
            this.events = new List<Event>();
        }

        public void AddEvent(Event newEvent)
        {
            this.events.Add(newEvent);
        }

        public int DeleteEventsByTitle(string title)
        {
            return this.events.RemoveAll(
                curEvent => curEvent.Title.ToLowerInvariant() == title.ToLowerInvariant());
        }

        public IEnumerable<Event> ListEvents(DateTime date, int count)
        {
            var events = 
                from curEvent in this.events
                where curEvent.Date >= date
                orderby curEvent.Date, curEvent.Title, curEvent.Location
                select curEvent;

            return events.Take(count);
        }
    }
}
