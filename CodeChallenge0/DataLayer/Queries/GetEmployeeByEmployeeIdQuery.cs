using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CodeChallenge0.DataLayer.Services;
using CodeChallenge0.Models.ViewModel;

namespace CodeChallenge0.DataLayer.Queries
{
    /// <summary>
    /// Get Employee By Employee Id Query
    /// </summary>
    public class GetEmployeeByEmployeeIdQuery : IRequest<Employee>
    {
        public int EmployeeId { get; set; }
        public GetEmployeeByEmployeeIdQuery(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }

    /// <summary>
    /// Get Employee By Employee Id Query Handler
    /// </summary>
    public class GetEmployeeByEmployeeIdQueryHandler : BaseQueryHandler, IRequestHandler<GetEmployeeByEmployeeIdQuery, Employee>
    {
        public GetEmployeeByEmployeeIdQueryHandler(IDbService dbService, IMapper mapper) : base(dbService, mapper) { }

        public async Task<Employee> Handle(GetEmployeeByEmployeeIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _DbService.GetEmployeeByEmployeeIdAsync(request.EmployeeId);
            return _mapper.Map<Employee>(result);
        }

    }
}
