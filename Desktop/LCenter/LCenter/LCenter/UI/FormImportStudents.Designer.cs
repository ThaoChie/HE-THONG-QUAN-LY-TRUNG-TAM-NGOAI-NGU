namespace LCenter.UI
{
    partial class FormImportStudents
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
            dgvImport = new DataGridView();
            btnSave = new Button();
            btnBrowseExcel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvImport).BeginInit();
            SuspendLayout();
            // 
            // dgvImport
            // 
            dgvImport.BackgroundColor = SystemColors.ControlLightLight;
            dgvImport.BorderStyle = BorderStyle.Fixed3D;
            dgvImport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvImport.Location = new Point(49, 63);
            dgvImport.Name = "dgvImport";
            dgvImport.RowHeadersWidth = 82;
            dgvImport.Size = new Size(1307, 830);
            dgvImport.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.Location = new Point(1403, 847);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 46);
            btnSave.TabIndex = 1;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnBrowseExcel
            // 
            btnBrowseExcel.Location = new Point(1403, 776);
            btnBrowseExcel.Name = "btnBrowseExcel";
            btnBrowseExcel.Size = new Size(150, 46);
            btnBrowseExcel.TabIndex = 2;
            btnBrowseExcel.Text = "Import Excel";
            btnBrowseExcel.UseVisualStyleBackColor = true;
            btnBrowseExcel.Click += btnBrowseExcel_Click;
            // 
            // FormImportStudents
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1596, 962);
            Controls.Add(btnBrowseExcel);
            Controls.Add(btnSave);
            Controls.Add(dgvImport);
            Name = "FormImportStudents";
            Text = "Thêm hồ sơ học viên theo lô";
            Load += FormImportStudents_Load;
            ((System.ComponentModel.ISupportInitialize)dgvImport).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvImport;
        private Button btnSave;
        private Button btnBrowseExcel;
    }
}