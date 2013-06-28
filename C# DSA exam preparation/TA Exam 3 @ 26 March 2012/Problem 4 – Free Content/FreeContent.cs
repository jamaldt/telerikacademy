﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using Wintellect.PowerCollections;

class FreeContent
{
    static void Main()
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

public class SiteControler
{
    private const string AddBookCmd = "Add book";
    private const string AddMovieCmd = "Add movie";
    private const string AddSongCmd = "Add song";
    private const string AddApplicationCmd = "Add application";
    private const string UpdateCmd = "Update";
    private const string FindCmd = "Find";

    private const string BookAdded = "Book added";
    private const string MovieAdded = "Movie added";
    private const string SongAdded = "Song added";
    private const string ApplicationAdded = "Application added";
    private const string ItemsUpdated = " items updated";
    private const string NoItemsFound = "No items found";


    private StringBuilder sb;
    private Catalog catalog = new Catalog();

    public SiteControler(StringBuilder sb)
    {
        this.sb = sb;
    }

    public void Execute(Command command)
    {
        switch (command.Name)
        {
            case AddBookCmd:
                AddBook(command.Arguments);
                break;
            case AddMovieCmd:
                AddMovie(command.Arguments);
                break;
            case AddSongCmd:
                AddSong(command.Arguments);
                break;
            case AddApplicationCmd:
                AddApplication(command.Arguments);
                break;
            case UpdateCmd:
                Update(command.Arguments);
                break;
            case FindCmd:
                Find(command.Arguments);
                break;
            default:
                throw new ArgumentException();
        }
    }

    private void Find(string[] p)
    {
        string title = p[0];
        IEnumerable<Item> foundItems = this.catalog.FindByTitle(title);

        if (contentByTitle.ContainsKey(title))
        {
            int count = int.Parse(p[1]);
            int index = 0;
            IDictionary<Item, int> foundItems = contentByTitle[title];
            bool exit = false;

            foreach (var item in foundItems)
            {
                index += 1;
                if (index > count || exit)
                {
                    break;
                }

                if (item.Value == 1)
                {
                    this.sb.AppendLine(item.Key.ToString());
                }
                else
                {
                    for (int i = 0; i < item.Value; i++)
                    {
                        this.sb.AppendLine(item.Key.ToString());
                        index += 1;
                        if (index > count)
                        {
                            exit = true;
                            break;
                        }
                    }
                    index--;
                }
            }
        }
        else
        {
            this.sb.AppendLine(NoItemsFound);
        }
    }

    private void Update(string[] p)
    {
        int count = 0;
        string oldUrl = p[0];

        if (contentByUrl.ContainsKey(oldUrl))
        {
            string newUrl = p[1];

            ICollection<Item> itemsToUpdate = contentByUrl[oldUrl];
            // save number for result outut;
            count = itemsToUpdate.Count;

            // Remove all items
            contentByUrl.Remove(oldUrl);
            foreach (var item in itemsToUpdate)
            {
                IDictionary<Item, int> dict = contentByTitle[item.Title];
                dict.Remove(item);
            }

            // Add back updated
            foreach (var item in itemsToUpdate)
        	{
                item.Url = newUrl;
                AddToCatalogs(item);
            }
        }

        sb.AppendLine("" + count + ItemsUpdated);
    }

    private void AddApplication(string[] p)
    {
        string title = p[0];
        string author = p[1];
        string size = p[2];
        string url = p[3];
        AddContent("Application", title, author, size, url);

        sb.AppendLine(ApplicationAdded);
    }

    private void AddSong(string[] p)
    {
        string title = p[0];
        string author = p[1];
        string size = p[2];
        string url = p[3];
        AddContent("Song", title, author, size, url);

        sb.AppendLine(SongAdded);
    }

    private void AddMovie(string[] p)
    {
        string title = p[0];
        string author = p[1];
        string size = p[2];
        string url = p[3];
        AddContent("Movie", title, author, size, url);

        sb.AppendLine(MovieAdded);
    }

    private void AddBook(string[] p)
    {
        string title = p[0];
        string author = p[1];
        string size = p[2];
        string url = p[3];
        AddContent("Book", title, author, size, url);

        sb.AppendLine(BookAdded);
    }

    private void AddContent(string type, string title, string author, string size, string url)
    {
        Item content = new Item(type, title, author, size, url);
        AddToCatalogs(content);
    }

    private void AddToCatalogs(Item content)
    {
        string title = content.Title;
        string url = content.Url;
        this.catalog.Add(content);
    }

}

public class Command
{
    private string name;
    private string[] arguments;

    public Command(string input)
    {
        string[] str = input.Split(new string[] { ": " }, 2, StringSplitOptions.RemoveEmptyEntries);
        this.name = str[0];
        string[] arguments = str[1].Split(';');
        for (int i = 0; i < arguments.Length; i++)
        {
            arguments[i] = arguments[i].Trim();
        }
        this.arguments = arguments;
    }

    public string Name { get { return this.name; } }
    public string[] Arguments { get { return this.arguments; } }
}

class Item : IComparable<Item>
{
    private string type;
    private string title;
    private string author;
    private string size;
    private string url;

    public Item(string type, string title, string author, string size, string url)
    {
        this.type = type;
        this.title = title;
        this.author = author;
        this.size = size;
        this.url = url;
    }

    public string Url { set { this.url = value; } get { return this.url; } }
    public string Title { get { return this.title; } }

    public override string ToString()
    {
        return String.Format("{0}: {1}; {2}; {3}; {4}", this.type, this.title, this.author, this.size, this.url);
    }

    public int CompareTo(Item other)
    {
        int compareResult = string.Compare(this.ToString(), other.ToString());
        return compareResult;
    }
}

class Catalog
{
    private IDictionary<string, ICollection<Item>> contentByUrl = new Dictionary<string, ICollection<Item>>();
    private IDictionary<string, IDictionary<Item, int>> contentByTitle = new Dictionary<string, IDictionary<Item, int>>();

    internal int UpdateUrl(string oldUrl, string newUrl)
    {
        int updatedItemsCount = 0;

        if (this.contentByUrl.ContainsKey(oldUrl))
        {
            ICollection<Item> itemsToUpdate = this.contentByUrl[oldUrl].ToList(); // Remidner!! ToList()!!! Because it returns some other structures.

            updatedItemsCount = itemsToUpdate.Count;

            // Remove all items
            this.contentByUrl.Remove(oldUrl);
            foreach (var item in itemsToUpdate)
            {
                this.contentByTitle.Remove(item.Title, item);
            }

            // Add back updated
            foreach (var item in itemsToUpdate)
            {
                item.Url = newUrl;
                this.Add(item);
            }
        }

        return updatedItemsCount;
    }

    internal IEnumerable<Item> FindByTitle(string title)
    {
        IEnumerable<Item> foundItems = null;
        if (contentByTitle.ContainsKey(title))
        {
            foundItems = this.contentByTitle[title].ToList();
        }

        return foundItems;
    }

    internal void Add(Item content)
    {
        string title = content.Title;
        string url = content.Url;

        // Add by title
        if (contentByTitle.ContainsKey(title))
        {
            IDictionary<Item, int> dict = contentByTitle[title];
            if (dict.ContainsKey(content))
            {
                dict[content] += 1;
            }
            else
            {
                dict.Add(content, 1);
            }
        }
        else
        {
            IDictionary<Item, int> dict = new SortedDictionary<Item, int>();
            dict.Add(content, 1);
            contentByTitle.Add(title, dict);
        }
        // Add by url
        if (contentByUrl.ContainsKey(url))
        {
            contentByUrl[url].Add(content);
        }
        else
        {
            ICollection<Item> set = new List<Item>();
            set.Add(content);
            contentByUrl.Add(url, set);
        }
    }
}