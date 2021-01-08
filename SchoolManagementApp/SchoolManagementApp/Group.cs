using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp
{
    public class Group
    {
        public string Id { get; set; }
        public string Name { get; set; }
        private List<Student> Students;

        public Group()
        {
            Id = $"gr-{(new Random()).Next()}";
            Students = new List<Student>();
        }

        public Group(string name) : this()
        {
            Name = name;
        }

        public List<Student> GetStudentList() => Students;

        public void AddStudent(Student student) => Students.Add(student);

        public void DeleteStudent(Student student) => Students.Remove(student);

        public override string ToString()
        {
            return Name;
        }
    }
}
