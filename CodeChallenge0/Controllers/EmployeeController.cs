using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using CodeChallenge0.DataLayer.Commands;
using CodeChallenge0.DataLayer.Queries;
using CodeChallenge0.Models.ViewModel;

namespace CodeChallenge0.Controllers
{
    /// <summary>
    /// Employee Controller
    /// </summary>
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Index (entry point)
        /// Screen #3
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var result = _mediator.Send(new GetListOfEmployeeQuery());
            return View("IndexEmployee", result.Result);
        }

        /// <summary>
        /// Index function to handle Search And Sort on main page
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public IActionResult IndexForSearchAndSort(string sortOrder, string searchString)
        {
            var employees = _mediator.Send(new GetListOfEmployeeQuery()).Result;

            ViewData["CurrentFilter"] = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(_ => _.LastName.ToUpper().Contains(searchString.ToUpper())
                                              || _.FirstName.ToUpper().Contains(searchString.ToUpper()));
            }

            if (!string.IsNullOrEmpty(sortOrder))
            {
                switch (sortOrder)
                {
                    case "FirstName":
                        employees = employees.OrderBy(_ => _.FirstName);
                        break;
                    case "LastName":
                        employees = employees.OrderBy(_ => _.LastName);
                        break;
                    case "JobTitle":
                        employees = employees.OrderBy(_ => _.JobTitle);
                        break;
                }
            }

            return View("IndexEmployee", employees);
        }

        /// <summary>
        ///  Employee detail
        ///  Screen #4
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DetailEmployee(int? id)
        {
            var result = _mediator.Send(new GetEmployeeByEmployeeIdQuery(id.Value));
            return View("DetailEmployee", result.Result);
        }

        /// <summary>
        /// Launching Create Employee Blank screen
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View("CreateEmployee");
        }

        /// <summary>
        /// Create New Employee from Blank screen
        /// Pushing new model to Database
        /// </summary>
        /// <param name="newEmployee"></param>
        /// <returns></returns>
        public IActionResult CreateNewEmployee(Employee newEmployee)
        {
            try {
                _mediator.Send(new AddEmployeeCommand(newEmployee)).Wait();
            }
            catch(Exception) {
                //DbUpdateException
                //Logging //error middleware 
            }
            return Index();
        }

        /// <summary>
        /// Lauching Update Employee screen
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult UpdateEmployee(int? Id)
        {
            var model = _mediator.Send(new GetEmployeeByEmployeeIdQuery(Id.Value)).Result;
            return View("UpdateEmployee", model);
        }

        /// <summary>
        /// Update Database Employee
        /// </summary>
        /// <param name="updatedEmployee"></param>
        /// <returns></returns>
        public IActionResult UpdateDbEmployee(Employee updatedEmployee)
        {
            try {
               _mediator.Send(new UpdateEmployeeCommand(updatedEmployee)).Wait();
            }
            catch (Exception) {
                //DbUpdateException
                //Logging //error middleware 
            }
            return Index();
        }

        /// <summary>
        /// Delete Employee
        /// Launching Delete screen
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult DeleteEmployee(int? Id)
        {
            var model = _mediator.Send(new GetEmployeeByEmployeeIdQuery(Id.Value));
            return View("DeleteEmployee", model.Result);
        }

        /// <summary>
        /// Delete Database Employee
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult DeleteDbEmployee(int? Id)
        {
            try {
                _mediator.Send(new DeleteEmployeeCommand(Id.Value)).Wait();
            }
            catch (Exception) {
                //DbUpdateException
                //Logging //error middleware 
            }
            return Index();
        }
    }
}
