using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge0.Models.DbModel
{
    public partial class TblEmployee
    {
        public TblEmployee()
        {
            TblServiceOrder = new HashSet<TblServiceOrder>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public int? YearsAtCompany { get; set; }
        public string NickName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<TblServiceOrder> TblServiceOrder { get; set; }
    }
}
