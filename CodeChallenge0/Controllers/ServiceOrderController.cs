using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using CodeChallenge0.DataLayer.Commands;
using CodeChallenge0.DataLayer.Queries;
using CodeChallenge0.Models.ViewModel;

namespace CodeChallenge0.Controllers
{
    /// <summary>
    /// Service Order Controller
    /// </summary>
    public class ServiceOrderController : Controller
    {
        private readonly IMediator _mediator;

        public ServiceOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Index (Entry point)
        /// Screen #1
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var result = _mediator.Send(new GetListOfServiceOrderQuery());
            return View("IndexServiceOrder", result.Result);
        }

        /// <summary>
        /// Screen #1A
        /// Index function to handle Search And Sort on main page
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public IActionResult IndexForSearchAndSort(string sortOrder, string searchString)
        {
            var serviceOrders = _mediator.Send(new GetListOfServiceOrderQuery()).Result;

            ViewData["CurrentFilter"] = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                serviceOrders = serviceOrders.Where(_ => _.Title.ToUpper().Contains(searchString.ToUpper())
                                              || _.ServiceDescription.ToUpper().Contains(searchString.ToUpper())
                                              || _.ServiceOrderId.ToString().Contains(searchString)
                                              || _.EmployeeName.ToUpper().Contains(searchString.ToUpper()));
            }

            if (!string.IsNullOrEmpty(sortOrder))
            {
                switch (sortOrder)
                {
                    case "DueDate":
                        serviceOrders = serviceOrders.OrderBy(_ => _.DueDate);
                        break;
                    case "DateAssigned":
                        serviceOrders = serviceOrders.OrderBy(_ => _.DateAssigned);
                        break;
                    case "EmployeeName":
                        serviceOrders = serviceOrders.OrderBy(_ => _.EmployeeName);
                        break;
                    case "Title":
                        serviceOrders = serviceOrders.OrderBy(_ => _.Title);
                        break;
                    case "ServiceOrderId":
                        serviceOrders = serviceOrders.OrderBy(_ => _.ServiceOrderId);
                        break;
                }
            }

            return View("IndexServiceOrder", serviceOrders);
        }

        /// <summary>
        /// Detail Service Order
        /// Screen #2
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DetailServiceOrder(int? id)
        {
            var result = _mediator.Send(new GetServiceOrderByServiceOrderIdQuery(id.Value));
            return View("DetailServiceOrder", result.Result);
        }

        /// <summary>
        /// Launching Create Blank screen
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            var employeeList = _mediator.Send(new GetListOfEmployeeQuery()).Result.ToList();
            
            //Create dropdownlist with employee name
            ViewBag.Employees = new SelectList(employeeList, "EmployeeId", "wholeName");
            return View("CreateServiceOrder");
        }

        /// <summary>
        /// Create New Service Order
        /// pushing new model to Database
        /// </summary>
        /// <param name="newServiceOrder"></param>
        /// <returns></returns>
        public IActionResult CreateNewServiceOrder(ServiceOrder newServiceOrder)
        {
            try  {
                _mediator.Send(new AddServiceOrderCommand(newServiceOrder)).Wait();
            }
            catch (Exception) {
                //DbUpdateException
                //Logging //error middleware 
            }
            return Index();
        }

        /// <summary>
        /// Launching Update Service Order screen
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult UpdateServiceOrder(int? Id)
        {
            var model = _mediator.Send(new GetServiceOrderByServiceOrderIdQuery(Id.Value)).Result;
            return View("UpdateServiceOrder", model);
        }

        /// <summary>
        /// Update Database Service Order
        /// </summary>
        /// <param name="updatedServiceOrder"></param>
        /// <returns></returns>
        public IActionResult UpdateDbServiceOrder(ServiceOrder updatedServiceOrder)
        {
            try {
                _mediator.Send(new UpdateServiceOrderCommand(updatedServiceOrder)).Wait();
            }
            catch (Exception) {
                //DbUpdateException
                //Logging //error middleware 
            }
            return Index();
        }

        /// <summary>
        /// Delete Service Order
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult DeleteServiceOrder(int? Id)
        {
            var model = _mediator.Send(new GetServiceOrderByServiceOrderIdQuery(Id.Value));
            return View("DeleteServiceOrder", model.Result);
        }

        /// <summary>
        /// Delete Database Service Order
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult DeleteDbServiceOrder(int? Id)
        {
            try {
                _mediator.Send(new DeleteServiceOrderCommand(Id.Value)).Wait();
            }
            catch (Exception) {
                //DbUpdateException
                //Logging //error middleware 
            }
            return Index();
        }
    }
}
