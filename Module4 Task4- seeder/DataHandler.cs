using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_Task4__seeder
{
    public class DataHandler
        //adding learners.txt and lecturer.txt populating the lists of learner and lecturer
    {
        public static void ReadFromFile(string filePath, List<Learner> learners, List<Course> courses)
        {
            //learner details(path)
            List<string> lines = File.ReadAllLines(filePath).ToList();
            foreach (string line in lines)
            {
                string[] learnerDetails = line.Split(',');
                int id = int.Parse(learnerDetails[0]);
                string firstName = learnerDetails[1];
                string lastName = learnerDetails[2];
                int courseNum = int.Parse(learnerDetails[3]);

                List<int> marks = new List<int>()
        {
            Convert.ToInt32(learnerDetails[4]),
            Convert.ToInt32(learnerDetails[5]),
            Convert.ToInt32(learnerDetails[6]),
            Convert.ToInt32(learnerDetails[7]),
            Convert.ToInt32(learnerDetails[8])
        };

                CourseAssessmentMark assessmentMarks = new CourseAssessmentMark(courses[courseNum], marks);
                Learner learner = new Learner(id, firstName, lastName, assessmentMarks);
                learners.Add(learner);
            }
        }
        //adding the same code to lecturer file.txt
        public static void LecturersFile(string filePath, List<Lecturer> lecturers, List<Course> courses)
        {
            //lecturer details(path)
            List<string> lines = File.ReadAllLines(filePath).ToList();
            foreach (string line in lines)
            {
                string[] lecturerDetails = line.Split(',');
                int id = int.Parse(lecturerDetails[0]);
                string firstName = lecturerDetails[1];
                string lastName = lecturerDetails[2];
                int positionNum = int.Parse(lecturerDetails[3]);
                int salaryNum = int.Parse(lecturerDetails[4]);
                int courseNum = int.Parse(lecturerDetails[5]);
                Eposition position = (Eposition)positionNum;
                ESalary salary = (ESalary)salaryNum;
                Course course = courses[courseNum];
                Lecturer lecturer = new Lecturer(id, firstName, lastName, (Eposition)position, (ESalary)salary, course);
                lecturers.Add(lecturer);
            }
        }
    }
}
