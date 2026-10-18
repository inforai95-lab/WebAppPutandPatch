using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPutandPatch.Data;
using WebAppPutandPatch.Models;

namespace WebAppPutandPatch.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.AsNoTracking().ToListAsync(); 
        }
        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<Employee> CreateAsync(
            Employee employee)
        {
            await _context.Employees.AddAsync(employee);

            await _context.SaveChangesAsync();

            return employee;
        }
        public async Task<bool> UpdateAsync(Employee employee)
        {
            var existingEmployee =
                await _context.Employees
                    .FirstOrDefaultAsync(e => e.Id == employee.Id);

            if (existingEmployee == null)
            {
                return false;
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.City = employee.City;
            existingEmployee.Salary = employee.Salary;

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var employee =
                await _context.Employees
                    .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                return false;
            }

            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> PatchAsync(int id,Action<Employee> patchAction)
        {
            var employee =
                await _context.Employees
                    .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                return false;
            }

            patchAction(employee);

            await _context.SaveChangesAsync();

            return true;
        }

    }
}
