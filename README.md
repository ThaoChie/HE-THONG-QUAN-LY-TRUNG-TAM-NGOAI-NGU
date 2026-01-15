# 🎓 Hệ thống Quản lý Trung tâm Ngoại ngữ (LCenter)

**LCenter** là phần mềm quản lý trung tâm ngoại ngữ được xây dựng trên nền tảng **Windows Forms (.NET Core/.NET 8+)**, áp dụng mô hình kiến trúc **3 lớp (3-Layer Architecture)** và sử dụng **Entity Framework Core** để quản lý cơ sở dữ liệu.

---

## Tính năng chính (Key Features)

Hệ thống cung cấp các phân hệ quản lý toàn diện:

* ** Quản lý Hệ thống:** Đăng nhập, Phân quyền người dùng (Admin/Teacher).
* ** Quản lý Học viên:**
    * Thêm, Sửa, Xóa hồ sơ học viên.
    * Tìm kiếm học viên theo tên/SĐT.
    * **Import danh sách học viên hàng loạt từ file Excel.**
* ** Quản lý Giảng viên:** Quản lý thông tin cá nhân, chuyên môn, trạng thái hoạt động.
* ** Quản lý Khóa học:** Thiết lập các mã khóa học, học phí, thời lượng.
* *  Quản lý Lớp học:**
    * Tạo lớp học mới, xếp lịch học (Ngày bắt đầu/Kết thúc).
    * Phân công Giảng viên và Khóa học cho lớp.
    * Xem danh sách học viên trong lớp.

---

## 🛠 Công nghệ sử dụng (Tech Stack)

* **Frontend:** Windows Forms (C#).
* **Backend:** .NET 6.0 (hoặc cao hơn).
* **Database:** SQL Server.
* **ORM:** Entity Framework Core (Code First).
* **Kiến trúc:** 3-Layer (UI - BLL - DAL) + Dependency Injection (DI).
* **Thư viện bên thứ 3:**
    * `ExcelDataReader`: Xử lý nhập liệu từ Excel.
    * `Microsoft.Extensions.DependencyInjection`: Quản lý DI Container.

---

##  Cấu trúc dự án (Project Structure)
Dự án được chia thành 3 project chính:

LCenter.UI (Presentation Layer):

Chứa các Form (ManageStudents, ManageClasses...).

Xử lý sự kiện, validate dữ liệu đầu vào.

LCenterBLL (Business Logic Layer):

Chứa các Interface và Class Service (BUS).

Xử lý nghiệp vụ logic trước khi gọi xuống DAL.

LCenterDAL (Data Access Layer):

Context: Chứa LCenterContext (Cấu hình EF Core).

Entities: Các class ánh xạ bảng CSDL (Student, Teacher...).

DTOs: Data Transfer Objects (Object truyền tải dữ liệu).

Repositories: Xử lý truy vấn trực tiếp với Database.

---

## Hướng dẫn Cài đặt & Setup (Installation Guide)

Để chạy dự án này trên máy local, vui lòng làm theo các bước sau:

### 1. Yêu cầu môi trường
* Visual Studio 2022.
* SQL Server (đã cài đặt).
* .NET 6.0 SDK trở lên.

### 2. Cài đặt các gói NuGet (NuGet Packages)
Nếu Visual Studio không tự động restore packages, hãy mở **Package Manager Console** (*View -> Other Windows -> Package Manager Console*) và chạy lần lượt các lệnh sau:

**Cài đặt cho tầng DAL (Data Access Layer):**

Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.Extensions.DependencyInjection
Install-Package ExcelDataReader
Install-Package ExcelDataReader.DataSet

### 3. Cấu hình Chuỗi kết nối (Connection String)
Mở file cấu hình (ví dụ: appsettings.json, App.config hoặc trong DbContext). Tìm đoạn kết nối và sửa lại Server cho đúng với máy của bạn.

Lưu ý quan trọng: Bắt buộc phải thêm MultipleActiveResultSets=True để tránh lỗi xung đột luồng khi tải dữ liệu.

'Data Source=YOUR_SERVER_NAME;Initial Catalog=LCenterDB;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;'

### 4. Khởi tạo Database (Migration)
Dự án sử dụng EF Core Code First. Để tạo database, hãy chạy lệnh sau trong Package Manager Console:

Tại ô Default project, chọn project chứa DbContext Chạy lệnh: Update-Database
