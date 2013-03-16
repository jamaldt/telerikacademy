using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Class : IComment
    {

        private List<Student> students = new List<Student>();
        private List<Teacher> teachers = new List<Teacher>();
        private String id;
        
        
        public string Comment { get; set; }
        public String Id{ get { return id; } }


    }
}
