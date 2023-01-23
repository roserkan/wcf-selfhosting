using CompanyApp.Core.Entities;
using System;

namespace CompanyApp.Entities
{
    public class EmployeeTech : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public Guid TechId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Tech Tech { get; set; }
    }
}
