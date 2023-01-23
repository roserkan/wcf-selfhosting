using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Core.Entities
{
    /// <summary>
    /// Common class of all entities.
    /// </summary>
    /// <remarks>
    /// Here we can define the properties that we want to be common to all entities.
    /// </remarks>
    public class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
