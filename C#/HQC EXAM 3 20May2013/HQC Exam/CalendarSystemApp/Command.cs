namespace CalendarSystemNS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Command
    {
        private Command(string name, string[] commandArguments)
        {
            this.Name = name;
            this.Arguments = commandArguments;
        }

        public string Name { get; set; }

        public string[] Arguments { get; set; }

        public static Command Parse(string inputCommand)
        {
            int cmdLastIndex = inputCommand.IndexOf(' ');
            if (cmdLastIndex == -1)
            {
                throw new ArgumentException("Invalid command: " + inputCommand);
            }

            string name = inputCommand.Substring(0, cmdLastIndex);
            string argumentsString = inputCommand.Substring(cmdLastIndex + 1);

            string[] commandArguments = argumentsString.Split('|');
            for (int i = 0; i < commandArguments.Length; i++)
            {
                string argument = commandArguments[i];
                commandArguments[i] = argument.Trim();
            }

            return new Command(name, commandArguments);
        }
    }
}
