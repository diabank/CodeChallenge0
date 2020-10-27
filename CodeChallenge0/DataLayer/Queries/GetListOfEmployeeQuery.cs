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
    /// Get List Of Employee Query
    /// </summary>
    public class GetListOfEmployeeQuery : IRequest<IEnumerable<Employee>>
    {
        public int Skip { get; set;}
        public int Take { get; set;}

        public GetListOfEmployeeQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }

        public GetListOfEmployeeQuery()
        {
            Skip = 0;
            Take = 100;
        }
    }

    /// <summary>
    /// Get List Of Employee Query Handler
    /// </summary>
    public class GetListOfEmployeeQueryHandler : BaseQueryHandler, IRequestHandler<GetListOfEmployeeQuery, IEnumerable<Employee>>
    {
        public GetListOfEmployeeQueryHandler(IDbService dbService, IMapper mapper) : base(dbService, mapper) { }

        public async Task<IEnumerable<Employee>> Handle(GetListOfEmployeeQuery request, CancellationToken cancellationToken)
        {
            var results = await _DbService.GetEmployeesAsync(request.Skip, request.Take);
            return results.Select(_ => _mapper.Map<Employee>(_)).ToList();
        }
    }
}
