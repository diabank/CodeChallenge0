using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge0.Models.ViewModel
{
    public class ServiceOrder
    {
        [Display(Name = "Service Order ID")]
        public int ServiceOrderId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string ServiceDescription { get; set; }

        [Required]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        [Required]
        [Display(Name = "Date Assigned")]
        public DateTime DateAssigned { get; set; }

        public int? EmployeeId { get; set; }

        [Display(Name = "Employee Assigned")]
        public string EmployeeName { get; set; }
    }
}
