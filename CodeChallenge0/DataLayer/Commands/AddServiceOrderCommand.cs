using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CodeChallenge0.DataLayer.Queries;
using CodeChallenge0.DataLayer.Services;
using CodeChallenge0.Models.DbModel;
using CodeChallenge0.Models.ViewModel;

namespace CodeChallenge0.DataLayer.Commands
{
    /// <summary>
    /// Add Service Order Command
    /// </summary>
    public class AddServiceOrderCommand : IRequest
    {
        public ServiceOrder ServiceOrder { get; set; }

        public AddServiceOrderCommand(ServiceOrder serviceOrder)
        {
            ServiceOrder = serviceOrder;
        }
    }

    /// <summary>
    /// Add Service Order CommandHandler
    /// </summary>
    public class AddServiceOrderCommandHandler : BaseQueryHandler, IRequestHandler<AddServiceOrderCommand>
    {
        public AddServiceOrderCommandHandler(IDbService dbService, IMapper mapper) : base(dbService, mapper) { }

        public async Task<Unit> Handle(AddServiceOrderCommand request, CancellationToken cancellationToken)
        {
            await _DbService.AddServiceOrderAsync(_mapper.Map<TblServiceOrder>(request.ServiceOrder));
            return Unit.Value;
        }
    }
}
