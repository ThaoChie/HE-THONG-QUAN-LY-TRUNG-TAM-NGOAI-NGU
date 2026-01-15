using LCenterDAL.DTOs;
using LCenterDAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LCenterDAL.Interfaces
{

    public interface IClassDAO
    {
        Task<List<ClassDTO>> GetAllAsync();
        Task<ClassDTO> GetByIdAsync(int id);
        Task<int> AddAsync(Class c);
        Task<bool> UpdateAsync(Class c);
        Task<bool> DeleteAsync(int id);
    }
}
