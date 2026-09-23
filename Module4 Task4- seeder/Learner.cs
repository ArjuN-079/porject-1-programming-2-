using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_Task4__seeder
{
    public class Learner : person //adding person in learner for enums function in learner code
    {
        private CourseAssessmentMark courseAssessmentMark;

        public Learner(int id, string firstName, string lastName, CourseAssessmentMark courseAssessmentMark):base (id,firstName, lastName)
        {
            this.courseAssessmentMark = courseAssessmentMark;
        }

        public CourseAssessmentMark CourseAssessmentMark { get => courseAssessmentMark; set => courseAssessmentMark = value; }
    }
}
