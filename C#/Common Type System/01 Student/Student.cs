using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Student
{
    class Student : ICloneable, IComparable<Student>
    {
        private static int id = 0;
        private static int _ssn = 1000;
        private static Random rand = new Random();

        public Student()
        {
            firstName = "Student";
            lastName = (++id).ToString();
            ssn = _ssn + rand.Next(1000000);
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string middleName;

        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Name
        {
            get
            {
                return firstName + " " + middleName + " " + lastName;
            }
        }

        private int ssn;

        public int SSN
        {
            get { return ssn; }
            set { ssn = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string mobilePhone;

        public string MobilePhone
        {
            get { return mobilePhone; }
            set { mobilePhone = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string course;

        public string Course
        {
            get { return course; }
            set { course = value; }
        }

        private Specialty specialty;

        public Specialty Specialty
        {
            get { return specialty; }
            set { specialty = value; }
        }

        private University university;

        public University University
        {
            get { return university; }
            set { university = value; }
        }

        private Faculty faculty;

        public Faculty Faculty
        {
            get { return faculty; }
            set { faculty = value; }
        }

        public override bool Equals(object obj)
        {
            // If the cast is invalid, the result will be null
            Student student = obj as Student;
            if (student == null)
            {
                return false;
            }

            if (this.Name != student.Name || this.SSN != student.SSN)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return firstName.GetHashCode() ^ lastName.GetHashCode();
        }

        public override string ToString()
        {
            return Name + ", Faculty:" + Faculty + ", SSN:" + SSN;
        }

        public static bool operator ==(Student student1, Student student2)
        {
            return Student.Equals(student1, student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !(Student.Equals(student1, student2));
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Student Clone()
        {
            Student student = new Student();
            student.lastName = this.lastName;
            student.ssn = this.ssn;
            return student;
        }

        public int CompareTo(Student other)
        {
            int result = string.Compare(this.Name, other.Name);
            if (result < 0)
                return -1;
            else if (result > 0)
                return 1;

            if (this.SSN > other.SSN)
                return 1;
            else if (this.SSN < other.SSN)
                return -1;
            else
                throw new Exception("Shit happens - very bad named exception :)");

        }
    }
}
