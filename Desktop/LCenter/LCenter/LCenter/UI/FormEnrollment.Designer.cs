namespace LCenter.UI
{
    partial class FormEnrollment
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
            btnSave = new Button();
            dgvStudent = new DataGridView();
            btnCancel = new Button();
            btnBrowseExcel = new Button();
            btnExport = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStudent).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.GradientActiveCaption;
            btnSave.Location = new Point(1221, 672);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 46);
            btnSave.TabIndex = 1;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // dgvStudent
            // 
            dgvStudent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudent.Location = new Point(33, 36);
            dgvStudent.Name = "dgvStudent";
            dgvStudent.RowHeadersWidth = 82;
            dgvStudent.Size = new Size(1157, 760);
            dgvStudent.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.Location = new Point(1221, 750);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 46);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnBrowseExcel
            // 
            btnBrowseExcel.BackColor = Color.MediumAquamarine;
            btnBrowseExcel.Location = new Point(1221, 36);
            btnBrowseExcel.Name = "btnBrowseExcel";
            btnBrowseExcel.Size = new Size(150, 46);
            btnBrowseExcel.TabIndex = 4;
            btnBrowseExcel.Text = "Import";
            btnBrowseExcel.UseVisualStyleBackColor = false;
            btnBrowseExcel.Click += btnBrowseExcel_Click;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(1221, 114);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(150, 46);
            btnExport.TabIndex = 5;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            // 
            // FormEnrollment
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1438, 841);
            Controls.Add(btnExport);
            Controls.Add(btnBrowseExcel);
            Controls.Add(btnCancel);
            Controls.Add(dgvStudent);
            Controls.Add(btnSave);
            Name = "FormEnrollment";
            Text = "FormEnrollment";
            Load += FormEnrollment_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudent).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button btnSave;
        private DataGridView dgvStudent;
        private Button btnCancel;
        private Button btnBrowseExcel;
        private Button btnExport;
    }
}