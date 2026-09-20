using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_Task4__seeder
{
    public class lecturer:person
    {
        private Eposition position;
        private ESalary salary;
        private Course course;

        public lecturer(int id, string firstName, string lastName, Eposition position, ESalary salary, Course course): base(id, firstName, lastName)
        {
            this.position = position;
            this.salary = salary;
            this.course = course;
        }

        public Eposition Position { get => position; set => position = value; }
        public ESalary Salary { get => salary; set => salary = value; }
        public Course Course { get => course; set => course = value; }
    }
}
