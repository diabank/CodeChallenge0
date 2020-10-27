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
    /// Get List Of Service Order Query
    /// </summary>
    public class GetListOfServiceOrderQuery : IRequest<IEnumerable<ServiceOrder>>
    {
        public int Skip { get; set; }
        public int Take { get; set; }

        public GetListOfServiceOrderQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }

        public GetListOfServiceOrderQuery()
        {
            Skip = 0;
            Take = 100;
        }
    }

    /// <summary>
    /// Get List Of Service Order Query Handler
    /// </summary>
    public class GetListOfServiceOrderQueryHandler : BaseQueryHandler, IRequestHandler<GetListOfServiceOrderQuery, IEnumerable<ServiceOrder>>
    {
        public GetListOfServiceOrderQueryHandler(IDbService dbService, IMapper mapper) : base(dbService, mapper) { }

        public async Task<IEnumerable<ServiceOrder>> Handle(GetListOfServiceOrderQuery request, CancellationToken cancellationToken)
        {
            var results = await _DbService.GetServiceOrdersAsync(request.Skip, request.Take);
            return results.Select(_ => _mapper.Map<ServiceOrder>(_)).ToList();
        }
    }
}
