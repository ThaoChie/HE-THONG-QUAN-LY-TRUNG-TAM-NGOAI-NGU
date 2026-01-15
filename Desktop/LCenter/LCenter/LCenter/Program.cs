using LCenter.UI; 
using LCenterBLL.BUS;
using LCenterBLL.Interfaces;
using LCenterDAL.Context;
using LCenterDAL.Implements;
using LCenterDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace LCenter
{
    static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IConfiguration Configuration { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) 
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            // 1. Khởi tạo Service Collection
            var services = new ServiceCollection();

            // 2. Cấu hình Database Context
            services.AddDbContext<LCenterContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            // 3. Đăng ký DAO (Data Access Layer)
            services.AddScoped<IStudentDAO, StudentDAO>();
            services.AddScoped<IUserDAO, UserDAO>();
            services.AddScoped<ICourseDAO, CourseDAO>();
            services.AddScoped<IClassDAO, ClassDAO>();
            services.AddScoped<IEnrollmentDAO, EnrollmentDAO>();
            services.AddScoped<IScoreDAO, ScoreDAO>();
            services.AddScoped<IStatisticDAO, StatisticDAO>();
            services.AddScoped<IAttendanceDAO, AttendanceDAO>();

            // 4. Đăng ký BUS (Business Logic Layer)
            services.AddScoped<IStudentBUS, StudentBUS>();
            services.AddScoped<IUserBUS, UserBUS>();
            services.AddScoped<ICourseBUS, CourseBUS>();
            services.AddScoped<IClassBUS, ClassBUS>();
            services.AddScoped<IEnrollmentBUS, EnrollmentBUS>();
            services.AddScoped<IScoreBUS, ScoreBUS>();
            services.AddScoped<IStatisticBUS, StatisticBUS>();
            services.AddScoped<IAttendanceBUS, AttendanceBUS>();

            // 5. Đăng ký Form (UI) - Đăng ký TẤT CẢ các form bạn có
            services.AddTransient<LoginForm>();
            services.AddTransient<MainForm>();
            services.AddTransient<ManageStudents>();
            services.AddTransient<ManageCourses>(); 
            services.AddTransient<ManageClasses>();
            services.AddTransient<ManageClassDetails>();
            services.AddTransient<ManageTeachers>();
            services.AddTransient<FormImportStudents>();
            services.AddTransient<FormEnrollment>();

            // 6. Build Provider
            ServiceProvider = services.BuildServiceProvider();

            // 7. Chạy Form Đăng nhập
            try
            {
                var loginForm = ServiceProvider.GetRequiredService<LoginForm>();
                Application.Run(loginForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi động: {ex.Message}");
            }
        }
    }
}