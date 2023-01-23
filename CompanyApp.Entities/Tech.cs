using CompanyApp.Core.Entities;
using System.Collections.Generic;

namespace CompanyApp.Entities
{
    public class Tech : BaseEntity
    {
        public string TechName { get; set; }
        public virtual ICollection<EmployeeTech> EmployeeTechs { get; set; }
    }
}
