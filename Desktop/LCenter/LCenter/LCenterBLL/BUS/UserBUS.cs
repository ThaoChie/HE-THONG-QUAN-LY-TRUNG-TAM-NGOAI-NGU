using LCenterBLL.Common;
using LCenterBLL.Interfaces;
using LCenterDAL.DTOs;
using LCenterDAL.Entities;
using LCenterDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCenterBLL.BUS
{
    public class UserBUS : IUserBUS
    {
        private readonly IUserDAO _dao;
        public UserBUS(IUserDAO dao) { _dao = dao; }

        public async Task<UserDTO> LoginAsync(string username, string password)
        {
            string hash = PasswordHelper.HashPassword(password);
            return await _dao.LoginAsync(username, hash);
        }

        public Task<List<UserDTO>> GetTeachersAsync()
        {
            return _dao.GetByRoleAsync("Teacher");
        }

        public async Task<int> AddTeacherAsync(UserDTO dto)
        {
            //  Xử lý Password: Nếu chưa có thì mặc định 123456
            string rawPass = string.IsNullOrEmpty(dto.PasswordHash) ? "123456" : dto.PasswordHash;

            //  Hash Password
            dto.PasswordHash = PasswordHelper.HashPassword(rawPass);

            // 3Gán các giá trị mặc định cho Giảng viên
            dto.RoleName = "Teacher";
            dto.IsActive = true;

            return await _dao.AddAsync(dto);
        }

        public async Task<bool> UpdateTeacherAsync(UserDTO dto)
        {
            return await _dao.UpdateAsync(dto);
        }

        public async Task<bool> DeleteTeacherAsync(int id)
        {
            return await _dao.DeleteAsync(id);
        }


        public async Task<bool> ChangePasswordAsync(int userId, string oldPass, string newPass)
        {
            string oldHash = PasswordHelper.HashPassword(oldPass);
            string newHash = PasswordHelper.HashPassword(newPass);
            return await _dao.ChangePasswordAsync(userId, oldHash, newHash);
        }
    }
}
