using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human
{
    class Worker : Human
    {
        public double WeekSalary { get; set; }
        public double WorkHoursPerDay { get; set; }

        public Worker(string firstName, string lastName, double salary, double workHours)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.WeekSalary = salary;
            this.WorkHoursPerDay = workHours;
        }



        public double MoneyPerHour()
        {
            return WeekSalary / (WorkHoursPerDay * 5);
        }
    }
}
