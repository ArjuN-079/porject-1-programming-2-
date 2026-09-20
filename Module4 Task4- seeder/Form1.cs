namespace Module4_Task4__seeder
{
    public partial class Form1 : Form
    {
        private static List<Institution> institutions;
        private static List<Department> departments;
        private static List<Course> courses;

        private static List<Learner> learners;
        private static List<lecturer> lecturers = new();
        public Form1()
        {
            InitializeComponent();
            institutions = Seeder.SeedInstitutions();
            departments = Seeder.SeedDepartments();
            courses = Seeder.SeedCourses();
            learners = new List<Learner?>();
            DataHandler.ReadFromFile("learners.txt", learners, courses);
            DataHandler.LecturersFile("lecturers.txt", lecturers, courses);


            //CourseAssessmentMark cam = new CourseAssessmentMark(null, new List<int> { 10, 49, 50, 75, 100, 100 });
            //MessageBox.Show(string.Join(", ", cam.GetAllMarks()));
            //MessageBox.Show(string.Join(", ", cam.GetAllGrades()));
            //MessageBox.Show(string.Join(", ", cam.GetHighestMarks()));
            //MessageBox.Show(string.Join(", ", cam.GetLowestMarks()));
            //MessageBox.Show(string.Join(", ", cam.GetFailMarks()));
            //MessageBox.Show(cam.GetAverageMark().ToString());
            //MessageBox.Show(cam.GetAverageGrade());

            Institution institution1 = institutions[0];
            Institution institution2 = institutions[1];
            Department department1 = departments[0];
            Department department2 = departments[1];
            Course course1 = courses[0];
            Course course2 = courses[1];

            MessageBox.Show(institution1.DisplayInfo().ToString());
            MessageBox.Show(institution2.DisplayInfo().ToString());
            MessageBox.Show(department1.DisplayInfo().ToString());
            MessageBox.Show(department2.DisplayInfo().ToString());
            MessageBox.Show(course1.DisplayInfo().ToString());
            MessageBox.Show(course2.DisplayInfo().ToString());
        }

      

        //course details
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = courses.Select(course => new
            {
                course.Code,
                course.Name,
                course.Description,
                course.Credits,
                Fees = (course.Fees).ToString("C"),
                Institution_Name = course.Department.Institution.Name,
                course.Department.Institution.Region,
                course.Department.Institution.Country,
                Department_Name = course.Department.Name,
            }).ToList();

        }
        
        //display course details
        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = learners.Select(learner => new
            {
                learner.Id,
                learner.FirstName,
                learner.LastName,
                courses_code = learner.CourseAssessmentMark.Course.Code,
                courses_name = learner.CourseAssessmentMark.Course.Name,
                Marks = string.Join(",", learner.CourseAssessmentMark.GetAllMarks())
            }).ToList();

        }
        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }
        // Display All grades
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= 
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }
    }
}
