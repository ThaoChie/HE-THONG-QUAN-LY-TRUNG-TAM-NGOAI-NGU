


using LCenterBLL.Common; 
using LCenterBLL.Interfaces;
using LCenterDAL.DTOs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
namespace LCenter
{
    public partial class LoginForm : Form
    {
        private readonly IUserBUS _userBUS;
        private readonly IServiceProvider _serviceProvider;
        private bool _isLoginSuccess = false;

        public LoginForm(IUserBUS userBUS, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _userBUS = userBUS;
            _serviceProvider = serviceProvider;
            this.AcceptButton = btnDangNhap;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnDangNhap;
            this.CancelButton = btnThoat;
            this.ActiveControl = txtUsername;
            txtPassword.UseSystemPasswordChar = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();

                e.SuppressKeyPress = true;
            }
        }

        private async void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            try  
            {
                btnDangNhap.Enabled = false; 

                var user = await _userBUS.LoginAsync(username, password);

                if (user != null)
                {
                    // Lưu vào Session
                    Session.CurrentUser = user;

                    var mainForm = _serviceProvider.GetRequiredService<MainForm>();
                    this.Hide();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
            finally
            {
                btnDangNhap.Enabled = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show( "Bạn có chắc chắn muốn thoát chương trình không?",
                                                    "Xác nhận thoát",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isLoginSuccess) return;

            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
