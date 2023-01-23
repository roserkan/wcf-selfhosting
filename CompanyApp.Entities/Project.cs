using CompanyApp.Core.Entities;
using System.Collections.Generic;

namespace CompanyApp.Entities
{
    public class Project : BaseEntity
    {
        public string ProjectName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
