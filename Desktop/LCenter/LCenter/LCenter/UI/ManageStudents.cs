using LCenterBLL.Interfaces;
using LCenterDAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LCenter.UI
{
    public partial class ManageStudents : Form
    {
        private readonly IStudentBUS _bus;
        private List<StudentDTO> _listCache;

        public ManageStudents(IStudentBUS bus)
        {
            InitializeComponent();
            _bus = bus;
            this.Load += ManageStudents_Load;
        }



        private async void ManageStudents_Load(object sender, EventArgs e)
        {
            cboStatus.Items.Clear();
            cboStatus.Items.AddRange(new string[] { "Đang học", "Bảo lưu", "Đã nghỉ", "Hoàn thành" });
            cboStatus.SelectedIndex = 0;

            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                _listCache = await _bus.GetAllAsync();
                BindGrid(_listCache);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void BindGrid(List<StudentDTO> list)
        {
            dgvStudents.DataSource = null;
            dgvStudents.AutoGenerateColumns = true; // Tạm tắt để kiểm soát cột thủ công

            // --- CÁCH SỬA 1: Map dữ liệu thủ công (Chuẩn nhất) ---
            // Bạn phải đảm bảo tên cột (Name) trong Design khớp với dòng dưới
            if (dgvStudents.Columns["FullName"] != null) dgvStudents.Columns["FullName"].DataPropertyName = "FullName";
            if (dgvStudents.Columns["Phone"] != null) dgvStudents.Columns["Phone"].DataPropertyName = "Phone";
            if (dgvStudents.Columns["Email"] != null) dgvStudents.Columns["Email"].DataPropertyName = "Email";
            if (dgvStudents.Columns["DateOfBirth"] != null) dgvStudents.Columns["DateOfBirth"].DataPropertyName = "DateOfBirth";
            if (dgvStudents.Columns["Status"] != null) dgvStudents.Columns["Status"].DataPropertyName = "Status";

            // Ẩn cột ID nếu có
            if (dgvStudents.Columns["StudentId"] != null) dgvStudents.Columns["StudentId"].DataPropertyName = "StudentId";

            dgvStudents.DataSource = list;

            // Format ngày sinh
            if (dgvStudents.Columns["DateOfBirth"] != null)
                dgvStudents.Columns["DateOfBirth"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }


        private void linkLabelQuaylai_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }




        private void ManageStudents_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpNgaySinh_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ResetInput();
            txtSearchPhone.Clear();
            _ = LoadDataAsync();
        }

        private void ResetInput()
        {
            txtID.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            dtpDateOfBirth.Value = DateTime.Now;
            cboStatus.SelectedIndex = 0;
            txtName.Focus();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên!");
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại!");
                txtPhone.Focus();
                return false;
            }
            return true;
        }

        private void btnBackDb_Click(object sender, EventArgs e)
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


        private async void btnBatch_Click(object sender, EventArgs e)
        {
            FormImportStudents frm = new FormImportStudents(_bus);
            frm.ShowDialog();
            await LoadDataAsync();
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var item = dgvStudents.Rows[e.RowIndex].DataBoundItem as StudentDTO;

                if (item == null) return;

                txtID.Text = item.StudentId.ToString();
                txtName.Text = item.FullName;
                txtPhone.Text = item.Phone;
                txtEmail.Text = item.Email;
                dtpDateOfBirth.Value = item.DateOfBirth ?? DateTime.Now;

                if (!string.IsNullOrEmpty(item.Status))
                {
                    cboStatus.Text = item.Status;
                }
                else
                {
                    cboStatus.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dòng: " + ex.Message);
            }
        }

        private async void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn học viên cần sửa!");
                return;
            }
            if (!ValidateInput()) return;

            var dto = new StudentDTO
            {
                StudentId = int.Parse(txtID.Text),
                FullName = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                DateOfBirth = dtpDateOfBirth.Value,
                Status = cboStatus.Text
            };

            try
            {
                if (await _bus.UpdateAsync(dto))
                {
                    MessageBox.Show("Cập nhật thành công!");

                    var existingItem = _listCache.FirstOrDefault(s => s.StudentId == dto.StudentId);
                    if (existingItem != null)
                    {
                        existingItem.FullName = dto.FullName;
                        existingItem.Phone = dto.Phone;
                        existingItem.Email = dto.Email;
                        existingItem.DateOfBirth = dto.DateOfBirth;
                        existingItem.Status = dto.Status;
                    }

                    BindGrid(_listCache);
                    ResetInput();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }



        private async void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) return;

            int id = int.Parse(txtID.Text);

            if (MessageBox.Show("Bạn có chắc muốn xóa học viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    if (await _bus.DeleteAsync(id))
                    {
                        MessageBox.Show("Đã xóa thành công!");

                        var itemToRemove = _listCache.FirstOrDefault(s => s.StudentId == id);
                        if (itemToRemove != null)
                        {
                            _listCache.Remove(itemToRemove);
                        }

                        BindGrid(null);
                        BindGrid(_listCache);
                        ResetInput();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var dto = new StudentCreateDTO
            {
                FullName = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                DateOfBirth = dtpDateOfBirth.Value
            };

            try
            {
                int newId = await _bus.AddAsync(dto);

                if (newId > 0)
                {
                    MessageBox.Show("Thêm học viên thành công!");

                    var newStudent = new StudentDTO
                    {
                        StudentId = newId,
                        FullName = dto.FullName,
                        Phone = dto.Phone,
                        Email = dto.Email,
                        DateOfBirth = dto.DateOfBirth,
                        Status = "Đang học"
                    };

                    _listCache.Insert(0, newStudent);
                    BindGrid(_listCache);
                    ResetInput();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            if (_listCache == null) return;

            string keyword = txtSearchPhone.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                BindGrid(_listCache);
            }
            else
            {
                var filteredList = _listCache.Where(s =>
                    (s.FullName != null && s.FullName.ToLower().Contains(keyword)) ||
                    (s.Phone != null && s.Phone.Contains(keyword))
                ).ToList();

                BindGrid(filteredList);
            }
        }
    }
}
