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
    /// Get Service Order By Service Order Id Query
    /// </summary>
    public class GetServiceOrderByServiceOrderIdQuery : IRequest<ServiceOrder>
    {
        public int ServiceOrderId { get; set; }
        public GetServiceOrderByServiceOrderIdQuery(int serviceOrderId)
        {
            ServiceOrderId = serviceOrderId;
        }
    }

    /// <summary>
    /// Get Service Order By Service Order Id Query Handler
    /// </summary>
    public class GetServiceOrderByServiceOrderIdQueryHandler : BaseQueryHandler, IRequestHandler<GetServiceOrderByServiceOrderIdQuery, ServiceOrder>
    {
        public GetServiceOrderByServiceOrderIdQueryHandler(IDbService dbService, IMapper mapper) : base(dbService, mapper) { }

        public async Task<ServiceOrder> Handle(GetServiceOrderByServiceOrderIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _DbService.GetServiceOrderByServiceOrderId(request.ServiceOrderId);
            return _mapper.Map<ServiceOrder>(result);
        }

    }
}
