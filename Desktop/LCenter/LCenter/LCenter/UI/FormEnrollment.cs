using ExcelDataReader;
using LCenterBLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LCenter.UI
{
    public partial class FormEnrollment : Form
    {
        private readonly int _classId;
        private readonly IStudentBUS _studentBus;
        private readonly IEnrollmentBUS _enrollmentBus;

        // 🔥 BIẾN QUAN TRỌNG: Lưu tạm danh sách ID hợp lệ chờ được Lưu
        private List<int> _pendingStudentIds = new List<int>();

        public FormEnrollment(int classId, IStudentBUS sBus, IEnrollmentBUS eBus)
        {
            InitializeComponent();
            _classId = classId;
            _studentBus = sBus;
            _enrollmentBus = eBus;

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        private async void FormEnrollment_Load(object sender, EventArgs e)
        {
            await LoadStudentsInClass();
        }

        // Hàm load danh sách thật từ Database
        private async Task LoadStudentsInClass()
        {
            try
            {
                var list = await _enrollmentBus.GetStudentsInClassAsync(_classId);
                dgvStudent.DataSource = list;

                // Ẩn cột không cần thiết
                if (dgvStudent.Columns["EnrollmentId"] != null) dgvStudent.Columns["EnrollmentId"].Visible = false;
                if (dgvStudent.Columns["ClassId"] != null) dgvStudent.Columns["ClassId"].Visible = false;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải danh sách lớp: " + ex.Message); }
        }

        // =============================================================
        // BƯỚC 1: NÚT CHỌN EXCEL (CHỈ PREVIEW - KHÔNG LƯU)
        // =============================================================
        private async void btnBrowseExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xls",
                Title = "Chọn file danh sách học viên"
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Cấu hình để dùng dòng đầu tiên làm Tiêu đề cột (Header)
                    var conf = new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    };

                    var dataSet = reader.AsDataSet(conf);
                    var dataTable = dataSet.Tables[0]; // Lấy sheet đầu tiên

                    // 🔥 YÊU CẦU CỦA BẠN: Hiển thị toàn bộ thông tin file Excel lên Grid
                    dgvStudent.DataSource = dataTable;

                    MessageBox.Show($"Đã load {dataTable.Rows.Count} dòng từ file Excel.\nVui lòng kiểm tra và bấm LƯU để ghi danh.", "Thông báo");
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Vui lòng tắt file Excel trước khi Import!", "Lỗi file");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file: " + ex.Message);
            }
        }

        // =============================================================
        // BƯỚC 2: NÚT LƯU (THỰC HIỆN TRANSACTION)
        // =============================================================
        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem Grid đang hiển thị dữ liệu từ Excel (DataTable) hay chưa
            DataTable dt = dgvStudent.DataSource as DataTable;

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu từ file Excel. Vui lòng Import trước!", "Thông báo");
                return;
            }

            if (MessageBox.Show($"Bạn có muốn thực hiện ghi danh cho {dt.Rows.Count} học viên trong danh sách này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                var listStudentIdsToEnroll = new List<int>();
                var listNotFound = new List<string>();

                // Duyệt từng dòng trên lưới (chính là dữ liệu file Excel)
                foreach (DataRow row in dt.Rows)
                {
                    // Lấy SĐT từ cột "Phone" (theo file mẫu bạn gửi)
                    // Nếu file Excel tên cột khác (ví dụ "Số điện thoại") thì đổi chữ "Phone" bên dưới
                    if (row.Table.Columns.Contains("Phone"))
                    {
                        string phone = row["Phone"].ToString().Trim();
                        if (string.IsNullOrEmpty(phone)) continue;

                        // Tìm ID học viên trong DB dựa vào SĐT
                        var student = await _studentBus.LookupByPhoneAsync(phone);

                        if (student != null)
                        {
                            listStudentIdsToEnroll.Add(student.StudentId);
                        }
                        else
                        {
                            // Lưu lại SĐT không tìm thấy để báo cáo
                            listNotFound.Add(phone);
                        }
                    }
                }

                // Xử lý Ghi danh
                if (listStudentIdsToEnroll.Count > 0)
                {
                    // Gọi Transaction ghi danh lô
                    string result = await _enrollmentBus.EnrollStudentsBatchAsync(_classId, listStudentIdsToEnroll);

                    string msg = result;
                    if (listNotFound.Count > 0)
                    {
                        msg += $"\n\nTuy nhiên, có {listNotFound.Count} SĐT trong file không tồn tại trên hệ thống (không thể ghi danh): \n" + string.Join(", ", listNotFound.Take(5)) + "...";
                    }

                    MessageBox.Show(msg, "Kết quả");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bất kỳ học viên nào trong hệ thống khớp với danh sách SĐT này.", "Lỗi dữ liệu");
                }

                // Cuối cùng: Load lại danh sách chính thức từ DB để hiển thị kết quả
                await LoadStudentsInClass();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
