using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
          {
              new Student( "Student1","1", 5 ),
              new Student( "Student2","2", 3 ),
              new Student( "Student3","3", 3 ),
              new Student( "Student4","4", 4 ),
              new Student( "Student5","5", 5 ),
              new Student( "Student6","6", 4 ),
              new Student( "Student7","7", 2 ),
              new Student( "Student8","8", 6 ),
              new Student( "Student9","9", 3 ),
              new Student( "Student10","10", 6 )
          };

            students = students.OrderBy(student => student.Grade).ToList();

            foreach (var item in students)
            {
                Console.WriteLine(item.Name + " " + item.Grade);
            }

            Console.WriteLine();
            Console.WriteLine();
	    
            List<Worker> workers = new List<Worker>()
          {
              new Worker( "Worker1","1", 1, 10),
              new Worker( "Worker2","2", 2, 20 ),
              new Worker( "Worker3","3", 3, 30 ),
              new Worker( "Worker4","4", 4, 40 ),
              new Worker( "Worker5","5", 5, 50 ),
              new Worker( "Worker6","6", 6, 60 ),
              new Worker( "Worker7","7", 7, 70 ),
              new Worker( "Worker8","8", 8, 80 ),
              new Worker( "Worker9","9", 9, 90 ),
              new Worker( "Worker10","10", 10, 100 )
          };

            workers = workers.OrderByDescending(worker => worker.MoneyPerHour()).ToList();

            foreach (var item in workers)
            {
                Console.WriteLine(item.Name + " " + item.MoneyPerHour());
            }

            Console.WriteLine();
            Console.WriteLine();

            var mergedlists = workers.Concat<Human>(students).ToList();
            mergedlists = mergedlists.OrderBy(list => list.FirstName).ThenBy(list => list.LastName).ToList();

            foreach (var item in mergedlists)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
        }
    }
}