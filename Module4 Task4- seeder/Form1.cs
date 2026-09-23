using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Devices;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Module4_Task4__seeder
{
    public partial class Form1 : Form
    {
        private static List<Institution> institutions;
        private static List<Department> departments;
        private static List<Course> courses;

        //private List<Course> courseList;

        private static List<Learner> learners;
        private static List<Lecturer> lecturers;
        public Form1()
        {
            InitializeComponent();
            institutions = Seeder.SeedInstitutions();
            departments = Seeder.SeedDepartments();
            courses = Seeder.SeedCourses();
            learners = new List<Learner>();
            lecturers = new List<Lecturer>();
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

        // Display All grades
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = learners.Select(learner => new
            {
                learner.Id,
                learner.FirstName,
                learner.LastName,
                courses_code = learner.CourseAssessmentMark.Course.Code,
                courses_name = learner.CourseAssessmentMark.Course.Name,
                Grades = string.Join(",", learner.CourseAssessmentMark.GetAllGrades())
            }).ToList();

        }

        //Display Highest Marks
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = learners.Select(learner => new
            {
                learner.Id,
                learner.FirstName,
                learner.LastName,
                courses_code = learner.CourseAssessmentMark.Course.Code,
                courses_name = learner.CourseAssessmentMark.Course.Name,
                HighestMarks = string.Join(",", learner.CourseAssessmentMark.GetHighestMarks())
            }).ToList();
        }
        //Display Lowest Marks
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = learners.Select(learner => new
            {
                learner.Id,
                learner.FirstName,
                learner.LastName,
                courses_code = learner.CourseAssessmentMark.Course.Code,
                courses_name = learner.CourseAssessmentMark.Course.Name,
                LowestMarks = string.Join(",", learner.CourseAssessmentMark.GetLowestMarks())
            }).ToList();
        }
        //Display Fail Marks
        private void button6_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = learners.Select(learner => new
            {
                learner.Id,
                learner.FirstName,
                learner.LastName,
                courses_code = learner.CourseAssessmentMark.Course.Code,
                courses_name = learner.CourseAssessmentMark.Course.Name,
                FailMarks = string.Join(",", learner.CourseAssessmentMark.GetFailMarks())
            }).ToList();
        }
        //Display Average Marks
        private void button7_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = learners.Select(learner => new
            {
                learner.Id,
                learner.FirstName,
                learner.LastName,
                courses_code = learner.CourseAssessmentMark.Course.Code,
                courses_name = learner.CourseAssessmentMark.Course.Name,
                AverageMarks = string.Join(",", learner.CourseAssessmentMark.GetAverageMark())
            }).ToList();
        }
        //Display Average Grades
        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = learners.Select(learner => new
            {
                learner.Id,
                learner.FirstName,
                learner.LastName,

                courses_code = learner.CourseAssessmentMark.Course.Code,
                courses_name = learner.CourseAssessmentMark.Course.Name,
                AverageGrades = string.Join(",", learner.CourseAssessmentMark.GetAverageGrade
                ())
            }).ToList();
        }
        //Display Lecturer Details
        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = lecturers.Select(lecturer => new
            {
                lecturer.Id,
                lecturer.FirstName,
                lecturer.LastName,
                lecturer.Position,
                lecturer.Course.Department.Institution.Name,
                lecturer.Course.Department.Institution.Region,
                lecturer.Course.Department.Institution.Country,
                department_name = lecturer.Course.Department.Name,
                lecturer.Course.Code,
                // lecturer.Salary
                Salary = (int)lecturer.Salary



            }).ToList();
        }
        //Add learner(adding the learner is some issue)

        // youtube and w3 school and the help of copilot
        /// <summary>

        //>  Summary of Work Done:
        // add learner i use the dlg and box style in copilot
        //dlg - its a class for adding new forms
        // course list to add
        // File maganement task 5 string[] lines = File.ReadAllLines(filePath);
        //add the text box  for (int i = 1; i < lines.Length; i++)


        /// </summary>

        private void button10_Click(object sender, EventArgs e)
        {
            //if (courses == null)
            //    courses = SeedData.SeedCourses();

            using (Form dlg = new Form())
            {
                dlg.Text = "Add a Learner";
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.MinimizeBox = false;
                dlg.MaximizeBox = false;

                int top = 15;

                TextBox txtFirst = AddTextRow(dlg, "First Name", ref top);
                TextBox txtLast = AddTextRow(dlg, "Last Name", ref top);

                // Course dropdown
                dlg.Controls.Add(new Label { Text = "Course", Left = 15, Top = top + 3, Width = 130 });
                ComboBox cmbCourse = new ComboBox
                {
                    Left = 150,
                    Top = top,
                    Width = 220,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                dlg.Controls.Add(cmbCourse);
                cmbCourse.DataSource = courses;
                cmbCourse.DisplayMember = "Name";
                cmbCourse.ValueMember = "Code";
                cmbCourse.Format += (s, ev) =>
                {
                    if (ev.ListItem is Course c) ev.Value = $"{c.Code} - {c.Name}";
                };
                top += 35;

                // 5 assessment marks
                TextBox[] markBoxes = new TextBox[5];
                for (int i = 0; i < markBoxes.Length; i++)
                    markBoxes[i] = AddTextRow(dlg, $"Assessment Mark {i + 1}", ref top);

                // Buttons
                Button btnSave = new Button { Text = "Save", Left = 210, Top = top + 10, Width = 75 };
                Button btnCancel = new Button { Text = "Cancel", Left = 295, Top = top + 10, Width = 75, DialogResult = DialogResult.Cancel };
                dlg.Controls.AddRange(new Control[] { btnSave, btnCancel });

                dlg.AcceptButton = btnSave;
                dlg.CancelButton = btnCancel;
                dlg.ClientSize = new Size(390, top + 55);


                // No course preselected
                dlg.Shown += (s, ev) => cmbCourse.SelectedIndex = -1;

                // Only close if the save worked
                btnSave.Click += (s, ev) =>
                {
                    if (SaveLearner(txtFirst, txtLast, cmbCourse, markBoxes))
                        dlg.DialogResult = DialogResult.OK;
                };

                dlg.ShowDialog(this);
            }
        }

        // Validate and write to learners.txt. Returns true if saved.
        private bool SaveLearner(TextBox txtFirst, TextBox txtLast, ComboBox cmbCourse, TextBox[] markBoxes)
        {
            string firstName = txtFirst.Text.Trim();
            string lastName = txtLast.Text.Trim();

            if (firstName == "")
            {
                ShowWarning("Please enter a first name.", txtFirst);
                return false;
            }

            if (lastName == "")
            {
                ShowWarning("Please enter a last name.", txtLast);
                return false;
            }

            if (cmbCourse.SelectedIndex < 0)
            {
                ShowWarning("Please select a course.", cmbCourse);
                return false;
            }

            int course = cmbCourse.SelectedIndex;  

            int[] marks = new int[markBoxes.Length];
            for (int i = 0; i < markBoxes.Length; i++)
            {
                if (!int.TryParse(markBoxes[i].Text.Trim(), out marks[i]) || marks[i] < 0 || marks[i] > 100)
                {
                    ShowWarning($"Assessment mark {i + 1} must be a whole number from 0 to 100.", markBoxes[i]);
                    return false;
                }
            }

            try
            {
                int nextNumber = 1;
                string prefix = "";

                if (File.Exists("learners.txt"))
                {
                    string existing = File.ReadAllText("learners.txt");

                    // Next ID = highest existing ID + 1
                    int maxId = existing
                        .Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
                        .Select(l => int.TryParse(l.Split(',')[0], out int n) ? n : 0)
                        .DefaultIfEmpty(0)
                        .Max();

                    nextNumber = maxId + 1;

                    if (existing.Length > 0 && !existing.EndsWith("\n"))
                        prefix = Environment.NewLine;
                }
                //
                string line = $"{nextNumber},{firstName},{lastName},{course},{string.Join(",", marks)}";
                File.AppendAllText("learners.txt", prefix + line + Environment.NewLine);

                MessageBox.Show($"Learner {nextNumber} saved.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Adds a label + textbox row and moves down
        private static TextBox AddTextRow(Form form, string label, ref int top)
        {
            form.Controls.Add(new Label { Text = label, Left = 15, Top = top + 3, Width = 130 });
            TextBox tb = new TextBox { Left = 150, Top = top, Width = 220 };
            form.Controls.Add(tb);
            top += 35;
            return tb;
        }
        // 
        private static void ShowWarning(string message, Control focusControl)
        {
            MessageBox.Show(message, "Check Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            focusControl.Focus();
        }

        //Add lecturer Button
        private void button11_Click(object sender, EventArgs e)
        {

            using (Form dlg = new Form())
            {
                dlg.Text = "Add a Lecturer";
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.MinimizeBox = false;
                dlg.MaximizeBox = false;

                int top = 15;

                TextBox txtFirst = AddTextRow(dlg, "First Name", ref top);
                TextBox txtLast = AddTextRow(dlg, "Last Name", ref top);

                // Position dropdown from the enum
                dlg.Controls.Add(new Label { Text = "Position", Left = 15, Top = top + 3, Width = 130 });
                ComboBox cmbPosition = new ComboBox
                {
                    Left = 150,
                    Top = top,
                    Width = 220,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                foreach (Eposition p in Enum.GetValues(typeof(Eposition)))
                    cmbPosition.Items.Add($"{(int)p} - {p.ToString().Replace("_", " ")}");
                dlg.Controls.Add(cmbPosition);
                top += 35;

                // Salary – read-only, filled from the position
                TextBox txtSalary = AddTextRow(dlg, "Salary", ref top);
                txtSalary.ReadOnly = true;
                txtSalary.TabStop = false;

                cmbPosition.SelectedIndexChanged += (s, ev) =>
                {
                    if (cmbPosition.SelectedIndex < 0) { txtSalary.Clear(); return; }
                    Eposition pos = (Eposition)cmbPosition.SelectedIndex;
                    ESalary sal = (ESalary)Enum.Parse(typeof(ESalary), pos + "_Salary");
                    txtSalary.Text = $"${(int)sal:N0}";
                };

                // Course dropdown
                dlg.Controls.Add(new Label { Text = "Course", Left = 15, Top = top + 3, Width = 130 });
                ComboBox cmbCourse = new ComboBox
                {
                    Left = 150,
                    Top = top,
                    Width = 220,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                dlg.Controls.Add(cmbCourse);
                cmbCourse.DataSource = courses;
                cmbCourse.DisplayMember = "Name";
                cmbCourse.Format += (s, ev) =>
                {
                    if (ev.ListItem is Course c) ev.Value = $"{courses.IndexOf(c)} - {c.Name}";
                };
                top += 35;

                // Buttons
                Button btnSave = new Button { Text = "Save", Left = 210, Top = top + 10, Width = 75 };
                Button btnCancel = new Button { Text = "Cancel", Left = 295, Top = top + 10, Width = 75, DialogResult = DialogResult.Cancel };
                dlg.Controls.AddRange(new Control[] { btnSave, btnCancel });

                dlg.AcceptButton = btnSave;
                dlg.CancelButton = btnCancel;
                dlg.ClientSize = new Size(390, top + 55);

                dlg.Shown += (s, ev) => cmbCourse.SelectedIndex = -1;

                btnSave.Click += (s, ev) =>
                {
                    if (SaveLecturer(txtFirst, txtLast, cmbPosition, cmbCourse))
                        dlg.DialogResult = DialogResult.OK;
                };

                dlg.ShowDialog(this);
            }
        }

        // Validate and write to lecturers.txt. Returns true if saved.
        private bool SaveLecturer(TextBox txtFirst, TextBox txtLast, ComboBox cmbPosition, ComboBox cmbCourse)
        {
            string firstName = txtFirst.Text.Trim();
            string lastName = txtLast.Text.Trim();

            if (firstName == "")
            {
                ShowWarning("Please enter a first name.", txtFirst);
                return false;
            }

            if (lastName == "")
            {
                ShowWarning("Please enter a last name.", txtLast);
                return false;
            }

            if (cmbPosition.SelectedIndex < 0)
            {
                ShowWarning("Please select a position.", cmbPosition);
                return false;
            }

            if (cmbCourse.SelectedIndex < 0)
            {
                ShowWarning("Please select a course.", cmbCourse);
                return false;
            }

            Eposition position = (Eposition)cmbPosition.SelectedIndex;
            ESalary salary = (ESalary)Enum.Parse(typeof(ESalary), position + "_Salary");

            int positionIndex = cmbPosition.SelectedIndex;
            string positionName = position.ToString().Replace("_", " ");
            int course = cmbCourse.SelectedIndex;

            try
            {
                int nextNumber = 1;
                string prefix = "";

                if (File.Exists("lecturers.txt"))
                {
                    string existing = File.ReadAllText("lecturers.txt");

                    // Next ID = highest existing ID + 1
                    int maxId = existing
                        .Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
                        .Select(l => int.TryParse(l.Split(',')[0], out int n) ? n : 0)
                        .DefaultIfEmpty(0)
                        .Max();

                    nextNumber = maxId + 1;

                    if (existing.Length > 0 && !existing.EndsWith("\n"))
                        prefix = Environment.NewLine;
                }

                string line = $"{nextNumber},{firstName},{lastName},{positionIndex},{(int)salary},{course}";
                File.AppendAllText("lecturers.txt", prefix + line + Environment.NewLine);

                MessageBox.Show($"Lecturer {nextNumber} saved.\n{positionName}: ${(int)salary:N0}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //delete lecturers

        private void button12_Click(object sender, EventArgs e)
        {
            if (!File.Exists("lecturers.txt"))
            {
                MessageBox.Show("No records found.", "Remove Lecturer",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (Form dlg = new Form())
            {
                dlg.Text = "Remove a Lecturer";
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.MinimizeBox = false;
                dlg.MaximizeBox = false;

                int top = 15;

                // ID + Search
                dlg.Controls.Add(new Label { Text = "Lecturer ID", Left = 15, Top = top + 3, Width = 130 });
                TextBox txtId = new TextBox { Left = 150, Top = top, Width = 130 };
                Button btnSearch = new Button { Text = "Search", Left = 290, Top = top - 1, Width = 80 };
                dlg.Controls.AddRange(new Control[] { txtId, btnSearch });
                top += 45;

                // Read-only details
                TextBox txtFirst = AddTextRow(dlg, "First Name", ref top);
                TextBox txtLast = AddTextRow(dlg, "Last Name", ref top);
                TextBox txtPosition = AddTextRow(dlg, "Position", ref top);
                TextBox txtSalary = AddTextRow(dlg, "Salary", ref top);
                TextBox txtCourse = AddTextRow(dlg, "Course", ref top);

                TextBox[] details = { txtFirst, txtLast, txtPosition, txtSalary, txtCourse };
                foreach (TextBox tb in details)
                {
                    tb.ReadOnly = true;
                    tb.TabStop = false;
                }

                // Buttons
                Button btnRemove = new Button { Text = "Remove", Left = 210, Top = top + 10, Width = 75, Enabled = false };
                Button btnClose = new Button { Text = "Close", Left = 295, Top = top + 10, Width = 75, DialogResult = DialogResult.Cancel };
                dlg.Controls.AddRange(new Control[] { btnRemove, btnClose });

                dlg.AcceptButton = btnSearch;   // Enter = Search
                dlg.CancelButton = btnClose;
                dlg.ClientSize = new Size(390, top + 55);

                string foundLine = null;   // the line currently shown

                // Clear details if the ID is changed after a search
                txtId.TextChanged += (s, ev) =>
                {
                    foundLine = null;
                    btnRemove.Enabled = false;
                    foreach (TextBox tb in details) tb.Clear();
                };

                btnSearch.Click += (s, ev) =>
                {
                    if (!int.TryParse(txtId.Text.Trim(), out int id) || id < 1)
                    {
                        ShowWarning("Please enter a valid lecturer ID.", txtId);
                        return;
                    }

                    try
                    {
                        string match = File.ReadAllLines("lecturers.txt").FirstOrDefault(l => int.TryParse(l.Split(',')[0], out int lineId) && lineId == id);

                        if (match == null)
                        {
                            ShowWarning($"Lecturer ID {id} not found.", txtId);
                            return;
                        }

                        // Format: id,first,last,position,salary,course
                        string[] p = match.Split(',');

                        txtFirst.Text = p.Length > 1 ? p[1] : "";
                        txtLast.Text = p.Length > 2 ? p[2] : "";
                        txtPosition.Text = p.Length > 3 ? p[3].Replace("_", " ") : "";
                        txtSalary.Text = p.Length > 4 && int.TryParse(p[4], out int sal) ? $"${sal:N0}" : (p.Length > 4 ? p[4] : "");

                        if (p.Length > 5 && int.TryParse(p[5], out int ci) && ci >= 0 && ci < courses.Count)
                            txtCourse.Text = $"{ci} - {courses[ci].Name}";
                        else
                            txtCourse.Text = p.Length > 5 ? p[5] : "";

                        foundLine = match;
                        btnRemove.Enabled = true;
                        btnRemove.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not search: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                btnRemove.Click += (s, ev) =>
                {
                    if (foundLine == null) return;

                    var confirm = MessageBox.Show(
                        $"Remove {txtFirst.Text} {txtLast.Text} (ID {txtId.Text.Trim()})?",
                        "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm != DialogResult.Yes) return;

                    try
                    {
                        var lines = File.ReadAllLines("lecturers.txt")
                                        .Where(l => !string.IsNullOrWhiteSpace(l))
                                        .ToList();

                        lines.Remove(foundLine);
                        File.WriteAllLines("lecturers.txt", lines);

                        MessageBox.Show($"Lecturer ID {txtId.Text.Trim()} removed.", "Remove Lecturer",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dlg.DialogResult = DialogResult.OK;   // close the form
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not remove: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                dlg.ShowDialog(this);
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {

        }
        private void button14_Click(object sender, EventArgs e)
        {

        }

        private string PromptRequired(string text, string caption)
        {
            while (true)
            {
                string value = Prompt(text, caption);
                if (value == null) return null;
                if (!string.IsNullOrWhiteSpace(value)) return value.Trim();

                MessageBox.Show("This field is required.", caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int? PromptInt(string text, string caption, int min, int max)
        {
            while (true)
            {
                string value = Prompt(text, caption);
                if (value == null) return null;

                if (int.TryParse(value.Trim(), out int number) && number >= min && number <= max)
                    return number;

                MessageBox.Show($"Please enter a whole number from {min} to {max}.", caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private static string Prompt(string text, string caption)
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 350;
                prompt.Height = 160;
                prompt.Text = caption;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.StartPosition = FormStartPosition.CenterParent;
                prompt.MinimizeBox = false;
                prompt.MaximizeBox = false;

                Label lbl = new Label { Left = 15, Top = 15, Width = 300, Text = text };
                TextBox txt = new TextBox { Left = 15, Top = 40, Width = 300 };
                Button ok = new Button { Text = "OK", Left = 155, Width = 75, Top = 75, DialogResult = DialogResult.OK };
                Button cancel = new Button { Text = "Cancel", Left = 240, Width = 75, Top = 75, DialogResult = DialogResult.Cancel };

                prompt.Controls.AddRange(new Control[] { lbl, txt, ok, cancel });
                prompt.AcceptButton = ok;
                prompt.CancelButton = cancel;

                return prompt.ShowDialog() == DialogResult.OK ? txt.Text : null;
            }
        }

    }
}
