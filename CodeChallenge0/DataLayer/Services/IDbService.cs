using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge0.Models.DbModel;

namespace CodeChallenge0.DataLayer.Services
{
    public interface IDbService
    {
        Task<IEnumerable<TblEmployee>> GetEmployeesAsync(int skip, int take);
        Task<TblEmployee> GetEmployeeByEmployeeIdAsync(int employeeId);
        Task AddEmployeeAsync(TblEmployee employee);
        Task UpdateEmployeeAsync(TblEmployee UpdatedEmployee);
        Task DeleteEmployeeAsync(int employeeId);
        Task<IEnumerable<TblServiceOrder>> GetServiceOrdersAsync(int skip, int take);
        Task<TblServiceOrder> GetServiceOrderByServiceOrderId(int serviceOrderId);
        Task AddServiceOrderAsync(TblServiceOrder serviceOrder);
        Task UpdateServiceOrderAsync(TblServiceOrder UpdatedServiceOrder);
        Task DeleteServiceOrderAsync(int serviceOrderId);
    }
}
