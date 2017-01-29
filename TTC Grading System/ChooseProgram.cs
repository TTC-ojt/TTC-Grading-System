using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TTC_Grading_System
{
    public partial class ChooseProgram : Form
    {
        public ChooseProgram()
        {
            InitializeComponent();
        }

        List<CProgram> programs;
        internal CProgram program = new CProgram();

        private void ChooseProgram_Load(object sender, EventArgs e)
        {
            programs = CProgram.getAll();
            dgvChooseProgram.Rows.Clear();
            foreach (var program in programs)
            {
                dgvChooseProgram.Rows.Add(program.ID, program.Title, program.Tuition);
            }
            dgvChooseProgram.ClearSelection();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvChooseProgram.SelectedRows[0].Cells[0].Value);
            program = programs.Find(p => p.ID == id);
            this.Close();
        }

        private void dgvChooseProgram_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvChooseProgram.SelectedRows.Count > 0)
            {
                btnSelect.Enabled = true;
            }
            else
            {
                btnSelect.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
