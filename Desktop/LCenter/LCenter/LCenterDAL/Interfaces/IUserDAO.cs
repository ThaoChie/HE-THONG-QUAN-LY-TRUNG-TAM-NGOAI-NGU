using LCenterDAL.DTOs;
using LCenterDAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LCenterDAL.Interfaces
{

    public interface IUserDAO
    {
        Task<UserDTO> LoginAsync(string username, string passwordHash);
        Task<List<UserDTO>> GetByRoleAsync(string roleName);
        Task<UserDTO> GetByIdAsync(int id);
        Task<int> AddAsync(UserDTO dto);
        Task<bool> UpdateAsync(UserDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> ChangePasswordAsync(int userId, string oldHash, string newHash);
        Task<bool> ResetPasswordAsync(int userId, string newHash);
        Task<bool> UpdateRoleAsync(int userId, string newRole);
    }
}
