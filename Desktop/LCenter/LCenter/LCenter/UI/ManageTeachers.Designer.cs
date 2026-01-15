namespace LCenter.UI
{
    partial class ManageTeachers
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
            grpInfo = new GroupBox();
            btnEdit = new Button();
            chkActive = new CheckBox();
            label7 = new Label();
            txtSpec = new TextBox();
            label6 = new Label();
            txtPhone = new TextBox();
            label5 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            txtName = new TextBox();
            label3 = new Label();
            txtUsername = new TextBox();
            label2 = new Label();
            btnRefresh = new Button();
            btnAdd = new Button();
            txtSearch = new TextBox();
            label8 = new Label();
            btnQuaylai = new Button();
            dgvTeachers = new DataGridView();
            label9 = new Label();
            grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTeachers).BeginInit();
            SuspendLayout();
            // 
            // grpInfo
            // 
            grpInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpInfo.Controls.Add(btnEdit);
            grpInfo.Controls.Add(chkActive);
            grpInfo.Controls.Add(label7);
            grpInfo.Controls.Add(txtSpec);
            grpInfo.Controls.Add(label6);
            grpInfo.Controls.Add(txtPhone);
            grpInfo.Controls.Add(label5);
            grpInfo.Controls.Add(txtEmail);
            grpInfo.Controls.Add(label4);
            grpInfo.Controls.Add(txtName);
            grpInfo.Controls.Add(label3);
            grpInfo.Controls.Add(txtUsername);
            grpInfo.Controls.Add(label2);
            grpInfo.Controls.Add(btnRefresh);
            grpInfo.Controls.Add(btnAdd);
            grpInfo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpInfo.Location = new Point(12, 173);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(520, 876);
            grpInfo.TabIndex = 0;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin Giảng viên";
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(6, 731);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(89, 46);
            btnEdit.TabIndex = 14;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click_1;
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Checked = true;
            chkActive.CheckState = CheckState.Checked;
            chkActive.Location = new Point(165, 641);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(221, 36);
            chkActive.TabIndex = 6;
            chkActive.Text = "Đang hoạt động";
            chkActive.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 645);
            label7.Name = "label7";
            label7.Size = new Size(125, 32);
            label7.TabIndex = 13;
            label7.Text = "Trạng thái:";
            // 
            // txtSpec
            // 
            txtSpec.Location = new Point(165, 546);
            txtSpec.Name = "txtSpec";
            txtSpec.Size = new Size(327, 39);
            txtSpec.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(0, 553);
            label6.Name = "label6";
            label6.Size = new Size(157, 32);
            label6.TabIndex = 11;
            label6.Text = "Chuyên môn:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(165, 439);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(327, 39);
            txtPhone.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(-1, 442);
            label5.Name = "label5";
            label5.Size = new Size(130, 32);
            label5.TabIndex = 9;
            label5.Text = "Điện thoại:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(165, 323);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(327, 39);
            txtEmail.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 330);
            label4.Name = "label4";
            label4.Size = new Size(76, 32);
            label4.TabIndex = 7;
            label4.Text = "Email:";
            // 
            // txtName
            // 
            txtName.Location = new Point(165, 113);
            txtName.Name = "txtName";
            txtName.Size = new Size(327, 39);
            txtName.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 220);
            label3.Name = "label3";
            label3.Size = new Size(123, 32);
            label3.TabIndex = 5;
            label3.Text = "Họ và tên:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(165, 217);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(327, 39);
            txtUsername.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(-4, 113);
            label2.Name = "label2";
            label2.Size = new Size(126, 32);
            label2.TabIndex = 3;
            label2.Text = "Username:";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(359, 736);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(133, 41);
            btnRefresh.TabIndex = 9;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.ControlLight;
            btnAdd.ForeColor = Color.Black;
            btnAdd.Location = new Point(177, 735);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 42);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.Location = new Point(791, 138);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(593, 39);
            txtSearch.TabIndex = 11;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(538, 145);
            label8.Name = "label8";
            label8.Size = new Size(229, 32);
            label8.TabIndex = 12;
            label8.Text = "Tìm kiếm (SĐT/Tên):";
            // 
            // btnQuaylai
            // 
            btnQuaylai.Location = new Point(1555, 12);
            btnQuaylai.Name = "btnQuaylai";
            btnQuaylai.Size = new Size(236, 40);
            btnQuaylai.TabIndex = 14;
            btnQuaylai.Text = "Quay lại Dashboard";
            btnQuaylai.UseVisualStyleBackColor = true;
            btnQuaylai.Click += btnQuaylai_Click;
            // 
            // dgvTeachers
            // 
            dgvTeachers.BackgroundColor = SystemColors.ControlLightLight;
            dgvTeachers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTeachers.Location = new Point(558, 192);
            dgvTeachers.Name = "dgvTeachers";
            dgvTeachers.RowHeadersWidth = 82;
            dgvTeachers.Size = new Size(1224, 857);
            dgvTeachers.TabIndex = 15;
            dgvTeachers.CellClick += dgvTeachers_CellClick_1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.SteelBlue;
            label9.Location = new Point(417, 52);
            label9.Name = "label9";
            label9.Size = new Size(990, 59);
            label9.TabIndex = 16;
            label9.Text = "HỆ THỐNG QUẢN LÝ TRUNG TÂM NGOẠI NGỮ ";
            // 
            // ManageTeachers
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1803, 1061);
            Controls.Add(label9);
            Controls.Add(dgvTeachers);
            Controls.Add(btnQuaylai);
            Controls.Add(label8);
            Controls.Add(txtSearch);
            Controls.Add(grpInfo);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "ManageTeachers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Giảng Viên";
            Load += ManageTeachers_Load;
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTeachers).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSpec;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label8;
        private Button btnQuaylai;
        private DataGridView dgvTeachers;
        private Label label9;
        private Button btnEdit;
    }
}
