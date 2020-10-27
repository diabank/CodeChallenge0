using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge0.Models.DbModel
{
    public partial class TblServiceOrder
    {
        public int ServiceOrderId { get; set; }
        public string Title { get; set; }
        public string ServiceDescription { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime DateAssigned { get; set; }
        public bool Active { get; set; }
        public int? EmployeeId { get; set; }

        public virtual TblEmployee Employee { get; set; }
    }
}
