using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp
{
    class Student
    {
        private string _id;
        public string Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Student()
        {
            _id = $"stu-{(new Random()).Next()}";
            Id = _id;
        }

        public Student(string name, string surname) : this()
        {
            Name = name;
            Surname = surname;
        }
    }
}
