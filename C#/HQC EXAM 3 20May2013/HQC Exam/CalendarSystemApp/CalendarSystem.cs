namespace CalendarSystemNS
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CalendarSystem
    {
        public static void Main()
        {
            ////IEventsManager eventsManager = new EventsManager();
            IEventsManager eventsManager = new EventsManagerFast();
            EventProcessor eventProcessor = new EventProcessor(eventsManager);
            StringBuilder commandsResult = new StringBuilder();
            List<string> commands = new List<string>();

            while (true)
            {
                string commandInput = Console.ReadLine();

                if (string.IsNullOrEmpty(commandInput))
                {
                    throw new ArgumentException("Command can't be null or empty: " + commandInput);
                }
                else if (commandInput == "End")
                {
                    // Exit command proccessing loop and print results
                    break;
                }
                else
                {
                    commands.Add(commandInput);
              
                }
            }

            ProcessComands(eventProcessor, commandsResult, commands);
            Console.Write(commandsResult.ToString());
        }

        private static void ProcessComands(EventProcessor eventProcessor, StringBuilder commandsResult, List<string> commands)
        {
            foreach (var cmd in commands)
            {
                try
                {
                    Command command = Command.Parse(cmd);
                    string result = eventProcessor.ProcessCommand(command);
                    commandsResult.AppendLine(result);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}