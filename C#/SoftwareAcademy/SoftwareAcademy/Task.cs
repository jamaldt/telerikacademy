using SoftwareAcademy;
using System.Reflection;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;
namespace SoftwareAcademy
{
    public class Course : ICourse
    {
        private List<string> topics;

        public List<string> Topics
        {
            get { return topics; }
        }

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                this.name = value;
            }
        }

        private ITeacher teacher;

        public ITeacher Teacher
        {
            get
            {
                return teacher;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                this.teacher = value;
            }
        }

        protected Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.teacher = teacher;
            this.topics = new List<string>();
        }

        public void AddTopic(string topic)
        {
            if (topic == null)
            {
                throw new ArgumentNullException();
            }
            topics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name);
            result.AppendFormat(": Name={0}", this.name);

            if (teacher != null)
            {
                result.AppendFormat("; Teacher={0}", teacher.Name);
            }

            if (topics.Count > 0)
            {
                result.Append("; Topics=[");
                bool first = true;

                foreach (var topic in topics)
                {
                    if (first)
                        result.Append(topic);
                    else
                    {
                        result.Append(", ");
                        result.Append(topic);
                    }
                }
                result.Append("]");
            }
            return result.ToString();
        }
    }

    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            return new Teacher(name);
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            return new LocalCourse(name, teacher, lab);
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            return new OffsiteCourse(name, teacher, town);
        }
    }

    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }

    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public string Lab
        {
            get
            {
                return lab;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                lab = value;
            }
        }

        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name, teacher)
        {
            this.Lab = lab;
        }

        public override string ToString()
        {
            return base.ToString() + String.Format("; Lab={0}", this.Lab);
        }
    }

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public string Town
        {
            get
            {
                return town;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                this.town = value;
            }
        }

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            this.Town = town;
        }

        public override string ToString()
        {
            return base.ToString() + String.Format("; Town={0}", this.Town);
        }
    }

    public class SoftwareAcademyCommandExecutor
    {
        static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"
                  

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }

    public class Teacher : ITeacher
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                this.name = value;
            }
        }


        private List<ICourse> courses;

        public List<ICourse> Courses
        {
            get { return courses; }
        }

        public Teacher(string name)
        {
            this.Name = name;
            this.courses = new List<ICourse>();
        }

        public void AddCourse(ICourse course)
        {
            if (course == null)
            {
                throw new ArgumentNullException();
            }
            courses.Add(course);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name);
            result.AppendFormat(": Name={0}", this.name);

            if (courses.Count > 0)
            {
                result.Append("; Courses=[");
                bool first = true;

                foreach (var course in courses)
                {
                    if (first)
                        result.Append(course);
                    else
                    {
                        result.Append(", ");
                        result.Append(course);
                    }
                }
                result.Append("]");
            }
            return result.ToString();
        }
    }
}

