namespace CalendarSystemNS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IEventsManager
    {
        /// <summary>
        /// Adds new event to EventsManager.
        /// </summary>
        void AddEvent(Event newEvent);

        /// <summary>
        /// Delete all events in EventsManager whith speciafied title. NOTE: Case insencitive.
        /// </summary>
        /// <param name="title">Case insencitive title of events.</param>
        /// <returns>Returns number of deleted events.</returns>
        int DeleteEventsByTitle(string title);

        /// <summary>
        /// Returns all events from certain date in ascending order.
        /// </summary>
        /// <param name="date">Date to match.</param>
        /// <param name="count">Specify how many events to return.</param>
        /// <returns>IEnumerable collcection.</returns>
        IEnumerable<Event> ListEvents(DateTime date, int count);
    }
}
