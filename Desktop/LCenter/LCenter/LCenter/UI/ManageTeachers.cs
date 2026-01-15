using LCenterBLL.Interfaces;
using LCenterDAL.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LCenter.UI
{
    public partial class ManageTeachers : Form
    {
        private readonly IUserBUS _bus;
        private List<UserDTO> _listCache;
        private int _currentUserId = 0;

        private bool _isBusy = false;

        public ManageTeachers(IUserBUS bus)
        {
            InitializeComponent();
            _bus = bus;
            this.Load += ManageTeachers_Load;
        }

        private async void ManageTeachers_Load(object sender, EventArgs e)
        {
            await LoadDataSafeAsync();
        }

        private async Task LoadDataSafeAsync()
        {
            if (_isBusy) return;

            try
            {
                _isBusy = true; 
                Cursor.Current = Cursors.WaitCursor; 

                _listCache = await _bus.GetTeachersAsync();
                BindGrid(_listCache);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                _isBusy = false; // Tắt cờ bận dù có lỗi hay không
                Cursor.Current = Cursors.Default;
            }
        }

        private void BindGrid(List<UserDTO> list)
        {
            dgvTeachers.DataSource = null;
            dgvTeachers.AutoGenerateColumns = true;
            dgvTeachers.DataSource = list;

            if (list == null || list.Count == 0) return;

            string[] hideCols = { "PasswordHash", "RoleName", "UserId", "DisplayName" };
            foreach (var col in hideCols)
            {
                if (dgvTeachers.Columns[col] != null) dgvTeachers.Columns[col].Visible = false;
            }

            if (dgvTeachers.Columns["Username"] != null) dgvTeachers.Columns["Username"].HeaderText = "Tài khoản";
            if (dgvTeachers.Columns["FullName"] != null) dgvTeachers.Columns["FullName"].HeaderText = "Họ tên";
            if (dgvTeachers.Columns["Specialization"] != null) dgvTeachers.Columns["Specialization"].HeaderText = "Chuyên môn";
            if (dgvTeachers.Columns["Email"] != null) dgvTeachers.Columns["Email"].HeaderText = "Email";
            if (dgvTeachers.Columns["Phone"] != null) dgvTeachers.Columns["Phone"].HeaderText = "SĐT";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_listCache == null) return;
            string keyword = txtSearch.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                BindGrid(_listCache);
            }
            else
            {
                var filteredList = _listCache.Where(u =>
                    (u.Phone != null && u.Phone.Contains(keyword)) ||
                    (u.FullName != null && u.FullName.ToLower().Contains(keyword)) ||
                    (u.Username != null && u.Username.ToLower().Contains(keyword))
                ).ToList();
                BindGrid(filteredList);
            }
        }


        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (_isBusy) return; 

            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập Username và Họ tên!");
                return;
            }

            var dto = new UserDTO
            {
                Username = txtUsername.Text.Trim(),
                FullName = txtName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Specialization = txtSpec.Text.Trim(),
                IsActive = chkActive.Checked,
                PasswordHash = "123456"
            };

            try
            {
                _isBusy = true; 
                int newId = await _bus.AddTeacherAsync(dto);
                if (newId > 0)
                {
                    MessageBox.Show("Thêm thành công! Pass mặc định: 123456");
                    ResetInput();

                    _isBusy = false; 
                    await LoadDataSafeAsync();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại (Username đã tồn tại?)");
                    _isBusy = false;
                }
            }
            catch (Exception ex)
            {
                _isBusy = false;
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            ResetInput();
            await LoadDataSafeAsync();
        }

        private void ResetInput()
        {
            _currentUserId = 0;
            txtUsername.Clear();
            txtUsername.Enabled = true;
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtSpec.Clear();
            chkActive.Checked = true;
            txtSearch.Clear();
        }

        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTeachers_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var item = dgvTeachers.Rows[e.RowIndex].DataBoundItem as UserDTO;
                if (item == null) return;

                _currentUserId = item.UserId; 
                if (txtUsername != null) { txtUsername.Text = item.Username; txtUsername.Enabled = false; }
                if (txtName != null) txtName.Text = item.FullName;
                if (txtEmail != null) txtEmail.Text = item.Email;
                if (txtPhone != null) txtPhone.Text = item.Phone;
                if (txtSpec != null) txtSpec.Text = item.Specialization;
                if (chkActive != null) chkActive.Checked = item.IsActive;
            }
            catch { }
        }

        private async void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (_isBusy) return;

            if (_currentUserId <= 0)
            {
                MessageBox.Show("Vui lòng chọn giảng viên cần sửa!");
                return;
            }

            var dto = new UserDTO
            {
                UserId = _currentUserId,
                Username = txtUsername.Text.Trim(),
                FullName = txtName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Specialization = txtSpec.Text.Trim(),
                IsActive = chkActive.Checked
            };

            try
            {
                _isBusy = true;
                if (await _bus.UpdateTeacherAsync(dto))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    ResetInput();
                    _isBusy = false;
                    await LoadDataSafeAsync();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại.");
                    _isBusy = false;
                }
            }
            catch (Exception ex)
            {
                _isBusy = false;
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}