using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CodeChallenge0.DataLayer.Queries;
using CodeChallenge0.DataLayer.Services;

namespace CodeChallenge0.DataLayer.Commands
{
    /// <summary>
    /// Delete Service Order Command
    /// </summary>
    public class DeleteServiceOrderCommand : IRequest
    {
        public int ServiceOrderId { get; set; }

        public DeleteServiceOrderCommand(int serviceOrderId)
        {
            ServiceOrderId = serviceOrderId;
        }
    }

    /// <summary>
    /// Delete Service Order Command Handler
    /// </summary>
    public class DeleteServiceOrderCommandHandler : BaseQueryHandler, IRequestHandler<DeleteServiceOrderCommand>
    {
        public DeleteServiceOrderCommandHandler(IDbService dbService, IMapper mapper) : base(dbService, mapper) { }

        public async Task<Unit> Handle(DeleteServiceOrderCommand request, CancellationToken cancellationToken)
        {
            await _DbService.DeleteServiceOrderAsync(request.ServiceOrderId);
            return Unit.Value;
        }

    }
}
