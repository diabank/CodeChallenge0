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
    /// Add Employee Command
    /// </summary>
    public class AddEmployeeCommand : IRequest
    {
        public Employee Employee { get; set; }

        public AddEmployeeCommand(Employee employee)
        {
            Employee = employee;
        }
    }

    /// <summary>
    /// Add Employee Command Handler
    /// </summary>
    public class AddEmployeeCommandHandler : BaseQueryHandler, IRequestHandler<AddEmployeeCommand>
    {
        public AddEmployeeCommandHandler(IDbService dbService, IMapper mapper) : base(dbService, mapper) { }

        public async Task<Unit> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _DbService.AddEmployeeAsync(_mapper.Map<TblEmployee>(request.Employee));
            return Unit.Value;
        }

    }
}
