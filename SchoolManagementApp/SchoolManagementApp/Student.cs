using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp
{
    public class Student
    {
        private static int _id = (new Random()).Next();
        public string Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Student()
        {
            Id = $"stu-{_id}";
            _id++;
        }

        public Student(string name, string surname) : this()
        {
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}
