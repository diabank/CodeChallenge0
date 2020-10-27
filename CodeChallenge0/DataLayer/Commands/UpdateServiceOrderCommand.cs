using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CodeChallenge0.DataLayer.Queries;
using CodeChallenge0.DataLayer.Services;
using CodeChallenge0.Models.DbModel;
using CodeChallenge0.Models.ViewModel;

namespace CodeChallenge0.DataLayer.Commands
{
    /// <summary>
    /// Update Service Order Command
    /// </summary>
    public class UpdateServiceOrderCommand : IRequest
    {
        public ServiceOrder ServiceOrder { get; set; }

        public UpdateServiceOrderCommand(ServiceOrder serviceOrder)
        {
            ServiceOrder = serviceOrder;
        }
    }

    /// <summary>
    /// Update Service Order Command Handler
    /// </summary>
    public class UpdateServiceOrderCommandHandler : BaseQueryHandler, IRequestHandler<UpdateServiceOrderCommand>
    {
        public UpdateServiceOrderCommandHandler(IDbService dbService, IMapper mapper) : base(dbService, mapper) { }

        public async Task<Unit> Handle(UpdateServiceOrderCommand request, CancellationToken cancellationToken)
        {
            await _DbService.UpdateServiceOrderAsync(_mapper.Map<TblServiceOrder>(request.ServiceOrder));
            return Unit.Value;
        }

    }
}
