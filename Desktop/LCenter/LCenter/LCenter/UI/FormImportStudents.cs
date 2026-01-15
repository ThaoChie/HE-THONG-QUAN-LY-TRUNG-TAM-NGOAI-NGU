using LCenterBLL.Interfaces;
using LCenterDAL.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader; // Nhớ using cái này
using System.IO;
using System.Data;

namespace LCenter.UI
{
    public partial class FormImportStudents : Form
    {
        private readonly IStudentBUS _studentBus;

        public FormImportStudents(IStudentBUS studentBus)
        {
            InitializeComponent();
            _studentBus = studentBus;
            InitializeGrid();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        private void InitializeGrid()
        {
            dgvImport.AutoGenerateColumns = false;
            dgvImport.Columns.Add("FullName", "Họ và Tên");
            dgvImport.Columns.Add("Email", "Email");
            dgvImport.Columns.Add("Phone", "SĐT");
            // Cột ngày tháng cần xử lý format
            var colDate = new DataGridViewTextBoxColumn();
            colDate.Name = "DateOfBirth";
            colDate.HeaderText = "Ngày sinh (yyyy-MM-dd)";
            dgvImport.Columns.Add(colDate);
        }
        private void FormImportStudents_Load(object sender, EventArgs e)
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var listToImport = new List<StudentDTO>();

            foreach (DataGridViewRow row in dgvImport.Rows)
            {
                if (row.IsNewRow) continue; 

                var s = new StudentDTO();

                s.FullName = row.Cells["FullName"].Value?.ToString();
                s.Email = row.Cells["Email"].Value?.ToString();
                s.Phone = row.Cells["Phone"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["DateOfBirth"].Value?.ToString(), out DateTime dob))
                    s.DateOfBirth = dob;
                else
                    s.DateOfBirth = DateTime.Now; 

                listToImport.Add(s);
            }

            if (listToImport.Count == 0)
            {
                MessageBox.Show("Danh sách trống!");
                return;
            }

            btnSave.Enabled = false; 
            try
            {
                string result = await _studentBus.ImportStudentsBatchAsync(listToImport);

                if (result == "Success")
                {
                    MessageBox.Show($"Đã thêm thành công {listToImport.Count} học viên!");
                    this.Close(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Nhập Lô", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }

        private void btnBrowseExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xls",
                Title = "Chọn file danh sách học viên"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ReadExcelFile(openFileDialog.FileName);
            }
        }

        private void ReadExcelFile(string filePath)
        {
            try
            {
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true 
                            }
                        });

                        DataTable table = result.Tables[0];

                        dgvImport.Rows.Clear();

                        foreach (DataRow row in table.Rows)
                        {
                            string name = row[0].ToString();
                            string email = row[1].ToString();
                            string phone = row[2].ToString();
                            string dob = row[3].ToString();

                            dgvImport.Rows.Add(name, email, phone, dob);
                        }

                        MessageBox.Show($"Đã đọc xong {table.Rows.Count} dòng!", "Thông báo");
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("File đang mở. Vui lòng đóng file Excel lại trước khi import!", "Cảnh báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file: " + ex.Message);
            }
        }
    }
}
