using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_Task4__seeder
{
    public static class Seeder
    {
        private static List<Institution> institutions = new List<Institution>();
        private static List<Department> departments = new List<Department>();
        private static List<Course> courses = new List<Course>();

        public static List<Institution> SeedInstitutions()
        {
            institutions.Add(new Institution("Otago Polytechnic", "Otago", "New Zealand"));
            institutions.Add(new Institution("University of Auckland", "Auckland", "New Zealand"));
            institutions.Add(new Institution("Otago University", "Dunedin", "New Zealand"));
            // TODO: add two more
            return institutions;
        }

        public static List<Department> SeedDepartments()
        {
            departments.Add(new Department(institutions[0], "Information Technology"));
            departments.Add(new Department(institutions[1], "Engineering"));
            departments.Add(new Department(institutions[2], "Marketing Management"));
            // TODO: add two more
            return departments;
        }

        public static List<Course> SeedCourses()
        {
            courses.Add(new Course(departments[0], "ID511001", "Programming 2", "Advanced programming concepts", 15, 3500));
            courses.Add(new Course(departments[1], "RTR51160", "cell Engineering", "Focuses on Cell Manipulation", 15, 1400));
            courses.Add(new Course(departments[2], "862WY550", "Marketing 2", "Marketing strategy management", 15, 5020));
            // TODO: add two more
            return courses;
        }
    }

}
