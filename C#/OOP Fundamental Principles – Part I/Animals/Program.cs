using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Program
    {
        public static double AvgAge(List<Animal> list)
        {
	    int age = 0;
            foreach (var item in list)
            {
                age += item.Age;
            }
            return (double)age / list.Count;
        }
        public static void Main(String[] args)
        {
            List<Animal> animals = new List<Animal>();

            animals.Add(new Tomcat(45, "baks"));
            animals.Add(new Kitten(25, "maruska"));
            animals.Add(new Frog(15, "Froggy", true));
            animals.Add(new Dog(5, "Sharo", false));

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.MakeSound(""));
            }
            Console.WriteLine();
            Console.WriteLine("Average age is " + AvgAge(animals) + " years.");
        }
    }
}
