using LCenterDAL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LCenterBLL.Interfaces
{
    public interface IClassBUS
    {
        Task<List<ClassDTO>> GetAllAsync(); 
        Task<int> AddAsync(ClassInputDTO dto);
        Task<bool> UpdateAsync(ClassInputDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
