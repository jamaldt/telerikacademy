namespace CalendarSystemNS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;
    using MultiDictionary = Wintellect.PowerCollections.MultiDictionary<string, CalendarSystemNS.Event>;

    public class EventsManagerFast : IEventsManager
    {
        private readonly MultiDictionary eventsKeyedByLowerCaseTitle;
        private readonly OrderedMultiDictionary<DateTime, Event> eventsOrderedByDate;

        public EventsManagerFast()
        {
            this.eventsKeyedByLowerCaseTitle = new MultiDictionary(true);
            this.eventsOrderedByDate = new OrderedMultiDictionary<DateTime, Event>(true);
        }

        public ICollection<Event> Events
        {
            get
            {
                List<Event> events = new List<Event>();
                foreach (Event ev in this.eventsOrderedByDate.Values)
                {
                    events.Add(ev);
                }

                return events;
            }
        }

        public void AddEvent(Event newEvent)
        {
            string eventTitleLowerCase = newEvent.Title.ToLowerInvariant();
            this.eventsKeyedByLowerCaseTitle.Add(eventTitleLowerCase, newEvent);
            this.eventsOrderedByDate.Add(newEvent.Date, newEvent);
        }

        public int DeleteEventsByTitle(string eventTitle)
        {
            string title = eventTitle.ToLowerInvariant();
            var eventsToDelete = this.eventsKeyedByLowerCaseTitle[title];
            int deletedEventsCount = eventsToDelete.Count;

            foreach (var delEvent in eventsToDelete)
            {
                this.eventsOrderedByDate.Remove(delEvent.Date, delEvent);
            }

            this.eventsKeyedByLowerCaseTitle.Remove(title);

            return deletedEventsCount;
        }

        public IEnumerable<Event> ListEvents(DateTime date, int count)
        {
            var events =
                from curEvent in this.eventsOrderedByDate.RangeFrom(date, true).Values
                //orderby curEvent.Date, curEvent.Title, curEvent.Location
                select curEvent;

            return events.Take(count);
        }
    }
}
