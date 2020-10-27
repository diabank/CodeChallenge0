using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge0.Models.DbModel;

namespace CodeChallenge0.DataLayer.Services
{
    /// <summary>
    /// Data Service Service Order
    /// </summary>
    public partial class DbService : IDbService
    {
        /// <summary>
        /// Get Service Orders Async
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TblServiceOrder>> GetServiceOrdersAsync(int skip, int take)
        {
            return await _databaseDbContext.TblServiceOrder
                .Where(_ => _.Active)
                //.Skip(skip)
                //.Take(take)
                .Include(_ => _.Employee)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Get Service Order By Service Order Id
        /// </summary>
        /// <param name="serviceOrderId"></param>
        /// <returns></returns>
        public async Task<TblServiceOrder> GetServiceOrderByServiceOrderId(int serviceOrderId)
        {
            return await _databaseDbContext.TblServiceOrder
                .Include(_ => _.Employee)
                .AsNoTracking()
                .FirstOrDefaultAsync(_ => _.ServiceOrderId == serviceOrderId);
        }

        /// <summary>
        /// Add Service Order Async
        /// </summary>
        /// <param name="serviceOrder"></param>
        /// <returns></returns>
        public async Task AddServiceOrderAsync(TblServiceOrder serviceOrder)
        {
            serviceOrder.Active = true;
            await _databaseDbContext.TblServiceOrder.AddAsync(serviceOrder);
            await _databaseDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Update Service Order Async
        /// </summary>
        /// <param name="UpdatedServiceOrder"></param>
        /// <returns></returns>
        public async Task UpdateServiceOrderAsync(TblServiceOrder UpdatedServiceOrder)
        {
            var serviceOrder = _databaseDbContext.TblServiceOrder.FirstOrDefaultAsync(_ => _.ServiceOrderId == UpdatedServiceOrder.ServiceOrderId).Result;
            if (null != serviceOrder)
            {
                serviceOrder.ServiceDescription = UpdatedServiceOrder.ServiceDescription;
                serviceOrder.Title = UpdatedServiceOrder.Title;
                serviceOrder.DueDate = UpdatedServiceOrder.DueDate;
                serviceOrder.DateAssigned = UpdatedServiceOrder.DateAssigned;
                serviceOrder.EmployeeId = UpdatedServiceOrder.EmployeeId;
            }
            await _databaseDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete Service Order Async
        /// </summary>
        /// <param name="serviceOrderId"></param>
        /// <returns></returns>
        public async Task DeleteServiceOrderAsync(int serviceOrderId)
        {
            var serviceOrder = _databaseDbContext.TblServiceOrder.FirstOrDefaultAsync(_ => _.ServiceOrderId == serviceOrderId).Result;
            if (null != serviceOrder)
            {
                serviceOrder.Active = false;
                await _databaseDbContext.SaveChangesAsync();
            }
        }
    }
}
