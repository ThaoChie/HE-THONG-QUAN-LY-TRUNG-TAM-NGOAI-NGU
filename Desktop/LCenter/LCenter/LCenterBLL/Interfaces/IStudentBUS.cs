using LCenterDAL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LCenterBLL.Interfaces
{
    public interface IStudentBUS
    {
        Task<List<StudentDTO>> GetAllAsync(); 
        Task<StudentDTO> GetByIdAsync(int id);
        Task<int> AddAsync(StudentCreateDTO dto); 
        Task<bool> UpdateAsync(StudentDTO dto); 
        Task<bool> DeleteAsync(int id);
        Task<StudentDTO> LookupByPhoneAsync(string phone);

        Task<string> ImportStudentsBatchAsync(List<StudentDTO> listStudents);
    }
}
