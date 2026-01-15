namespace LCenter.UI
{
    partial class ManageCourses
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            grpInfo = new GroupBox();
            numDuration = new NumericUpDown();
            numFee = new NumericUpDown();
            cboLevel = new ComboBox();
            txtDesc = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtId = new TextBox();
            label1 = new Label();
            btnRefresh = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            dgvCourses = new DataGridView();
            btnBack = new Button();
            label7 = new Label();
            grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numFee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).BeginInit();
            SuspendLayout();
            // 
            // grpInfo
            // 
            grpInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpInfo.Controls.Add(numDuration);
            grpInfo.Controls.Add(numFee);
            grpInfo.Controls.Add(cboLevel);
            grpInfo.Controls.Add(txtDesc);
            grpInfo.Controls.Add(label6);
            grpInfo.Controls.Add(label5);
            grpInfo.Controls.Add(label4);
            grpInfo.Controls.Add(txtName);
            grpInfo.Controls.Add(label3);
            grpInfo.Controls.Add(label2);
            grpInfo.Controls.Add(txtId);
            grpInfo.Controls.Add(label1);
            grpInfo.Controls.Add(btnRefresh);
            grpInfo.Controls.Add(btnDelete);
            grpInfo.Controls.Add(btnEdit);
            grpInfo.Controls.Add(btnAdd);
            grpInfo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpInfo.Location = new Point(12, 163);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(530, 922);
            grpInfo.TabIndex = 1;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin Khóa học";
            // 
            // numDuration
            // 
            numDuration.Location = new Point(160, 521);
            numDuration.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numDuration.Name = "numDuration";
            numDuration.Size = new Size(364, 39);
            numDuration.TabIndex = 4;
            // 
            // numFee
            // 
            numFee.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            numFee.Location = new Point(160, 414);
            numFee.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numFee.Name = "numFee";
            numFee.Size = new Size(364, 39);
            numFee.TabIndex = 3;
            // 
            // cboLevel
            // 
            cboLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLevel.FormattingEnabled = true;
            cboLevel.Location = new Point(160, 310);
            cboLevel.Name = "cboLevel";
            cboLevel.Size = new Size(364, 40);
            cboLevel.TabIndex = 2;
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(160, 623);
            txtDesc.Multiline = true;
            txtDesc.Name = "txtDesc";
            txtDesc.ScrollBars = ScrollBars.Vertical;
            txtDesc.Size = new Size(364, 35);
            txtDesc.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 626);
            label6.Name = "label6";
            label6.Size = new Size(82, 32);
            label6.TabIndex = 11;
            label6.Text = "Mô tả:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(0, 528);
            label5.Name = "label5";
            label5.Size = new Size(135, 32);
            label5.TabIndex = 9;
            label5.Text = "Thời lượng:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 421);
            label4.Name = "label4";
            label4.Size = new Size(102, 32);
            label4.TabIndex = 7;
            label4.Text = "Học phí:";
            // 
            // txtName
            // 
            txtName.Location = new Point(160, 196);
            txtName.Name = "txtName";
            txtName.Size = new Size(364, 39);
            txtName.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(0, 318);
            label3.Name = "label3";
            label3.Size = new Size(107, 32);
            label3.TabIndex = 5;
            label3.Text = "Trình độ:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(0, 203);
            label2.Name = "label2";
            label2.Size = new Size(95, 32);
            label2.TabIndex = 3;
            label2.Text = "Tên KH:";
            // 
            // txtId
            // 
            txtId.BackColor = Color.WhiteSmoke;
            txtId.Location = new Point(160, 88);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(364, 39);
            txtId.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 95);
            label1.Name = "label1";
            label1.Size = new Size(91, 32);
            label1.TabIndex = 1;
            label1.Text = "Mã KH:";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(376, 737);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(119, 40);
            btnRefresh.TabIndex = 9;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click_1;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(139, 735);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(89, 45);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(17, 735);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 46);
            btnEdit.TabIndex = 8;
            btnEdit.Text = "Sửa";
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.ForestGreen;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(245, 735);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(107, 45);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvCourses
            // 
            dgvCourses.AllowUserToAddRows = false;
            dgvCourses.AllowUserToDeleteRows = false;
            dgvCourses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCourses.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Navy;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCourses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCourses.ColumnHeadersHeight = 35;
            dgvCourses.EnableHeadersVisualStyles = false;
            dgvCourses.Location = new Point(548, 180);
            dgvCourses.MultiSelect = false;
            dgvCourses.Name = "dgvCourses";
            dgvCourses.ReadOnly = true;
            dgvCourses.RowHeadersVisible = false;
            dgvCourses.RowHeadersWidth = 82;
            dgvCourses.RowTemplate.Height = 25;
            dgvCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCourses.Size = new Size(1125, 905);
            dgvCourses.TabIndex = 2;
            dgvCourses.CellClick += dgvCourses_CellClick;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBack.BackColor = Color.Gray;
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(1415, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(258, 43);
            btnBack.TabIndex = 3;
            btnBack.Text = "Quay lại Dashboard";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.SteelBlue;
            label7.Location = new Point(301, 50);
            label7.Name = "label7";
            label7.Size = new Size(990, 59);
            label7.TabIndex = 7;
            label7.Text = "HỆ THỐNG QUẢN LÝ TRUNG TÂM NGOẠI NGỮ ";
            // 
            // ManageCourses
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1687, 1096);
            Controls.Add(label7);
            Controls.Add(btnBack);
            Controls.Add(dgvCourses);
            Controls.Add(grpInfo);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "ManageCourses";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Khóa Học";
            Load += ManageCourses_Load;
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)numFee).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.ComboBox cboLevel;
        private System.Windows.Forms.NumericUpDown numFee;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvCourses;
        private System.Windows.Forms.Button btnBack;
        private Label label7;
    }
}