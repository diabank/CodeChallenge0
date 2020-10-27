using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge0.Models.DbModel;

namespace CodeChallenge0.DataLayer.Services
{
    /// <summary>
    /// Data Service Employee
    /// </summary>
    public partial class DbService : IDbService
    {
        private readonly DatabaseDbContext _databaseDbContext;
        public DbService(DatabaseDbContext DatabaseDbContext)
        {
            _databaseDbContext = DatabaseDbContext;
        }

        /// <summary>
        /// Get Employees Async
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TblEmployee>> GetEmployeesAsync(int skip, int take)
        {
            return await _databaseDbContext.TblEmployee
                            .Where(_ => _.Active)
                            //.Skip(skip)
                            //.Take(take)
                            .AsNoTracking()
                            .ToListAsync();

        }

        /// <summary>
        /// Get Employee By Employee Id Async
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<TblEmployee> GetEmployeeByEmployeeIdAsync(int employeeId)
        {
            return await _databaseDbContext.TblEmployee
                .AsNoTracking()
                .FirstOrDefaultAsync(_ => _.EmployeeId == employeeId);
        }

        /// <summary>
        /// Add Employee Async
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task AddEmployeeAsync(TblEmployee employee)
        {
            employee.Active = true;
            await _databaseDbContext.TblEmployee.AddAsync(employee);
            await _databaseDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Update Employee Async
        /// </summary>
        /// <param name="UpdatedEmployee"></param>
        /// <returns></returns>
        public async Task UpdateEmployeeAsync(TblEmployee UpdatedEmployee)
        {
            var employee = _databaseDbContext.TblEmployee.FirstOrDefaultAsync(_ => _.EmployeeId == UpdatedEmployee.EmployeeId).Result;
            if (null != employee)
            {
                employee.LastName = UpdatedEmployee.LastName;
                employee.FirstName = UpdatedEmployee.FirstName;
                employee.NickName = UpdatedEmployee.NickName;
                employee.YearsAtCompany = UpdatedEmployee.YearsAtCompany;
                employee.JobTitle = UpdatedEmployee.JobTitle;
            }
            await _databaseDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete EmployeeAsync
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var employee = _databaseDbContext.TblEmployee.FirstOrDefaultAsync(_ => _.EmployeeId == employeeId).Result;
            if (null != employee)
            {
                employee.Active = false;
                await _databaseDbContext.SaveChangesAsync();
            }
        }
    }
}
