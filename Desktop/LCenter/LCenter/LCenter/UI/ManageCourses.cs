using LCenterBLL.Interfaces;
using LCenterDAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LCenter.UI
{
    public partial class ManageCourses : Form
    {
        private readonly ICourseBUS _bus;
        private List<CourseDTO> _listCache; 

        public ManageCourses(ICourseBUS bus)
        {
            InitializeComponent();
            _bus = bus;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void ManageCourses_Load(object sender, EventArgs e)
        {
            cboLevel.Items.AddRange(new string[] { "Basic", "Intermediate", "Advanced", "IELTS", "TOEIC" });

            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                _listCache = await _bus.GetAllAsync();
                BindGrid(_listCache);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BindGrid(List<CourseDTO> list)
        {
            dgvCourses.DataSource = null;
            dgvCourses.DataSource = list;

            if (dgvCourses.Columns["DisplayName"] != null)
                dgvCourses.Columns["DisplayName"].Visible = false;

            ConfigureColumn("CourseId", "ID", 50); 
            ConfigureColumn("CourseName", "Tên Khóa học", 200);
            ConfigureColumn("Level", "Trình độ", 100);
            ConfigureColumn("DurationHours", "Thời lượng", 100);
            ConfigureColumn("TuitionFee", "Học phí", 120);
            ConfigureColumn("Description", "Mô tả", 200);

            if (dgvCourses.Columns["TuitionFee"] != null)
            {
                dgvCourses.Columns["TuitionFee"].DefaultCellStyle.Format = "N0";
                dgvCourses.Columns["TuitionFee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        // Hàm phụ trợ để set tên cột cho gọn 
        private void ConfigureColumn(string propertyName, string headerText, int width)
        {
            if (dgvCourses.Columns[propertyName] != null)
            {
                dgvCourses.Columns[propertyName].Visible = true; 
                dgvCourses.Columns[propertyName].HeaderText = headerText;
                dgvCourses.Columns[propertyName].Width = width;
            }
        }


        private void dgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var item = dgvCourses.Rows[e.RowIndex].DataBoundItem as CourseDTO;
            if (item == null) return;

            txtId.Text = item.CourseId.ToString();
            txtName.Text = item.CourseName;
            numFee.Value = item.TuitionFee;
            numDuration.Value = item.DurationHours;
            cboLevel.Text = item.Level;
            txtDesc.Text = item.Description;

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text)) return;

            var dto = new CourseDTO
            {
                CourseName = txtName.Text,
                TuitionFee = numFee.Value,
                DurationHours = (int)numDuration.Value,
                Level = cboLevel.Text,
                Description = txtDesc.Text
            };

            try
            {
                int newId = await _bus.AddAsync(dto); 
                if (newId > 0)
                {
                    MessageBox.Show("Thêm thành công!");

                    dto.CourseId = newId;
                    _listCache.Add(dto); 
                    BindGrid(_listCache);
                    ResetInput();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }

        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;

            var dto = new CourseDTO
            {
                CourseId = int.Parse(txtId.Text),
                CourseName = txtName.Text,
                TuitionFee = numFee.Value,
                DurationHours = (int)numDuration.Value,
                Level = cboLevel.Text,
                Description = txtDesc.Text
            };

            if (await _bus.UpdateAsync(dto))
            {
                MessageBox.Show("Cập nhật thành công!");
               
                var existing = _listCache.FirstOrDefault(x => x.CourseId == dto.CourseId);
                if (existing != null)
                {
                    existing.CourseName = dto.CourseName;
                    existing.TuitionFee = dto.TuitionFee;
                    existing.DurationHours = dto.DurationHours;
                    existing.Level = dto.Level;
                    existing.Description = dto.Description;
                }
                BindGrid(_listCache); 
            }

        }

        private async  void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;
            int id = int.Parse(txtId.Text);

            if (MessageBox.Show("Xóa khóa học này?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (await _bus.DeleteAsync(id))
                {
                    var item = _listCache.FirstOrDefault(x => x.CourseId == id);
                    if (item != null) _listCache.Remove(item);
                    BindGrid(null); 
                    BindGrid(_listCache);
                    ResetInput();
                }
            }

        }

        private void ManageCourses_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            ResetInput();
        }

        private void ResetInput()
        {
            txtId.Clear(); txtName.Clear(); txtDesc.Clear();
            numFee.Value = 0; numDuration.Value = 0;
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
