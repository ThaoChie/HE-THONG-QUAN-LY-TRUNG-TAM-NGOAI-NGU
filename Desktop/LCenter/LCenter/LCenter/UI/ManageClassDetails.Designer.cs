namespace LCenter.UI
{
    partial class ManageClassDetails
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
            lblClassName = new Label();
            btnBack = new Button();
            GhiDanh = new TabControl();
            tabPage1 = new TabPage();
            dgvStudents = new DataGridView();
            pnlEnrollBottom = new Panel();
            btnRemove = new Button();
            pnlEnrollTop = new Panel();
            btnBatch = new Button();
            txtPhoneLookup = new TextBox();
            btnLookup = new Button();
            btnAddStudent = new Button();
            lblStudentInfo = new Label();
            tabPage2 = new TabPage();
            dgvScores = new DataGridView();
            pnlScoreBottom = new Panel();
            btnAddColumn = new Button();
            btnExport = new Button();
            btnSaveScore = new Button();
            tabAttendance = new TabPage();
            dgvAttendance = new DataGridView();
            pnlAttBottom = new Panel();
            btnAddDate = new Button();
            btnSaveAttendance = new Button();
            GhiDanh.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            pnlEnrollBottom.SuspendLayout();
            pnlEnrollTop.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvScores).BeginInit();
            pnlScoreBottom.SuspendLayout();
            tabAttendance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).BeginInit();
            pnlAttBottom.SuspendLayout();
            SuspendLayout();
            // 
            // lblClassName
            // 
            lblClassName.AutoSize = true;
            lblClassName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblClassName.ForeColor = Color.SteelBlue;
            lblClassName.Location = new Point(26, 22);
            lblClassName.Margin = new Padding(6, 0, 6, 0);
            lblClassName.Name = "lblClassName";
            lblClassName.Size = new Size(233, 59);
            lblClassName.TabIndex = 0;
            lblClassName.Text = "Đang tải...";
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBack.Location = new Point(1713, 25);
            btnBack.Margin = new Padding(6, 7, 6, 7);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(248, 38);
            btnBack.TabIndex = 1;
            btnBack.Text = "Quay lại Dashboard";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click_1;
            // 
            // GhiDanh
            // 
            GhiDanh.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GhiDanh.Controls.Add(tabPage1);
            GhiDanh.Controls.Add(tabPage2);
            GhiDanh.Controls.Add(tabAttendance);
            GhiDanh.Location = new Point(26, 123);
            GhiDanh.Margin = new Padding(6, 7, 6, 7);
            GhiDanh.Name = "GhiDanh";
            GhiDanh.SelectedIndex = 0;
            GhiDanh.Size = new Size(1934, 1118);
            GhiDanh.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvStudents);
            tabPage1.Controls.Add(pnlEnrollBottom);
            tabPage1.Controls.Add(pnlEnrollTop);
            tabPage1.Location = new Point(8, 46);
            tabPage1.Margin = new Padding(6, 7, 6, 7);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(6, 7, 6, 7);
            tabPage1.Size = new Size(1918, 1064);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Ghi danh";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.BackgroundColor = Color.White;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Dock = DockStyle.Fill;
            dgvStudents.Location = new Point(6, 155);
            dgvStudents.Margin = new Padding(6, 7, 6, 7);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersWidth = 82;
            dgvStudents.Size = new Size(1906, 779);
            dgvStudents.TabIndex = 2;
            // 
            // pnlEnrollBottom
            // 
            pnlEnrollBottom.BackColor = Color.WhiteSmoke;
            pnlEnrollBottom.Controls.Add(btnBatch);
            pnlEnrollBottom.Controls.Add(btnRemove);
            pnlEnrollBottom.Dock = DockStyle.Bottom;
            pnlEnrollBottom.Location = new Point(6, 934);
            pnlEnrollBottom.Margin = new Padding(6, 7, 6, 7);
            pnlEnrollBottom.Name = "pnlEnrollBottom";
            pnlEnrollBottom.Size = new Size(1906, 123);
            pnlEnrollBottom.TabIndex = 1;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.IndianRed;
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(22, 31);
            btnRemove.Margin = new Padding(6, 7, 6, 7);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(197, 75);
            btnRemove.TabIndex = 0;
            btnRemove.Text = "Xóa khỏi lớp";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // pnlEnrollTop
            // 
            pnlEnrollTop.Controls.Add(txtPhoneLookup);
            pnlEnrollTop.Controls.Add(btnLookup);
            pnlEnrollTop.Controls.Add(btnAddStudent);
            pnlEnrollTop.Controls.Add(lblStudentInfo);
            pnlEnrollTop.Dock = DockStyle.Top;
            pnlEnrollTop.Location = new Point(6, 7);
            pnlEnrollTop.Margin = new Padding(6, 7, 6, 7);
            pnlEnrollTop.Name = "pnlEnrollTop";
            pnlEnrollTop.Size = new Size(1906, 148);
            pnlEnrollTop.TabIndex = 0;
            // 
            // btnBatch
            // 
            btnBatch.BackColor = Color.AliceBlue;
            btnBatch.Enabled = false;
            btnBatch.ForeColor = Color.Black;
            btnBatch.Location = new Point(253, 37);
            btnBatch.Margin = new Padding(6, 7, 6, 7);
            btnBatch.Name = "btnBatch";
            btnBatch.Size = new Size(272, 62);
            btnBatch.TabIndex = 3;
            btnBatch.Text = "Thêm học viên theo lô";
            btnBatch.UseVisualStyleBackColor = false;
            btnBatch.Click += btnBatch_Click;
            // 
            // txtPhoneLookup
            // 
            txtPhoneLookup.Location = new Point(22, 37);
            txtPhoneLookup.Margin = new Padding(6, 7, 6, 7);
            txtPhoneLookup.Name = "txtPhoneLookup";
            txtPhoneLookup.Size = new Size(1176, 39);
            txtPhoneLookup.TabIndex = 0;
            // 
            // btnLookup
            // 
            btnLookup.BackColor = Color.DodgerBlue;
            btnLookup.ForeColor = Color.White;
            btnLookup.Location = new Point(1225, 25);
            btnLookup.Margin = new Padding(6, 7, 6, 7);
            btnLookup.Name = "btnLookup";
            btnLookup.Size = new Size(145, 62);
            btnLookup.TabIndex = 1;
            btnLookup.Text = "Tìm";
            btnLookup.UseVisualStyleBackColor = false;
            btnLookup.Click += btnLookup_Click;
            // 
            // btnAddStudent
            // 
            btnAddStudent.BackColor = Color.ForestGreen;
            btnAddStudent.Enabled = false;
            btnAddStudent.ForeColor = Color.White;
            btnAddStudent.Location = new Point(1410, 25);
            btnAddStudent.Margin = new Padding(6, 7, 6, 7);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(137, 62);
            btnAddStudent.TabIndex = 2;
            btnAddStudent.Text = "Thêm ";
            btnAddStudent.UseVisualStyleBackColor = false;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // lblStudentInfo
            // 
            lblStudentInfo.AutoSize = true;
            lblStudentInfo.ForeColor = Color.DimGray;
            lblStudentInfo.Location = new Point(22, 103);
            lblStudentInfo.Margin = new Padding(6, 0, 6, 0);
            lblStudentInfo.Name = "lblStudentInfo";
            lblStudentInfo.Size = new Size(29, 32);
            lblStudentInfo.TabIndex = 3;
            lblStudentInfo.Text = "...";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvScores);
            tabPage2.Controls.Add(pnlScoreBottom);
            tabPage2.Location = new Point(8, 46);
            tabPage2.Margin = new Padding(6, 7, 6, 7);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(6, 7, 6, 7);
            tabPage2.Size = new Size(1918, 1064);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Chấm điểm";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvScores
            // 
            dgvScores.AllowUserToAddRows = false;
            dgvScores.BackgroundColor = Color.White;
            dgvScores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvScores.Dock = DockStyle.Fill;
            dgvScores.Location = new Point(6, 7);
            dgvScores.Margin = new Padding(6, 7, 6, 7);
            dgvScores.Name = "dgvScores";
            dgvScores.RowHeadersWidth = 82;
            dgvScores.Size = new Size(1906, 927);
            dgvScores.TabIndex = 1;
            dgvScores.CellEndEdit += dgvScores_CellEndEdit;
            // 
            // pnlScoreBottom
            // 
            pnlScoreBottom.BackColor = Color.WhiteSmoke;
            pnlScoreBottom.Controls.Add(btnAddColumn);
            pnlScoreBottom.Controls.Add(btnExport);
            pnlScoreBottom.Controls.Add(btnSaveScore);
            pnlScoreBottom.Dock = DockStyle.Bottom;
            pnlScoreBottom.Location = new Point(6, 934);
            pnlScoreBottom.Margin = new Padding(6, 7, 6, 7);
            pnlScoreBottom.Name = "pnlScoreBottom";
            pnlScoreBottom.Size = new Size(1906, 123);
            pnlScoreBottom.TabIndex = 0;
            // 
            // btnAddColumn
            // 
            btnAddColumn.BackColor = Color.Teal;
            btnAddColumn.ForeColor = Color.White;
            btnAddColumn.Location = new Point(22, 37);
            btnAddColumn.Margin = new Padding(6, 7, 6, 7);
            btnAddColumn.Name = "btnAddColumn";
            btnAddColumn.Size = new Size(223, 69);
            btnAddColumn.TabIndex = 0;
            btnAddColumn.Text = "Thêm Cột Điểm";
            btnAddColumn.UseVisualStyleBackColor = false;
            btnAddColumn.Click += btnAddColumn_Click;
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExport.BackColor = Color.SeaGreen;
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(1427, 37);
            btnExport.Margin = new Padding(6, 7, 6, 7);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(217, 69);
            btnExport.TabIndex = 1;
            btnExport.Text = "Xuất Excel";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnSaveScore
            // 
            btnSaveScore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveScore.BackColor = Color.Crimson;
            btnSaveScore.ForeColor = Color.White;
            btnSaveScore.Location = new Point(1657, 37);
            btnSaveScore.Margin = new Padding(6, 7, 6, 7);
            btnSaveScore.Name = "btnSaveScore";
            btnSaveScore.Size = new Size(217, 69);
            btnSaveScore.TabIndex = 2;
            btnSaveScore.Text = "Lưu Điểm";
            btnSaveScore.UseVisualStyleBackColor = false;
            btnSaveScore.Click += btnSaveScore_Click;
            // 
            // tabAttendance
            // 
            tabAttendance.Controls.Add(dgvAttendance);
            tabAttendance.Controls.Add(pnlAttBottom);
            tabAttendance.Location = new Point(8, 46);
            tabAttendance.Margin = new Padding(6, 7, 6, 7);
            tabAttendance.Name = "tabAttendance";
            tabAttendance.Padding = new Padding(6, 7, 6, 7);
            tabAttendance.Size = new Size(1918, 1064);
            tabAttendance.TabIndex = 2;
            tabAttendance.Text = "Điểm danh";
            tabAttendance.UseVisualStyleBackColor = true;
            // 
            // dgvAttendance
            // 
            dgvAttendance.AllowUserToAddRows = false;
            dgvAttendance.BackgroundColor = Color.White;
            dgvAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAttendance.Dock = DockStyle.Fill;
            dgvAttendance.Location = new Point(6, 7);
            dgvAttendance.Margin = new Padding(6, 7, 6, 7);
            dgvAttendance.Name = "dgvAttendance";
            dgvAttendance.RowHeadersWidth = 82;
            dgvAttendance.Size = new Size(1906, 927);
            dgvAttendance.TabIndex = 1;
            // 
            // pnlAttBottom
            // 
            pnlAttBottom.BackColor = Color.WhiteSmoke;
            pnlAttBottom.Controls.Add(btnAddDate);
            pnlAttBottom.Controls.Add(btnSaveAttendance);
            pnlAttBottom.Dock = DockStyle.Bottom;
            pnlAttBottom.Location = new Point(6, 934);
            pnlAttBottom.Margin = new Padding(6, 7, 6, 7);
            pnlAttBottom.Name = "pnlAttBottom";
            pnlAttBottom.Size = new Size(1906, 123);
            pnlAttBottom.TabIndex = 0;
            // 
            // btnAddDate
            // 
            btnAddDate.BackColor = Color.ForestGreen;
            btnAddDate.ForeColor = Color.White;
            btnAddDate.Location = new Point(22, 20);
            btnAddDate.Margin = new Padding(6, 7, 6, 7);
            btnAddDate.Name = "btnAddDate";
            btnAddDate.Size = new Size(247, 86);
            btnAddDate.TabIndex = 0;
            btnAddDate.Text = "Điểm danh hôm nay";
            btnAddDate.UseVisualStyleBackColor = false;
            btnAddDate.Click += btnAddDate_Click;
            // 
            // btnSaveAttendance
            // 
            btnSaveAttendance.BackColor = Color.SteelBlue;
            btnSaveAttendance.ForeColor = Color.White;
            btnSaveAttendance.Location = new Point(291, 20);
            btnSaveAttendance.Margin = new Padding(6, 7, 6, 7);
            btnSaveAttendance.Name = "btnSaveAttendance";
            btnSaveAttendance.Size = new Size(241, 86);
            btnSaveAttendance.TabIndex = 1;
            btnSaveAttendance.Text = "Lưu Điểm Danh";
            btnSaveAttendance.UseVisualStyleBackColor = false;
            btnSaveAttendance.Click += btnSaveAttendance_Click;
            // 
            // ManageClassDetails
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1986, 1270);
            Controls.Add(GhiDanh);
            Controls.Add(btnBack);
            Controls.Add(lblClassName);
            Margin = new Padding(6, 7, 6, 7);
            Name = "ManageClassDetails";
            Text = "Chi tiết lớp học";
            WindowState = FormWindowState.Maximized;
            Load += ManageClassDetails_Load;
            GhiDanh.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            pnlEnrollBottom.ResumeLayout(false);
            pnlEnrollTop.ResumeLayout(false);
            pnlEnrollTop.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvScores).EndInit();
            pnlScoreBottom.ResumeLayout(false);
            tabAttendance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).EndInit();
            pnlAttBottom.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TabControl GhiDanh;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabAttendance;
        private System.Windows.Forms.Panel pnlEnrollTop;
        private System.Windows.Forms.Panel pnlEnrollBottom;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtPhoneLookup;
        private System.Windows.Forms.Button btnLookup;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Label lblStudentInfo;
        private System.Windows.Forms.Panel pnlScoreBottom;
        private System.Windows.Forms.DataGridView dgvScores;
        private System.Windows.Forms.Button btnAddColumn;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSaveScore;
        private System.Windows.Forms.Panel pnlAttBottom;
        private System.Windows.Forms.DataGridView dgvAttendance;
        private System.Windows.Forms.Button btnAddDate;
        private System.Windows.Forms.Button btnSaveAttendance;
        private Button btnBatch;
    }
}