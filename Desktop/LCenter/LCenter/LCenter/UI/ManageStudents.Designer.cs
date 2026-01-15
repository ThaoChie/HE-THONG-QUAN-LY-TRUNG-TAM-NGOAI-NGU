namespace LCenter.UI
{
    partial class ManageStudents
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
            pnlHeader = new Panel();
            btnBackDb = new Button();
            lblTitle = new Label();
            linkLabelQuaylai = new LinkLabel();
            pnlLeft = new Panel();
            grpInfo = new GroupBox();
            flpActions = new FlowLayoutPanel();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnBatch = new Button();
            tlpInputs = new TableLayoutPanel();
            lblID = new Label();
            txtID = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblDOB = new Label();
            dtpDateOfBirth = new DateTimePicker();
            lblStatus = new Label();
            cboStatus = new ComboBox();
            btnRefresh = new Button();
            pnlMain = new Panel();
            dgvStudents = new DataGridView();
            pnlSearch = new Panel();
            btnTimKiem = new Button();
            txtSearchPhone = new TextBox();
            btnBack = new Button();
            pnlHeader.SuspendLayout();
            pnlLeft.SuspendLayout();
            grpInfo.SuspendLayout();
            flpActions.SuspendLayout();
            tlpInputs.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            pnlSearch.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(44, 62, 80);
            pnlHeader.Controls.Add(btnBackDb);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(linkLabelQuaylai);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1966, 60);
            pnlHeader.TabIndex = 0;
            // 
            // btnBackDb
            // 
            btnBackDb.Location = new Point(1540, 12);
            btnBackDb.Name = "btnBackDb";
            btnBackDb.Size = new Size(267, 42);
            btnBackDb.TabIndex = 2;
            btnBackDb.Text = "Quay lại Dashboard";
            btnBackDb.UseVisualStyleBackColor = true;
            btnBackDb.Click += btnBackDb_Click;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.SteelBlue;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1966, 60);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "HỆ THỐNG QUẢN LÝ TRUNG TÂM NGOẠI NGỮ";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // linkLabelQuaylai
            // 
            linkLabelQuaylai.AutoSize = true;
            linkLabelQuaylai.LinkColor = Color.White;
            linkLabelQuaylai.Location = new Point(20, 20);
            linkLabelQuaylai.Name = "linkLabelQuaylai";
            linkLabelQuaylai.Size = new Size(139, 37);
            linkLabelQuaylai.TabIndex = 0;
            linkLabelQuaylai.TabStop = true;
            linkLabelQuaylai.Text = "< Quay lại";
            linkLabelQuaylai.VisitedLinkColor = Color.FromArgb(224, 224, 224);
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(grpInfo);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 60);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new Padding(10);
            pnlLeft.Size = new Size(622, 980);
            pnlLeft.TabIndex = 1;
            // 
            // grpInfo
            // 
            grpInfo.Controls.Add(flpActions);
            grpInfo.Controls.Add(tlpInputs);
            grpInfo.Controls.Add(btnRefresh);
            grpInfo.Dock = DockStyle.Fill;
            grpInfo.Location = new Point(10, 10);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(602, 960);
            grpInfo.TabIndex = 0;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin chi tiết";
            // 
            // flpActions
            // 
            flpActions.Controls.Add(btnAdd);
            flpActions.Controls.Add(btnEdit);
            flpActions.Controls.Add(btnDelete);
            flpActions.Controls.Add(btnBatch);
            flpActions.Dock = DockStyle.Bottom;
            flpActions.Location = new Point(3, 857);
            flpActions.Name = "flpActions";
            flpActions.Padding = new Padding(0, 10, 0, 0);
            flpActions.Size = new Size(596, 100);
            flpActions.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(39, 174, 96);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(3, 13);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 45);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(243, 156, 18);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(119, 13);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(109, 45);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click_1;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(234, 13);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(108, 45);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // btnBatch
            // 
            btnBatch.Location = new Point(348, 13);
            btnBatch.Name = "btnBatch";
            btnBatch.Size = new Size(217, 46);
            btnBatch.TabIndex = 3;
            btnBatch.Text = "Thêm theo lô";
            btnBatch.UseVisualStyleBackColor = true;
            btnBatch.Click += btnBatch_Click;
            // 
            // tlpInputs
            // 
            tlpInputs.ColumnCount = 2;
            tlpInputs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.10101F));
            tlpInputs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 69.89899F));
            tlpInputs.Controls.Add(lblID, 0, 0);
            tlpInputs.Controls.Add(txtID, 1, 0);
            tlpInputs.Controls.Add(lblName, 0, 1);
            tlpInputs.Controls.Add(txtName, 1, 1);
            tlpInputs.Controls.Add(lblPhone, 0, 2);
            tlpInputs.Controls.Add(txtPhone, 1, 2);
            tlpInputs.Controls.Add(lblEmail, 0, 3);
            tlpInputs.Controls.Add(txtEmail, 1, 3);
            tlpInputs.Controls.Add(lblDOB, 0, 4);
            tlpInputs.Controls.Add(dtpDateOfBirth, 1, 4);
            tlpInputs.Controls.Add(lblStatus, 0, 5);
            tlpInputs.Controls.Add(cboStatus, 1, 5);
            tlpInputs.Dock = DockStyle.Top;
            tlpInputs.Location = new Point(3, 39);
            tlpInputs.Name = "tlpInputs";
            tlpInputs.RowCount = 6;
            tlpInputs.RowStyles.Add(new RowStyle(SizeType.Absolute, 119F));
            tlpInputs.RowStyles.Add(new RowStyle(SizeType.Absolute, 106F));
            tlpInputs.RowStyles.Add(new RowStyle(SizeType.Absolute, 111F));
            tlpInputs.RowStyles.Add(new RowStyle(SizeType.Absolute, 113F));
            tlpInputs.RowStyles.Add(new RowStyle(SizeType.Absolute, 117F));
            tlpInputs.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tlpInputs.Size = new Size(596, 672);
            tlpInputs.TabIndex = 0;
            // 
            // lblID
            // 
            lblID.Anchor = AnchorStyles.Left;
            lblID.Location = new Point(3, 43);
            lblID.Name = "lblID";
            lblID.Size = new Size(128, 33);
            lblID.TabIndex = 0;
            lblID.Text = "Mã HV:";
            // 
            // txtID
            // 
            txtID.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtID.BackColor = Color.WhiteSmoke;
            txtID.Location = new Point(182, 38);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(411, 43);
            txtID.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.Left;
            lblName.Location = new Point(3, 155);
            lblName.Name = "lblName";
            lblName.Size = new Size(143, 33);
            lblName.TabIndex = 2;
            lblName.Text = "Họ tên:";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(182, 150);
            txtName.Name = "txtName";
            txtName.Size = new Size(411, 43);
            txtName.TabIndex = 3;
            // 
            // lblPhone
            // 
            lblPhone.Anchor = AnchorStyles.Left;
            lblPhone.Location = new Point(3, 264);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(128, 33);
            lblPhone.TabIndex = 4;
            lblPhone.Text = "SĐT:";
            // 
            // txtPhone
            // 
            txtPhone.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPhone.Location = new Point(182, 259);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(411, 43);
            txtPhone.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.Anchor = AnchorStyles.Left;
            lblEmail.Location = new Point(3, 374);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(143, 37);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.Location = new Point(182, 371);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(411, 43);
            txtEmail.TabIndex = 7;
            // 
            // lblDOB
            // 
            lblDOB.Anchor = AnchorStyles.Left;
            lblDOB.Location = new Point(3, 491);
            lblDOB.Name = "lblDOB";
            lblDOB.Size = new Size(143, 33);
            lblDOB.TabIndex = 8;
            lblDOB.Text = "Ngày sinh:";
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpDateOfBirth.Format = DateTimePickerFormat.Short;
            dtpDateOfBirth.Location = new Point(182, 486);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(411, 43);
            dtpDateOfBirth.TabIndex = 9;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Left;
            lblStatus.Location = new Point(3, 600);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(143, 37);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Trạng thái:";
            // 
            // cboStatus
            // 
            cboStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Location = new Point(182, 599);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(411, 45);
            cboStatus.TabIndex = 11;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(52, 152, 219);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(351, 717);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(144, 45);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(dgvStudents);
            pnlMain.Controls.Add(pnlSearch);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(622, 60);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(10);
            pnlMain.Size = new Size(1344, 980);
            pnlMain.TabIndex = 2;
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.BackgroundColor = Color.White;
            dgvStudents.BorderStyle = BorderStyle.None;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Dock = DockStyle.Fill;
            dgvStudents.Location = new Point(10, 60);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.RowHeadersWidth = 82;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(1324, 910);
            dgvStudents.TabIndex = 1;
            dgvStudents.CellClick += dgvStudents_CellClick;
            dgvStudents.CellContentClick += dgvStudents_CellContentClick;
            // 
            // pnlSearch
            // 
            pnlSearch.Controls.Add(btnTimKiem);
            pnlSearch.Controls.Add(txtSearchPhone);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(10, 10);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(1324, 50);
            pnlSearch.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimKiem.BackColor = Color.DimGray;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(305, 43);
            btnTimKiem.TabIndex = 1;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click_1;
            // 
            // txtSearchPhone
            // 
            txtSearchPhone.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearchPhone.Location = new Point(331, 1);
            txtSearchPhone.Name = "txtSearchPhone";
            txtSearchPhone.Size = new Size(993, 43);
            txtSearchPhone.TabIndex = 0;
            txtSearchPhone.Tag = "Tìm kiếm theo tên hoặc SĐT...";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(0, 0);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 0;
            // 
            // ManageStudents
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 244, 244);
            ClientSize = new Size(1966, 1040);
            Controls.Add(pnlMain);
            Controls.Add(pnlLeft);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "ManageStudents";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Học viên";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlLeft.ResumeLayout(false);
            grpInfo.ResumeLayout(false);
            flpActions.ResumeLayout(false);
            tlpInputs.ResumeLayout(false);
            tlpInputs.PerformLayout();
            pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        // Controls Declaration
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.LinkLabel linkLabelQuaylai;

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.TableLayoutPanel tlpInputs;
        private System.Windows.Forms.FlowLayoutPanel flpActions;

        // Labels (Helper only)
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblStatus;

        // Input Controls (Required Variables)
        public System.Windows.Forms.TextBox txtID;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.TextBox txtPhone;
        public System.Windows.Forms.TextBox txtEmail;
        public System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        public System.Windows.Forms.ComboBox cboStatus;

        // Action Buttons (Required Variables)
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.Button btnEdit;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnRefresh;
        public System.Windows.Forms.Button btnBack; // Declared for logic compatibility

        // Main Panel & Search
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlSearch;
        public System.Windows.Forms.TextBox txtSearchPhone;
        public System.Windows.Forms.Button btnTimKiem;
        public System.Windows.Forms.DataGridView dgvStudents;
        private Button btnBackDb;
        private Button btnBatch;
        private Button button1;
    }
}