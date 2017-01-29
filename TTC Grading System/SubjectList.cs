using MySql.Connection;
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
    public partial class SubjectList : Form
    {
        public SubjectList()
        {
            InitializeComponent();
        }

        List<Subject> subjects = new List<Subject>();
        List<Batch> batches = new List<Batch>();
        internal Subject subject = new Subject();
        internal Batch batch = new Batch();
        internal CProgram program = new CProgram();

        private void SubjectList_Load(object sender, EventArgs e)
        {
            Builder.UserID = Properties.Settings.Default.UserID;
            Builder.Password = Properties.Settings.Default.Password;
            Builder.Database = Properties.Settings.Default.Database;
            Builder.Server = Properties.Settings.Default.Server;
            Builder.Port = Properties.Settings.Default.Port;
        }

        private void dgvSubjects_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSubjects.SelectedRows.Count > 0)
            {
                int ID = Convert.ToInt32(dgvSubjects.SelectedRows[0].Cells[0].Value);
                subject = subjects.Find(s => s.ID == ID);
                batches = Batch.GetAllByProgram(subject.ProgramID);
                dgvBatches.Rows.Clear();
                foreach (Batch batch in batches)
                {
                    dgvBatches.Rows.Add(batch.ID, batch.Number);
                }
                dgvBatches.ClearSelection();
            }
            else
            {
                dgvBatches.Rows.Clear();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dgvSubjects.SelectedRows.Count > 0 && dgvBatches.SelectedRows.Count > 0)
            {
                int SubjectID = Convert.ToInt32(dgvSubjects.SelectedRows[0].Cells[0].Value);
                int BatchID = Convert.ToInt32(dgvBatches.SelectedRows[0].Cells[0].Value);
                subject = subjects.Find(s => s.ID == SubjectID);
                batch = batches.Find(b => b.ID == BatchID);
                Input inp = new Input(this);
                inp.subject = subject;
                inp.batch = batch;
                inp.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select subject and batch.");
            }
        }

        private void btnChangeCourse_Click(object sender, EventArgs e)
        {
            ChooseProgram vCProgram = new ChooseProgram();
            vCProgram.ShowDialog();
            program = vCProgram.program;
            if (program != null) LoadProgram();
        }

        private void LoadProgram()
        {
            txtProgramTitle.Text = program.Title;
            subjects = Subject.getAllByProgram(program.ID);
            dgvSubjects.Rows.Clear();
            foreach (Subject subject in subjects)
            {
                dgvSubjects.Rows.Add(subject.ID, subject.Code, subject.Title);
            }
            dgvSubjects.ClearSelection();
        }

        private void chbChange_CheckedChanged(object sender, EventArgs e)
        {
            if (chbChange.Checked)
            {
                Builder.Database = "ttc_k12";
                chbChange.Text = "K-12";
            } 
            else
            {
                Builder.Database = "ttc_students";
                chbChange.Text = "TESDA";
            }
            LoadProgram();
        }
    }
}
