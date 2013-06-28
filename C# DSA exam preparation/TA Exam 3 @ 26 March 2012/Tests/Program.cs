using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<Content>> dict = new Dictionary<string, List<Content>>();
        string oldKey = "abra";
        string newKey = "kadabra";

        dict.Add(oldKey, new List<Content>());
        dict.Add(newKey, new List<Content>());

        for (int i = 0; i < 10; i++)
        {
            dict[oldKey].Add(new Content("1"));
        }
        
        for (int i = 10; i < 20; i++)
        {
            dict[newKey].Add(new Content(i.ToString()));
        }

        List<Content> list = dict[oldKey];
        dict.Remove(oldKey);

        foreach (var item in list)
        {
            dict[newKey].Add(item);
        }

        List<Content> l = (dict[newKey]);
        l.Sort();

        foreach (var item in l)
        {
            Console.WriteLine(item.Num);
            
        }
    }
}


class Content : IComparable<Content>
{
    public string Num { get; set; }

    public Content(string num)
    {
        this.Num = num;
    }

    public int CompareTo(Content other)
    {
        int result = this.Num.CompareTo(other.Num);
        return result;
    }
}