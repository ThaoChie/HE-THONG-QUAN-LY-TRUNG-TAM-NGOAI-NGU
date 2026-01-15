using LCenterDAL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LCenterBLL.Interfaces
{
    public interface IUserBUS
    {
        Task<UserDTO> LoginAsync(string username, string password); // Hash pass rồi gọi DAO
        Task<List<UserDTO>> GetTeachersAsync(); 
        Task<int> AddTeacherAsync(UserDTO dto); // Tự sinh pass = username/phone
        Task<bool> UpdateTeacherAsync(UserDTO dto);
        Task<bool> ChangePasswordAsync(int userId, string oldPass, string newPass);
    }

}
