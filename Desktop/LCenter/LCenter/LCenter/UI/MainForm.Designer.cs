namespace LCenter
{
    partial class MainForm
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
            flowPanelMenu = new FlowLayoutPanel();
            btnGiangVien = new Button();
            btnHocVien = new Button();
            btnLophoc = new Button();
            btnKhoaHoc = new Button();
            btnLogout = new Button();
            menuStrip1 = new MenuStrip();
            panel1 = new Panel();
            lblTenUser = new Label();
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            dgvTopStudents = new DataGridView();
            lblWelcome = new Label();
            lblTotalStudents = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            flowPanelMenu.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopStudents).BeginInit();
            SuspendLayout();
            // 
            // flowPanelMenu
            // 
            flowPanelMenu.Controls.Add(btnGiangVien);
            flowPanelMenu.Controls.Add(btnHocVien);
            flowPanelMenu.Controls.Add(btnLophoc);
            flowPanelMenu.Controls.Add(btnKhoaHoc);
            flowPanelMenu.Controls.Add(btnLogout);
            flowPanelMenu.Controls.Add(menuStrip1);
            flowPanelMenu.Dock = DockStyle.Top;
            flowPanelMenu.Location = new Point(0, 0);
            flowPanelMenu.Name = "flowPanelMenu";
            flowPanelMenu.Size = new Size(1553, 932);
            flowPanelMenu.TabIndex = 0;
            // 
            // btnGiangVien
            // 
            btnGiangVien.BackColor = SystemColors.ControlLight;
            btnGiangVien.Location = new Point(3, 3);
            btnGiangVien.Name = "btnGiangVien";
            btnGiangVien.Size = new Size(299, 59);
            btnGiangVien.TabIndex = 1;
            btnGiangVien.Text = "Hồ sơ giảng viên";
            btnGiangVien.UseVisualStyleBackColor = false;
            btnGiangVien.Click += btnGiangVien_Click;
            // 
            // btnHocVien
            // 
            btnHocVien.Location = new Point(308, 3);
            btnHocVien.Name = "btnHocVien";
            btnHocVien.Size = new Size(285, 59);
            btnHocVien.TabIndex = 3;
            btnHocVien.Text = "Hồ sơ học viên";
            btnHocVien.UseVisualStyleBackColor = true;
            btnHocVien.Click += btnHocVien_Click;
            // 
            // btnLophoc
            // 
            btnLophoc.Location = new Point(599, 3);
            btnLophoc.Name = "btnLophoc";
            btnLophoc.Size = new Size(298, 59);
            btnLophoc.TabIndex = 5;
            btnLophoc.Text = "Quản lý lớp học";
            btnLophoc.UseVisualStyleBackColor = true;
            btnLophoc.Click += btnLophoc_Click;
            // 
            // btnKhoaHoc
            // 
            btnKhoaHoc.Location = new Point(903, 3);
            btnKhoaHoc.Name = "btnKhoaHoc";
            btnKhoaHoc.Size = new Size(330, 59);
            btnKhoaHoc.TabIndex = 2;
            btnKhoaHoc.Text = "Quản lý khóa học";
            btnKhoaHoc.UseVisualStyleBackColor = true;
            btnKhoaHoc.Click += btnKhoaHoc_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(1239, 3);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(302, 59);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Location = new Point(0, 65);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(202, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // panel1
            // 
            panel1.Controls.Add(lblTenUser);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dgvTopStudents);
            panel1.Controls.Add(lblWelcome);
            panel1.Controls.Add(lblTotalStudents);
            panel1.Location = new Point(0, 68);
            panel1.Name = "panel1";
            panel1.Size = new Size(1553, 864);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // lblTenUser
            // 
            lblTenUser.AutoSize = true;
            lblTenUser.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTenUser.ForeColor = SystemColors.InfoText;
            lblTenUser.Location = new Point(414, 151);
            lblTenUser.Name = "lblTenUser";
            lblTenUser.Size = new Size(0, 37);
            lblTenUser.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.InfoText;
            label4.Location = new Point(291, 151);
            label4.Name = "label4";
            label4.Size = new Size(0, 37);
            label4.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(378, 49);
            label1.Name = "label1";
            label1.Size = new Size(836, 50);
            label1.TabIndex = 4;
            label1.Text = "HỆ THỐNG QUẢN LÝ TRUNG TÂM NGOẠI NGỮ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Highlight;
            label2.Location = new Point(29, 237);
            label2.Name = "label2";
            label2.Size = new Size(506, 37);
            label2.TabIndex = 2;
            label2.Text = "Top 10 học viên xuất sắc tại trung tâm";
            // 
            // dgvTopStudents
            // 
            dgvTopStudents.BackgroundColor = SystemColors.ButtonFace;
            dgvTopStudents.BorderStyle = BorderStyle.None;
            dgvTopStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTopStudents.Location = new Point(29, 295);
            dgvTopStudents.Name = "dgvTopStudents";
            dgvTopStudents.RowHeadersWidth = 82;
            dgvTopStudents.Size = new Size(799, 535);
            dgvTopStudents.TabIndex = 1;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = SystemColors.Highlight;
            lblWelcome.Location = new Point(590, 114);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(117, 37);
            lblWelcome.TabIndex = 7;
            lblWelcome.Text = "xinchao";
            // 
            // lblTotalStudents
            // 
            lblTotalStudents.AutoSize = true;
            lblTotalStudents.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalStudents.ForeColor = Color.Red;
            lblTotalStudents.Location = new Point(29, 185);
            lblTotalStudents.Name = "lblTotalStudents";
            lblTotalStudents.Size = new Size(33, 37);
            lblTotalStudents.TabIndex = 0;
            lblTotalStudents.Text = "0";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1553, 932);
            Controls.Add(panel1);
            Controls.Add(flowPanelMenu);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "DashBoard";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            flowPanelMenu.ResumeLayout(false);
            flowPanelMenu.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopStudents).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowPanelMenu;
        private Panel panel1;
        private Label lblTotalStudents;
        private Button button1;
        private Label label2;
        private DataGridView dgvTopStudents;
        private Button btnGiangVien;
        private Button btnKhoaHoc;
        private Button btnHocVien;
        private Button btnLophoc;
        private Label label1;
        private Label lblTenUser;
        private Label label4;
        private Label lblWelcome;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Button btnLogout;
        private MenuStrip menuStrip1;
    }
}