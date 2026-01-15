using LCenterBLL.Common;
using LCenterBLL.Interfaces;
using LCenterDAL.DTOs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LCenter.UI
{
    public partial class ManageClasses : Form
    {
        private readonly IClassBUS _classBUS;
        private readonly ICourseBUS _courseBUS;
        private readonly IUserBUS _userBUS;
        private readonly IServiceProvider _serviceProvider;
        private List<ClassDTO> _listCache;

        public ManageClasses(IClassBUS classBUS, ICourseBUS courseBUS, IUserBUS userBUS, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _classBUS = classBUS;
            _courseBUS = courseBUS;
            _userBUS = userBUS;
            _serviceProvider = serviceProvider;

            // Đăng ký sự kiện Load (tránh trùng lặp nếu Designer đã có)
            this.Load -= ManageClasses_Load;
            this.Load += ManageClasses_Load;
        }

        private async void ManageClasses_Load(object sender, EventArgs e)
        {
            ApplyPermissions();
            await LoadAllDataAsync();
        }

        private void ApplyPermissions()
        {
            // Kiểm tra an toàn: Nếu chưa đăng nhập thì ẩn hết nút sửa xóa để tránh lỗi
            if (Session.CurrentUser == null)
            {
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                return;
            }

            if (Session.CurrentUser.RoleName == "Teacher")
            {
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;

                txtClassName.ReadOnly = true;
                cboCourse.Enabled = false;
                cboTeacher.Enabled = false;
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;

                btnViewStudents.Visible = true;
                btnRefresh.Visible = true;
            }
            else
            {
                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnDelete.Visible = true;

                txtClassName.ReadOnly = false;
                cboCourse.Enabled = true;
                cboTeacher.Enabled = true;
                dtpStartDate.Enabled = true;
                dtpEndDate.Enabled = true;
            }
        }

        private async Task LoadAllDataAsync()
        {
            try
            {
                // 1. Load ComboBox Khóa học (Cấu hình hiển thị TRƯỚC khi gán dữ liệu)
                var courses = await _courseBUS.GetAllAsync();
                cboCourse.DataSource = null;
                if (courses != null)
                {
                    cboCourse.DisplayMember = "CourseName";
                    cboCourse.ValueMember = "CourseId";
                    cboCourse.DataSource = courses;
                    cboCourse.SelectedIndex = -1;
                }

                // 2. Load ComboBox Giảng viên
                var teachers = await _userBUS.GetTeachersAsync();
                cboTeacher.DataSource = null;
                if (teachers != null)
                {
                    cboTeacher.DisplayMember = "FullName";
                    cboTeacher.ValueMember = "UserId";
                    cboTeacher.DataSource = teachers;
                    cboTeacher.SelectedIndex = -1;
                }

                // 3. Load dữ liệu lưới
                await LoadGridData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private async Task LoadGridData()
        {
            try
            {
                _listCache = await _classBUS.GetAllAsync();

                if (_listCache == null) _listCache = new List<ClassDTO>();

                // 🔥 SỬA LỖI Ở ĐÂY: Kiểm tra Session khác NULL trước khi check RoleName
                if (Session.CurrentUser != null && Session.CurrentUser.RoleName == "Teacher")
                {
                    _listCache = _listCache.Where(c => c.TeacherId == Session.CurrentUser.UserId).ToList();
                }

                BindGrid(_listCache);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách lớp: " + ex.Message);
            }
        }

        private void BindGrid(List<ClassDTO> list)
        {
            dgvClasses.DataSource = null;
            dgvClasses.AutoGenerateColumns = true;
            dgvClasses.DataSource = list;

            if (list == null || list.Count == 0) return;

            // Ẩn các cột ID
            if (dgvClasses.Columns["ClassId"] != null) dgvClasses.Columns["ClassId"].Visible = false;
            if (dgvClasses.Columns["CourseId"] != null) dgvClasses.Columns["CourseId"].Visible = false;
            if (dgvClasses.Columns["TeacherId"] != null) dgvClasses.Columns["TeacherId"].Visible = false;
            if (dgvClasses.Columns["CreatedDate"] != null) dgvClasses.Columns["CreatedDate"].Visible = false;
            // Ẩn cột DisplayName (thường dùng cho ComboBox chứ không hiện lên lưới)
            if (dgvClasses.Columns["DisplayName"] != null) dgvClasses.Columns["DisplayName"].Visible = false;

            // Đặt tên tiếng Việt
            if (dgvClasses.Columns["ClassName"] != null)
            {
                dgvClasses.Columns["ClassName"].HeaderText = "Tên Lớp";
                dgvClasses.Columns["ClassName"].Width = 200;
            }
            if (dgvClasses.Columns["CourseName"] != null)
            {
                dgvClasses.Columns["CourseName"].HeaderText = "Khóa Học";
                dgvClasses.Columns["CourseName"].Width = 150;
            }
            if (dgvClasses.Columns["TeacherName"] != null)
            {
                dgvClasses.Columns["TeacherName"].HeaderText = "Giảng Viên";
                dgvClasses.Columns["TeacherName"].Width = 150;
            }
            if (dgvClasses.Columns["StudentCount"] != null)
            {
                dgvClasses.Columns["StudentCount"].HeaderText = "Sĩ số";
                dgvClasses.Columns["StudentCount"].Width = 80;
                dgvClasses.Columns["StudentCount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvClasses.Columns["StartDate"] != null)
            {
                dgvClasses.Columns["StartDate"].HeaderText = "Ngày Bắt Đầu";
                dgvClasses.Columns["StartDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvClasses.Columns["StartDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvClasses.Columns["EndDate"] != null)
            {
                dgvClasses.Columns["EndDate"].HeaderText = "Ngày Kết Thúc";
                dgvClasses.Columns["EndDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvClasses.Columns["EndDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dgvClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var item = dgvClasses.Rows[e.RowIndex].DataBoundItem as ClassDTO;
            if (item == null) return;

            txtID.Text = item.ClassId.ToString();
            txtClassName.Text = item.ClassName;
            dtpStartDate.Value = item.StartDate;
            dtpEndDate.Value = item.EndDate;

            // Gán giá trị an toàn cho ComboBox
            if (cboCourse.Items.Count > 0) cboCourse.SelectedValue = item.CourseId;
            if (cboTeacher.Items.Count > 0) cboTeacher.SelectedValue = item.TeacherId;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var dto = new ClassInputDTO
            {
                ClassName = txtClassName.Text.Trim(),
                StartDate = dtpStartDate.Value,
                EndDate = dtpEndDate.Value,
                CourseId = (int)cboCourse.SelectedValue,
                TeacherId = (int)cboTeacher.SelectedValue
            };

            try
            {
                int newId = await _classBUS.AddAsync(dto);
                if (newId > 0)
                {
                    MessageBox.Show("Thêm lớp thành công!");
                    await LoadGridData();
                    ResetInput();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) return;
            if (!ValidateInput()) return;

            var dto = new ClassInputDTO
            {
                ClassId = int.Parse(txtID.Text),
                ClassName = txtClassName.Text.Trim(),
                StartDate = dtpStartDate.Value,
                EndDate = dtpEndDate.Value,
                CourseId = (int)cboCourse.SelectedValue,
                TeacherId = (int)cboTeacher.SelectedValue
            };

            try
            {
                if (await _classBUS.UpdateAsync(dto))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    await LoadGridData();
                    ResetInput();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) return;
            int id = int.Parse(txtID.Text);

            if (MessageBox.Show("Xóa lớp học này sẽ ảnh hưởng đến danh sách học viên trong lớp.\nBạn có chắc chắn?",
                                "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    if (await _classBUS.DeleteAsync(id))
                    {
                        MessageBox.Show("Đã xóa!");
                        await LoadGridData();
                        ResetInput();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ResetInput();
            _ = LoadGridData();
        }

        private void ResetInput()
        {
            txtID.Clear();
            txtClassName.Clear();
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMonths(3);
            if (cboCourse.Items.Count > 0) cboCourse.SelectedIndex = -1;
            if (cboTeacher.Items.Count > 0) cboTeacher.SelectedIndex = -1;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtClassName.Text)) { MessageBox.Show("Nhập tên lớp!"); return false; }
            if (cboCourse.SelectedIndex < 0) { MessageBox.Show("Chọn khóa học!"); return false; }
            if (cboTeacher.SelectedIndex < 0) { MessageBox.Show("Chọn giảng viên!"); return false; }
            return true;
        }

        private void btnViewStudents_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn một lớp học để xem chi tiết!");
                return;
            }

            int classId = int.Parse(txtID.Text);
            string className = txtClassName.Text;
            OpenClassDetailForm(classId, className);
        }

        private void OpenClassDetailForm(int classId, string className)
        {
            var detailForm = _serviceProvider.GetRequiredService<ManageClassDetails>();
            detailForm.SetClassInfo(classId, className);
            this.Hide();
            detailForm.ShowDialog();
            this.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "MainForm")
                {
                    f.Show();
                    break;
                }
            }
            this.Close();
        }
    }
}