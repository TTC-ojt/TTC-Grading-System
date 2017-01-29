using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTC_Grading_System
{
    public partial class Input : Form
    {
        public Input(SubjectList sl)
        {
            InitializeComponent();
            this.sl = sl;
        }

        private SubjectList sl;

        internal Subject subject = new Subject();
        internal Batch batch = new Batch();
        List<Student> students = new List<Student>();
        List<Grade> grades = new List<Grade>();

        private void Input_Load(object sender, EventArgs e)
        {
            lblSubjectCode.Text = subject.Code;
            lblSubjectTitle.Text = subject.Title;
            lblBatchNumber.Text = batch.Number.ToString("D2");
            LoadGrades();
        }

        private void LoadGrades()
        {
            students = Student.getByBatch(batch.ID);
            grades = Grade.getBySubjectAndBatch(subject.ID, batch.ID);
            dgvStudents.Rows.Clear();
            foreach (Student student in students)
            {
                Grade grade = grades.Find(g => g.StudentID == student.ID);
                decimal score = grade != null ? grade.Score : 0;
                string remarks = grade != null ? grade.Remarks : "";
                dgvStudents.Rows.Add(student.ID, student.Number, student.GetFullName(), score.ToString("N"), remarks);
            }
            dgvStudents.ClearSelection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
            sl.Show();
        }
    }
}
