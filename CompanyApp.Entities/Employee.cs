using CompanyApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Entities
{
    public class Employee : BaseEntity
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public virtual ICollection<EmployeeTech> EmployeeTechs { get; set; }


    }
}
