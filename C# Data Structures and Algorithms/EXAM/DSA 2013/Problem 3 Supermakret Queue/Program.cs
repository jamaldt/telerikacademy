using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        StringBuilder sb = new StringBuilder();
        SiteControler siteController = new SiteControler(sb);

        string input = Console.ReadLine();
        while (!input.Equals("End"))
        {
            Command command = new Command(input);
            siteController.Execute(command);
            input = Console.ReadLine();
        }

        Console.Write(sb.ToString());
    }
}

class Person
{
    public Person(string name)
    {
        this.Name = name;
        this.Previous = null;
        this.Next = null;
    }

    public string Name { get; set; }
    public Person Previous { get; set; }
    public Person Next { get; set; }

    public override string ToString()
    {
        return string.Format("{0}", this.Name);
    }
}

public class SiteControler
{
    private const string Append = "Append";
    private const string Insert = "Insert";
    private const string Find = "Find";
    private const string Serve = "Serve";

    private const string Error = "Error";
    private const string Ok = "OK";

    private StringBuilder sb;
    private MarketQueue mq;

    public SiteControler(StringBuilder sb)
    {
        this.sb = sb;
        this.mq = new MarketQueue();
    }

    public void Execute(Command command)
    {
        switch (command.Name)
        {
            case Append:
                AppendPerson(command.Arguments[0]);
                break;
            case Insert:
                int pos = int.Parse(command.Arguments[0]);
                string name = command.Arguments[1];
                InsertPerson(pos, name);
                break;
            case Find:
                FindPersons(command.Arguments[0]);
                break;
            case Serve:
                int count = int.Parse(command.Arguments[0]);
                ServePersons(count);
                break;
            default:
                throw new ArgumentException();
        }
    }

    private void ServePersons(int count)
    {
        int numberOfPplInQueue = this.mq.Count;
        if (count > numberOfPplInQueue)
        {
            this.sb.AppendLine(Error);
            return;
        }

        sb.AppendLine(this.mq.Serve(count));
    }

    private void FindPersons(string name)
    {
        int count = mq.FindByName(name);
        sb.AppendLine(count.ToString());
    }

    private void InsertPerson(int pos, string name)
    {
        int numberOfPplInQueue = this.mq.Count;
        if (pos == 0)
        {
            this.mq.InsertFirst(name);
            this.sb.AppendLine(Ok);
        }
        else if (pos == numberOfPplInQueue)
        {
            this.AppendPerson(name);
        }
        else if (pos > numberOfPplInQueue)
        {
            this.sb.AppendLine(Error);
        }
        else
        {
            this.mq.Insert(pos, name);
            this.sb.AppendLine(Ok);
        }
    }

    private void AppendPerson(string name)
    {
        this.mq.Add(name);
        this.sb.AppendLine(Ok);
    }


}

public class MarketQueue
{
    private IDictionary<string, IList<Person>> personsByName = new Dictionary<string, IList<Person>>();
    private LinkedList<Person> queue = new LinkedList<Person>();
    private StringBuilder sb = new StringBuilder();

    internal void Add(string name)
    {
        Person person = new Person(name);
        this.AddByName(person);
        queue.AddLast(person);
    }

    public int Count { get { return queue.Count; } }

    internal void Insert(int pos, string name)
    {
        Person newPerson = new Person(name);
        this.AddByName(newPerson);

        //if (pos < this.queue.Count / 2)
        {
            // go from first
            var person = this.queue.First;

            int dif = this.queue.Count - pos;
            if (dif > 4)
            {
                try
                {
                    int len = pos / 2;
                    for (int i = 0; i < len; i++)
                    {
                        person = person.Next.Next;
                    }

                    if (pos % 2 > 0)
                    {
                        person = person.Next;
                    }
                }
                catch (Exception)
                {
                    throw new FormatException();
                }
            }
            else
            {
                for (int i = 0; i < pos; i++)
                {
                    person = person.Next;
                }
            }

            this.queue.AddBefore(person, newPerson);
        }
        //else
        //{
        //    // start from last
        //    var person = this.queue.Last;

        //    if (this.queue.Count - pos > 4)
        //    {
        //        try
        //        {
        //            int len = pos / 2;
        //            for (int i = this.queue.Count; i > len; i--)
        //            {
        //                person = person.Previous.Previous;
        //            }

        //            if (pos % 2 == 0)
        //            {
        //                person = person.Next;
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            throw new ExecutionEngineException();
        //        }
        //    }
        //    else
        //    {
        //        for (int i = this.queue.Count; i > pos; i--)
        //        {
        //            person = person.Previous;
        //        }
        //    }

        //    this.queue.AddAfter(person, newPerson);
        //}
    }

    private void AddByName(Person newPerson)
    {
        string name = newPerson.Name;
        if (personsByName.ContainsKey(name))
        {
            personsByName[name].Add(newPerson);
        }
        else
        {
            List<Person> list = new List<Person>();
            list.Add(newPerson);
            personsByName.Add(name, list);
        }
    }

    internal int FindByName(string name)
    {
        if (personsByName.ContainsKey(name))
        {
            return personsByName[name].Count;
        }
        else
        {
            return 0;
        }
    }

    internal string Serve(int count)
    {
        Person person;
        sb.Clear();
        for (int i = 0; i < count; i++)
        {
            person = this.queue.First.Value;
            this.queue.RemoveFirst();
            personsByName[person.Name].Remove(person);

            sb.Append(person.ToString());
            sb.Append(" ");
        }

        return sb.ToString();
    }

    internal void InsertFirst(string name)
    {
        Person person = new Person(name);
        this.AddByName(person);
        this.queue.AddFirst(person);
    }
}

public class Command
{
    private string name;
    private string[] arguments;

    public Command(string input)
    {
        string[] str = input.Split(' ');
        this.name = str[0];
        string[] arguments = new string[str.Length - 1];
        for (int i = 0; i < arguments.Length; i++)
        {
            arguments[i] = str[i + 1];//.Trim();
        }
        this.arguments = arguments;
    }

    public string Name { get { return this.name; } }
    public string[] Arguments { get { return this.arguments; } }
}

