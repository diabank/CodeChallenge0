using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge0.Models.ViewModel
{
    public class Employee
    {
        [Display(Name = "ID")]
        public int EmployeeId { get; set; }
       
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [Display(Name = "Years At Company")]
        public int YearsAtCompany { get; set; }
       
        [Display(Name = "Nick Name")]
        public string NickName { get; set; }

        public string wholeName { get; set; }
    }
}
