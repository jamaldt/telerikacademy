using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Disciplines : IComment
    {
        private String name;
        private int numLectures;
        private int numExercises;
        public int NumLectures { get { return numLectures; } }
        public int NumExercises { get { return numExercises; } }
        public String Name { get { return name; } }

        public Disciplines(String name, int numLectures, int numExercises)
        {
            this.name = name;
            this.numExercises = numExercises;
            this.numLectures = numLectures;
        }

        public string Comment { get; set; }

    }
}
