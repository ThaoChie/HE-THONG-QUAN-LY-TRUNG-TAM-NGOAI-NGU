using LCenterDAL.Context;
using LCenterDAL.DTOs;
using LCenterDAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCenterDAL.Implements
{
    public class UserDAO : IUserDAO
    {
        private readonly LCenterContext _context;
        public UserDAO(LCenterContext context) { _context = context; }

        public async Task<UserDTO> LoginAsync(string username, string passwordHash)
        {
            var result = await _context.Database.SqlQueryRaw<UserDTO>(
                "EXEC sp_Auth_Login @Username, @PasswordHash",
                new SqlParameter("@Username", username),
                new SqlParameter("@PasswordHash", passwordHash)
            ).ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<List<UserDTO>> GetByRoleAsync(string roleName)
        {
            return await _context.Database.SqlQueryRaw<UserDTO>(
                "EXEC sp_User_GetByRole @RoleName",
                new SqlParameter("@RoleName", roleName)
            ).ToListAsync();
        }

        public async Task<int> AddAsync(UserDTO dto)
        {
            var sql = "EXEC sp_User_Insert @Username, @PasswordHash, @FullName, @Email, @Phone, @RoleName, @Specialization, @IsActive";

            var result = await _context.Database.SqlQueryRaw<decimal>(
                sql,
                new SqlParameter("@Username", dto.Username),
                new SqlParameter("@PasswordHash", dto.PasswordHash ?? "123456"),
                new SqlParameter("@FullName", dto.FullName),
                new SqlParameter("@Email", dto.Email ?? (object)DBNull.Value),
                new SqlParameter("@Phone", dto.Phone ?? (object)DBNull.Value),
                new SqlParameter("@RoleName", dto.RoleName),
                new SqlParameter("@Specialization", dto.Specialization ?? (object)DBNull.Value), 
                new SqlParameter("@IsActive", dto.IsActive) 
            ).ToListAsync();

            return Convert.ToInt32(result.FirstOrDefault());
        }

        public async Task<bool> UpdateAsync(UserDTO dto)
        {
            var sql = "EXEC sp_User_Update @UserId, @FullName, @Email, @Phone, @Specialization, @IsActive";

            int rows = await _context.Database.ExecuteSqlRawAsync(
                sql,
                new SqlParameter("@UserId", dto.UserId),
                new SqlParameter("@FullName", dto.FullName),
                new SqlParameter("@Email", dto.Email ?? (object)DBNull.Value),
                new SqlParameter("@Phone", dto.Phone ?? (object)DBNull.Value), 
                new SqlParameter("@Specialization", dto.Specialization ?? (object)DBNull.Value), 
                new SqlParameter("@IsActive", dto.IsActive)
            );
            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            int rows = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_User_Delete @UserId",
                new SqlParameter("@UserId", id)
            );
            return rows > 0;
        }


        public async Task<UserDTO> GetByIdAsync(int id)
        {
            var result = await _context.Database.SqlQueryRaw<UserDTO>("EXEC sp_User_GetById @Id", new SqlParameter("@Id", id)).ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<bool> ChangePasswordAsync(int userId, string oldHash, string newHash)
        {
            var result = await _context.Database.SqlQueryRaw<int>(
                "EXEC sp_Auth_ChangePassword @UserId, @OldHash, @NewHash",
                new SqlParameter("@UserId", userId),
                new SqlParameter("@OldHash", oldHash),
                new SqlParameter("@NewHash", newHash)
            ).ToListAsync();
            return result.FirstOrDefault() == 1;
        }

        public async Task<bool> ResetPasswordAsync(int userId, string newHash)
        {
            int rows = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_Auth_ResetPassword @UserId, @NewHash",
                new SqlParameter("@UserId", userId),
                new SqlParameter("@NewHash", newHash)
            );
            return rows > 0;
        }

        public async Task<bool> UpdateRoleAsync(int userId, string newRole)
        {
            int rows = await _context.Database.ExecuteSqlRawAsync(
               "EXEC sp_User_UpdateRole @UserId, @NewRole",
               new SqlParameter("@UserId", userId),
               new SqlParameter("@NewRole", newRole)
           );
            return rows > 0;
        }
    }
}