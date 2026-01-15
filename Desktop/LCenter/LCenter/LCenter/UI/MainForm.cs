using LCenter.UI;
using LCenterBLL.Common;
using LCenterBLL.Interfaces;
using LCenterDAL.DTOs;
using LCenterDAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LCenter
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IStatisticBUS _statBUS;

        public MainForm(IServiceProvider serviceProvider, IStatisticBUS statBUS)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _statBUS = statBUS;
        }
        private async void MainForm_Load(object sender, EventArgs e)
        {
            //  Kiểm tra đăng nhập
            if (!Session.IsLoggedIn())
            {
                this.Hide();
                var login = _serviceProvider.GetRequiredService<LoginForm>();
                if (login.ShowDialog() != DialogResult.OK)
                {
                    Application.Exit(); 
                    return;
                }
            }

            if (Session.CurrentUser != null)
            {
                lblWelcome.Text = $"Xin chào: {Session.CurrentUser.FullName} ({Session.CurrentUser.RoleName})";

                ApplyPermissions();
            }

            await LoadDashboardSafeAsync();
        }

        private async Task LoadDashboardSafeAsync()
        {
            try
            {
                // A. Lấy tổng số học viên
                int totalStudents = await _statBUS.GetTotalStudentsAsync();

                if (lblTotalStudents != null)
                    lblTotalStudents.Text = $"Số lượng học viên tại trung tâm: {totalStudents}";

                // B. Lấy Top 10 học viên xuất sắc
                var topStudents = await _statBUS.GetTopStudentsAsync();

                dgvTopStudents.DataSource = topStudents;
                FormatTopStudentGrid();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi Dashboard: " + ex.Message);
            }
        }


        private void FormatTopStudentGrid()
        {
            if (dgvTopStudents.Columns.Count == 0) return;

            string[] hideCols = { "StudentId", "DateOfBirth", "Email", "Status" };
            foreach (var col in hideCols)
            {
                if (dgvTopStudents.Columns[col] != null) dgvTopStudents.Columns[col].Visible = false;
            }

            if (dgvTopStudents.Columns["FullName"] != null) dgvTopStudents.Columns["FullName"].HeaderText = "Họ Tên";
            if (dgvTopStudents.Columns["Phone"] != null) dgvTopStudents.Columns["Phone"].HeaderText = "SĐT";

            if (dgvTopStudents.Columns["GPA"] != null)
            {
                dgvTopStudents.Columns["GPA"].HeaderText = "Điểm TB";
                dgvTopStudents.Columns["GPA"].DefaultCellStyle.Format = "N2";
                dgvTopStudents.Columns["GPA"].DefaultCellStyle.ForeColor = Color.Red;
                dgvTopStudents.Columns["GPA"].DefaultCellStyle.Font = new Font(dgvTopStudents.Font, FontStyle.Bold);
            }

            dgvTopStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ApplyPermissions()
        {
            if (Session.CurrentUser == null) return;

            btnHocVien.Visible = true;
            btnKhoaHoc.Visible = true;
            btnLophoc.Visible = true;
            btnGiangVien.Visible = true;

            if (Session.CurrentUser.RoleName == "Teacher")
            {
                btnHocVien.Visible = false;   
                btnKhoaHoc.Visible = false;   
                btnGiangVien.Visible = false; 
            }

        }



        private void btnHocVien_Click(object sender, EventArgs e)
        {
            OpenForm<ManageStudents>();
        }

        private void btnLophoc_Click(object sender, EventArgs e)
        {
            OpenForm<ManageClasses>();
        }


        private void btnKhoaHoc_Click(object sender, EventArgs e)
        {
            OpenForm<ManageCourses>();
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Logout();
            var loginForm = _serviceProvider.GetRequiredService<LoginForm>();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void btnGiangVien_Click(object sender, EventArgs e)
        {
            OpenManagementForm<ManageTeachers>();
        }

        private void OpenManagementForm<T>() where T : Form
        {
            try
            {
                var form = _serviceProvider.GetRequiredService<T>();

                this.Hide();

                form.ShowDialog();

                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở form: " + ex.Message);
                this.Show(); 
            }
        }

        private void OpenForm<T>() where T : Form
        {
            try
            {
                var form = _serviceProvider.GetRequiredService<T>();

                this.Hide(); 
                form.ShowDialog(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chức năng này chưa được cài đặt hoặc lỗi khởi tạo.\nChi tiết: {ex.Message}", "Thông báo");
            }
        }


    }
}
