using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalendarSystemNS;
using System.Globalization;
using System.Collections.Generic;

namespace CalendarSystem.Test
{
    [TestClass]
    public class EventsManagerFastTest 
    {
        [TestMethod]
        public void AddEventTest()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            DateTime date = CreateDate("2000-11-13T00:00:01");
            Event testEvent = new Event(date, "exam");
            eventsManager.AddEvent(testEvent);
            int eventsCount = eventsManager.Events.Count;
            Assert.IsTrue(eventsCount == 1);

            ICollection<Event> target = eventsManager.Events;
            Assert.IsTrue(target.Contains(testEvent));
        }

        [TestMethod]
        public void DeleteEventsByTitleTest()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            DateTime date = CreateDate("2000-11-13T00:00:01");
            string title = "exam";
            Event testEvent = new Event(date, title);
            
            eventsManager.AddEvent(testEvent);
            eventsManager.DeleteEventsByTitle(title);

            int eventsCount = eventsManager.Events.Count;
            Assert.IsTrue(eventsCount == 0);
        }

        [TestMethod]
        public void ListEventsTest()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            string dateInput = "2000-11-13T00:00:01";

            for (int i = 0; i < 10; i++)
            {
                DateTime date = CreateDate(dateInput);
                Event testEvent = new Event(date, i.ToString());
                eventsManager.AddEvent(testEvent);
            }

            DateTime dateCheck = CreateDate(dateInput);
            int eventsCount = 10;
            IEnumerable<Event> events = eventsManager.ListEvents(dateCheck, eventsCount);
            int target = 0;
            foreach (var ev in events)
            {
                target += 1;
                Assert.AreEqual<DateTime>(ev.Date, dateCheck);
            }

            Assert.IsTrue(target == eventsCount);
            
        }

        [TestMethod]
        public void ListEventsWhenThereAreNoItemsTest()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();
            string dateInput = "2000-11-13T00:00:01";
            DateTime dateCheck = CreateDate(dateInput);
            int eventsCount = 10;
            IEnumerable<Event> events = eventsManager.ListEvents(dateCheck, eventsCount);
            int target = 0;
            foreach (var ev in events)
            {
                target += 1;
            }

            Assert.IsTrue(target == 0);

        }

        [TestMethod]
        public void ListEventsWhenThereIsNoSuchDateAvaliableTest()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            string dateInput = "2000-11-13T00:00:01";

            for (int i = 0; i < 10; i++)
            {
                DateTime date = CreateDate(dateInput);
                Event testEvent = new Event(date, i.ToString());
                eventsManager.AddEvent(testEvent);
            }

            dateInput = "2000-11-13T00:55:05";
            DateTime dateCheck = CreateDate(dateInput);
            int eventsCount = 10;
            IEnumerable<Event> events = eventsManager.ListEvents(dateCheck, eventsCount);
            int target = 0;
            foreach (var ev in events)
            {
                target += 1;
                Assert.AreNotEqual<DateTime>(ev.Date, dateCheck);
            }

            Assert.IsTrue(target == 0);

        }

        private static DateTime CreateDate(string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            return dateTime;
        }
    }
}
