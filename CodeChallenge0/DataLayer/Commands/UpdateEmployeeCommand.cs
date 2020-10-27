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
    /// Update Employee Command
    /// </summary>
    public class UpdateEmployeeCommand : IRequest
    {
        public Employee Employee { get; set; }

        public UpdateEmployeeCommand(Employee employee)
        {
            Employee = employee;
        }
    }

    /// <summary>
    /// Update Employee Command Handler
    /// </summary>
    public class UpdateEmployeeCommandHandler : BaseQueryHandler, IRequestHandler<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandHandler(IDbService dbService, IMapper mapper) : base(dbService, mapper) { }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _DbService.UpdateEmployeeAsync(_mapper.Map<TblEmployee>(request.Employee));
            return Unit.Value;
        }

    }
}
