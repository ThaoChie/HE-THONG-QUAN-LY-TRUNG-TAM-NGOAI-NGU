using LCenterBLL.Common;
using LCenterBLL.Interfaces;
using LCenterDAL.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LCenter.UI
{
    public partial class ManageClassDetails : Form
    {
        private readonly IEnrollmentBUS _enrollBUS;
        private readonly IScoreBUS _scoreBUS;
        private readonly IStudentBUS _studentBUS;
        private readonly IAttendanceBUS _attBUS;

        private List<ScoreDTO> _rawScoreList;
        private List<AttendanceDTO> _rawAttList;

        private int _currentClassId;
        private StudentDTO _foundStudent;

        public ManageClassDetails(IEnrollmentBUS enrollBUS, IScoreBUS scoreBUS, IStudentBUS studentBUS, IAttendanceBUS attBUS)
        {
            InitializeComponent(); 
            _enrollBUS = enrollBUS;
            _scoreBUS = scoreBUS;
            _studentBUS = studentBUS;
            _attBUS = attBUS;
        }

        public void SetClassInfo(int classId, string className)
        {
            _currentClassId = classId;
            lblClassName.Text = "Đang quản lý: " + className;
        }

        private async void ManageClassDetails_Load(object sender, EventArgs e)
        {
            if (_currentClassId <= 0) return;

            ApplyPermissions();

            if (Session.CurrentUser.RoleName != "Teacher")
            {
                await LoadEnrollments();
            }
            await LoadScores();
            await LoadAttendance();
        }

        private void ApplyPermissions()
        {
            if (Session.CurrentUser == null) return;
            if (Session.CurrentUser.RoleName == "Teacher")
            {
                if (GhiDanh.TabPages.Contains(tabPage1)) GhiDanh.TabPages.Remove(tabPage1);
            }
            else
            {
                if (!GhiDanh.TabPages.Contains(tabPage1)) GhiDanh.TabPages.Insert(0, tabPage1);

                btnRemove.Visible = true;
                btnAddStudent.Visible = true;
                txtPhoneLookup.Enabled = true;
                btnLookup.Enabled = true;

                btnBatch.Enabled = true;
            }
        }

        // --- TAB 1: GHI DANH ---
        private async Task LoadEnrollments()
        {
            try
            {
                var list = await _enrollBUS.GetStudentsInClassAsync(_currentClassId);
                dgvStudents.DataSource = list;

                if (dgvStudents.Columns["EnrollmentId"] != null) dgvStudents.Columns["EnrollmentId"].Visible = false;
                if (dgvStudents.Columns["StudentId"] != null) dgvStudents.Columns["StudentId"].Visible = false;
                if (dgvStudents.Columns["ClassId"] != null) dgvStudents.Columns["ClassId"].Visible = false;

                if (dgvStudents.Columns["StudentName"] != null)
                {
                    dgvStudents.Columns["StudentName"].HeaderText = "Họ và Tên";
                    dgvStudents.Columns["StudentName"].DisplayIndex = 0; 
                }
                if (dgvStudents.Columns["Phone"] != null) dgvStudents.Columns["Phone"].HeaderText = "Số điện thoại";
                if (dgvStudents.Columns["EnrollmentDate"] != null)
                {
                    dgvStudents.Columns["EnrollmentDate"].HeaderText = "Ngày ghi danh";
                    dgvStudents.Columns["EnrollmentDate"].DefaultCellStyle.Format = "dd/MM/yyyy"; 
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void btnLookup_Click(object sender, EventArgs e)
        {
            string p = txtPhoneLookup.Text.Trim(); if (string.IsNullOrEmpty(p)) return;
            _foundStudent = await _studentBUS.LookupByPhoneAsync(p);
            if (_foundStudent != null)
            {
                lblStudentInfo.Text = $"Tìm thấy: {_foundStudent.FullName}"; lblStudentInfo.ForeColor = Color.Green;
                if (Session.CurrentUser.RoleName != "Teacher") btnAddStudent.Enabled = true;
            }
            else { lblStudentInfo.Text = "Không tìm thấy!"; lblStudentInfo.ForeColor = Color.Red; btnAddStudent.Enabled = false; }
        }

        private async void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUser.RoleName == "Teacher" || _foundStudent == null) return;
            try
            {
                if (await _enrollBUS.EnrollStudentAsync(_foundStudent.StudentId, _currentClassId) > 0)
                {
                    MessageBox.Show("Thành công!"); await LoadEnrollments(); await LoadScores(); await LoadAttendance();
                    btnAddStudent.Enabled = false; txtPhoneLookup.Clear(); lblStudentInfo.Text = "...";
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUser.RoleName == "Teacher") return;
            if (dgvStudents.CurrentRow?.DataBoundItem is EnrollmentDTO item)
            {
                if (MessageBox.Show("Xóa?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (await _enrollBUS.RemoveStudentAsync(item.EnrollmentId))
                    {
                        MessageBox.Show("Đã xóa!"); await LoadEnrollments(); await LoadScores(); await LoadAttendance();
                    }
                }
            }
        }

        // --- TAB 2: CHẤM ĐIỂM ---
        private async Task LoadScores()
        {
            try
            {
                var students = await _enrollBUS.GetStudentsInClassAsync(_currentClassId);

                _rawScoreList = await _scoreBUS.GetScoreBoardAsync(_currentClassId);

                DataTable dt = new DataTable();
                dt.Columns.Add("StudentName");
                dt.Columns.Add("Phone");
                dt.Columns.Add("EnrollmentId", typeof(int)); 

                var types = new List<string>();
                if (_rawScoreList != null && _rawScoreList.Count > 0)
                {
                    types = _rawScoreList.Select(s => s.ScoreType).Distinct().ToList();
                    foreach (var t in types)
                    {
                        dt.Columns.Add(t, typeof(double));
                    }
                }

                foreach (var s in students)
                {
                    DataRow r = dt.NewRow();
                    r["StudentName"] = s.StudentName;
                    r["EnrollmentId"] = s.EnrollmentId;

                    if (_rawScoreList != null)
                    {
                        var studentScores = _rawScoreList.Where(x => x.EnrollmentId == s.EnrollmentId);
                        foreach (var sc in studentScores)
                        {
                            if (dt.Columns.Contains(sc.ScoreType))
                                r[sc.ScoreType] = sc.ScoreValue;
                        }
                    }
                    dt.Rows.Add(r);
                }

                dgvScores.DataSource = dt;

                if (dgvScores.Columns["EnrollmentId"] != null) dgvScores.Columns["EnrollmentId"].Visible = false;

                if (dgvScores.Columns["StudentName"] != null)
                {
                    dgvScores.Columns["StudentName"].HeaderText = "Họ và Tên";
                    dgvScores.Columns["StudentName"].ReadOnly = true; 
                    dgvScores.Columns["StudentName"].Frozen = true;   
                }

                foreach (var t in types)
                {
                    if (dgvScores.Columns[t] != null)
                    {
                        dgvScores.Columns[t].DefaultCellStyle.BackColor = Color.LightYellow;
                        dgvScores.Columns[t].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load điểm: " + ex.Message);
            }
        }

        private async void btnSaveScore_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = dgvScores.DataSource as DataTable; if (dt == null) return;
                List<ScoreDTO> list = new List<ScoreDTO>();
                foreach (DataRow r in dt.Rows)
                {
                    string name = r["StudentName"].ToString();
                    foreach (DataColumn c in dt.Columns)
                    {
                        if (c.ColumnName == "StudentName") continue;
                        var dto = _rawScoreList.FirstOrDefault(s => s.StudentName == name && s.ScoreType == c.ColumnName);
                        if (dto != null && double.TryParse(r[c.ColumnName].ToString(), out double val))
                        {
                            if (dto.ScoreValue != val) list.Add(new ScoreDTO { ScoreId = dto.ScoreId, ScoreValue = val });
                        }
                    }
                }
                if (list.Count > 0 && await _scoreBUS.SaveScoreBoardAsync(list)) { MessageBox.Show("Lưu thành công!"); await LoadScores(); }
                else MessageBox.Show("Không có thay đổi.");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu điểm: " + ex.Message); await LoadScores(); }
        }

        private async void btnAddColumn_Click(object sender, EventArgs e)
        {
            string name = InputBox.Show("Nhập tên đầu điểm:", "Thêm Cột");
            if (string.IsNullOrWhiteSpace(name)) return;
            if (await _scoreBUS.AddNewScoreColumnAsync(_currentClassId, name)) { MessageBox.Show("Thành công!"); await LoadScores(); }
        }

        private void dgvScores_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvScores.Columns[e.ColumnIndex].Name;
            if (colName == "StudentName") return;
            var isScoreColumn = _rawScoreList.Any(s => s.ScoreType == colName);
            if (isScoreColumn)
            {
                var row = dgvScores.Rows[e.RowIndex];
                string studentName = row.Cells["StudentName"].Value.ToString();
                string newValStr = row.Cells[e.ColumnIndex].Value?.ToString();

                if (!double.TryParse(newValStr, out double newVal)) { MessageBox.Show("Vui lòng nhập số!"); RevertCell(row, colName, studentName); return; }
                if (newVal < 0 || newVal > 10) { MessageBox.Show("Điểm phải từ 0-10!"); RevertCell(row, colName, studentName); return; }
            }
        }

        private void RevertCell(DataGridViewRow row, string colName, string studentName)
        {
            var oldItem = _rawScoreList.FirstOrDefault(s => s.StudentName == studentName && s.ScoreType == colName);
            row.Cells[colName].Value = oldItem != null ? oldItem.ScoreValue : 0;
        }

        // --- TAB 3: ĐIỂM DANH ---
        private async Task LoadAttendance()
        {
            try
            {
                _rawAttList = await _attBUS.GetAttendanceListAsync(_currentClassId);
                var students = await _enrollBUS.GetStudentsInClassAsync(_currentClassId);

                DataTable dt = new DataTable();

                dt.Columns.Add("StudentName");
                dt.Columns.Add("EnrollmentId", typeof(int)); 
                dt.Columns.Add("Phone");

                var dates = _rawAttList.Select(x => x.AttendanceDate).Distinct().OrderBy(d => d).ToList();
                foreach (var d in dates)
                {
                    string colName = d.ToString("dd/MM/yyyy");
                    int i = 1;
                    while (dt.Columns.Contains(colName)) colName = d.ToString("dd/MM/yyyy") + $"_{i++}";
                    dt.Columns.Add(colName, typeof(bool));
                }

                foreach (var s in students)
                {
                    DataRow r = dt.NewRow();
                    r["StudentName"] = s.StudentName;
                    r["EnrollmentId"] = s.EnrollmentId;
                    r["Phone"] = s.Phone;

                    var atts = _rawAttList.Where(a => a.EnrollmentId == s.EnrollmentId);
                    foreach (var a in atts)
                    {
                        string col = a.AttendanceDate.ToString("dd/MM/yyyy");
                        if (dt.Columns.Contains(col)) r[col] = a.IsPresent;
                    }
                    dt.Rows.Add(r);
                }

                dgvAttendance.DataSource = null;
                dgvAttendance.Columns.Clear();

                dgvAttendance.AutoGenerateColumns = true;
                dgvAttendance.DataSource = dt;

                if (dgvAttendance.Columns.Contains("EnrollmentId"))
                    dgvAttendance.Columns["EnrollmentId"].Visible = false;

                if (dgvAttendance.Columns.Contains("StudentName"))
                {
                    dgvAttendance.Columns["StudentName"].HeaderText = "Họ và Tên";
                    dgvAttendance.Columns["StudentName"].Width = 200;

                    dgvAttendance.Columns["StudentName"].Frozen = true;

                    dgvAttendance.Columns["StudentName"].ReadOnly = true;
                }

                if (dgvAttendance.Columns.Contains("Phone"))
                {
                    dgvAttendance.Columns["Phone"].HeaderText = "Số điện thoại";
                    dgvAttendance.Columns["Phone"].Width = 120;
                    dgvAttendance.Columns["Phone"].ReadOnly = true;
                }

                foreach (DataGridViewColumn col in dgvAttendance.Columns)
                {
                    if (col.Name != "StudentName" && col.Name != "Phone" && col.Name != "EnrollmentId")
                    {
                        col.Width = 60;
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị điểm danh: " + ex.Message);
            }
        }

        private async void btnAddDate_Click(object sender, EventArgs e)
        {
            try { if (await _attBUS.AddAttendanceDateAsync(_currentClassId, DateTime.Now.Date)) { MessageBox.Show("Đã thêm ngày!"); await LoadAttendance(); } }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void btnSaveAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = dgvAttendance.DataSource as DataTable; if (dt == null) return;
                List<AttendanceDTO> list = new List<AttendanceDTO>();
                foreach (DataRow r in dt.Rows)
                {
                    int eid = (int)r["EnrollmentId"];
                    foreach (DataColumn c in dt.Columns)
                    {
                        if (c.ColumnName == "EnrollmentId" || c.ColumnName == "StudentName" || c.ColumnName == "Phone") continue;
                        bool val = r[c.ColumnName] != DBNull.Value && (bool)r[c.ColumnName];
                        var dto = _rawAttList.FirstOrDefault(a => a.EnrollmentId == eid && a.AttendanceDate.ToString("dd/MM/yyyy") == c.ColumnName);
                        if (dto != null && dto.IsPresent != val) list.Add(new AttendanceDTO { AttendanceId = dto.AttendanceId, IsPresent = val });
                    }
                }
                if (list.Count > 0 && await _attBUS.SaveAttendanceListAsync(list)) { MessageBox.Show("Lưu thành công!"); await LoadAttendance(); }
                else MessageBox.Show("Không có thay đổi.");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); await LoadAttendance(); }
        }

        private void btnExport_Click(object sender, EventArgs e) { if (dgvScores.Rows.Count > 0) ExportToCSV(dgvScores, "BangDiem"); }

        private void ExportToCSV(DataGridView dgv, string n)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog(); sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = n + "_" + DateTime.Now.ToString("ddMMyyyy_HHmm") + ".csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                    {
                        string h = ""; foreach (DataGridViewColumn c in dgv.Columns) if (c.Visible) h += "\"" + c.HeaderText + "\","; sw.WriteLine(h.TrimEnd(','));
                        foreach (DataGridViewRow r in dgv.Rows) { if (!r.IsNewRow) { string l = ""; foreach (DataGridViewCell c in r.Cells) if (dgv.Columns[c.ColumnIndex].Visible) l += "\"" + c.Value?.ToString() + "\","; sw.WriteLine(l.TrimEnd(',')); } }
                    }
                    MessageBox.Show("Xuất file thành công!");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnBack_Click_1(object sender, EventArgs e) => this.Close();

        public static class InputBox
        {
            public static string Show(string p, string t)
            {
                Form f = new Form() { Width = 500, Height = 230, Text = t, StartPosition = FormStartPosition.CenterScreen, Font = new Font("Segoe UI", 10F) };
                Label l = new Label() { Left = 20, Top = 20, Text = p, AutoSize = true, MaximumSize = new Size(440, 0) };
                TextBox tb = new TextBox() { Left = 20, Top = 60, Width = 440 };
                Button b1 = new Button() { Text = "OK", Left = 260, Top = 120, DialogResult = DialogResult.OK, BackColor = Color.SteelBlue, ForeColor = Color.White };
                Button b2 = new Button() { Text = "Hủy", Left = 360, Top = 120, DialogResult = DialogResult.Cancel };
                b1.Click += (s, e) => f.Close(); b2.Click += (s, e) => f.Close();
                f.Controls.AddRange(new Control[] { l, tb, b1, b2 }); f.AcceptButton = b1; f.Shown += (s, e) => tb.Focus();
                return f.ShowDialog() == DialogResult.OK ? tb.Text : "";
            }
        }

        private async void btnBatch_Click(object sender, EventArgs e)
        {
            if (_currentClassId == 0) return;

            try
            {
                // Mở form Import
                FormEnrollment frm = new FormEnrollment(_currentClassId, _studentBUS, _enrollBUS);
                frm.ShowDialog();

                await LoadEnrollments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}