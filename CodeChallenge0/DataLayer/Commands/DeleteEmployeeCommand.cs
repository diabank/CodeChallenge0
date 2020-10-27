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
    /// Delete Employee Command
    /// </summary>
    public class DeleteEmployeeCommand : IRequest
    {
        public int EmployeeId{ get; set; }

        public DeleteEmployeeCommand(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }

    /// <summary>
    /// Delete Employee Command Handler
    /// </summary>
    public class DeleteEmployeeCommandHandler : BaseQueryHandler, IRequestHandler<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandHandler(IDbService dbService, IMapper mapper) : base(dbService, mapper) { }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _DbService.DeleteEmployeeAsync(request.EmployeeId);
            return Unit.Value;
        }

    }
}
