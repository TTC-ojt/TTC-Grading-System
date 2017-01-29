namespace TTC_Grading_System
{
    partial class ChooseProgram
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseProgram));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvChooseProgram = new System.Windows.Forms.DataGridView();
            this.colProgramID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProgramTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProgramDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChooseProgram)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dgvChooseProgram);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 364);
            this.panel1.TabIndex = 0;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSelect.AutoSize = true;
            this.btnSelect.BackColor = System.Drawing.Color.Silver;
            this.btnSelect.Enabled = false;
            this.btnSelect.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSelect.FlatAppearance.BorderSize = 2;
            this.btnSelect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.Location = new System.Drawing.Point(489, 300);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(5);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(74, 59);
            this.btnSelect.TabIndex = 37;
            this.btnSelect.Text = "SELECT";
            this.btnSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DarkGreen;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(5);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(5);
            this.label5.Size = new System.Drawing.Size(558, 33);
            this.label5.TabIndex = 35;
            this.label5.Text = "CHOOSE PROGRAM";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvChooseProgram
            // 
            this.dgvChooseProgram.AllowUserToAddRows = false;
            this.dgvChooseProgram.AllowUserToDeleteRows = false;
            this.dgvChooseProgram.AllowUserToResizeColumns = false;
            this.dgvChooseProgram.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChooseProgram.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChooseProgram.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChooseProgram.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProgramID,
            this.colProgramTitle,
            this.colProgramDuration});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChooseProgram.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChooseProgram.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvChooseProgram.Location = new System.Drawing.Point(5, 48);
            this.dgvChooseProgram.Margin = new System.Windows.Forms.Padding(5);
            this.dgvChooseProgram.MultiSelect = false;
            this.dgvChooseProgram.Name = "dgvChooseProgram";
            this.dgvChooseProgram.ReadOnly = true;
            this.dgvChooseProgram.RowHeadersVisible = false;
            this.dgvChooseProgram.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChooseProgram.Size = new System.Drawing.Size(558, 242);
            this.dgvChooseProgram.TabIndex = 36;
            this.dgvChooseProgram.SelectionChanged += new System.EventHandler(this.dgvChooseProgram_SelectionChanged);
            // 
            // colProgramID
            // 
            this.colProgramID.HeaderText = "ID";
            this.colProgramID.Name = "colProgramID";
            this.colProgramID.ReadOnly = true;
            this.colProgramID.Visible = false;
            // 
            // colProgramTitle
            // 
            this.colProgramTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProgramTitle.FillWeight = 55F;
            this.colProgramTitle.HeaderText = "Title";
            this.colProgramTitle.Name = "colProgramTitle";
            this.colProgramTitle.ReadOnly = true;
            // 
            // colProgramDuration
            // 
            this.colProgramDuration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProgramDuration.FillWeight = 20F;
            this.colProgramDuration.HeaderText = "Tuition";
            this.colProgramDuration.Name = "colProgramDuration";
            this.colProgramDuration.ReadOnly = true;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Silver;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(5, 301);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(61, 59);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "CLOSE";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ChooseProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(578, 374);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseProgram";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose Program";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ChooseProgram_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChooseProgram)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvChooseProgram;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProgramID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProgramTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProgramDuration;
        private System.Windows.Forms.Button btnClose;
    }
}