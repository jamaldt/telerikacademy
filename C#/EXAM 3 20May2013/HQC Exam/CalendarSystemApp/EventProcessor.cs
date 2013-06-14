namespace CalendarSystemNS
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EventProcessor
    {
        private readonly IEventsManager eventsManager;

        public EventProcessor(IEventsManager eventsManager)
        {
            this.eventsManager = eventsManager;
        }

        public IEventsManager EventsProcessor
        {
            get
            {
                return this.eventsManager;
            }
        }

        public string ProcessCommand(Command command)
        {
            string cmd = command.Name;
            string[] args = command.Arguments;
            string output = string.Empty;

            switch (cmd)
            {
                case "AddEvent":
                    output = this.AddEvent(args);
                    break;
                case "DeleteEvents":
                    output = this.DeleteEvents(args);
                    break;
                case "ListEvents":
                    output = this.ListEvents(args);
                    break;
                default:
                    throw new ArgumentException("Invalid command: " + cmd);
            }

            return output;
        }

        private string AddEvent(string[] args)
        {
            string location;
            if (args.Length == 2)
            {
                location = null;
            }
            else if (args.Length == 3)
            {
                location = args[2];
            }
            else
            {
                throw new ArgumentException("ListEvents command has invalid arguments: " + args.ToString());
            }

            DateTime date = ExtractDate(args[0]);
            string title = args[1];
            Event newEvent = new Event(date, title, location);
            this.eventsManager.AddEvent(newEvent);

            return "Event added";
        }
     
        private string ListEvents(string[] args)
        {
            if (args.Length == 2)
            {
                DateTime date = ExtractDate(args[0]);
                int eventsCount = int.Parse(args[1]);
                var events = this.eventsManager.ListEvents(date, eventsCount).ToList();

                if (!events.Any())
                {
                    return "No events found";
                }

                StringBuilder sb = new StringBuilder();
                foreach (Event e in events)
                {
                    sb.AppendLine(e.ToString());
                }

                return sb.ToString().Trim();
            }
            else
            {
                throw new ArgumentException("ListEvents command has invalid arguments: " + args.ToString());
            }
        }

        private string DeleteEvents(string[] args)
        {
            if (args.Length == 1)
            {
                int deletedEventsCount = this.eventsManager.DeleteEventsByTitle(args[0]);

                if (deletedEventsCount == 0)
                {
                    return "No events found";
                }
                else
                {
                    return (deletedEventsCount + " events deleted");
                }
            }
            else
            {
                throw new ArgumentException("DeleteEvents command has invalid arguments: " + args.ToString());
            }
        }

        private static DateTime ExtractDate(string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            return dateTime;
        }
    }
}