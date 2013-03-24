using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Student
{

    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[10];
            for (int i = 0; i < 10; i++)
            {
                students[i] = new Student();
            }

            foreach (var student in students)
            {
                Console.WriteLine(student + " | hash = " + student.GetHashCode());
            }

            Console.WriteLine();
            if (students[0] == students[1])
                Console.WriteLine(students[0] + " equals " + students[1]);
            else
                Console.WriteLine(students[0] + " not equals " + students[1]);

            Console.WriteLine("\nClone test");
            Student studentClone = students[0].Clone();

            if (students[0].Equals(studentClone))
                Console.WriteLine("equal -- look the code :)");
            else
                Console.WriteLine("not equal");


            Console.WriteLine("\nSorting students:");
            Array.Sort(students);

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("Let's clone 1st student to 10th:");
            students[9] = students[0].Clone();
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine("Change it's SSN and sort again:");
            students[9].SSN = new Random().Next(100000) + 9999;
            Array.Sort(students);
            foreach (var student in students)
	        {
                Console.WriteLine(student);
	        }

            Console.WriteLine("Nice a? :)");

        }

    }
}
