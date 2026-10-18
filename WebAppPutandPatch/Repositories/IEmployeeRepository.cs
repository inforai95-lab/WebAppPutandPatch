using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPutandPatch.Models;

namespace WebAppPutandPatch.Repositories
{
   public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task<Employee> CreateAsync(Employee employee);
        Task<bool> UpdateAsync(Employee employee);
        Task<bool> DeleteAsync(int id);
        Task<bool> PatchAsync(int id, Action<Employee> patchAction);


    }
}
