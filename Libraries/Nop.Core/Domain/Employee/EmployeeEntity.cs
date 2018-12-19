using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.Employee
{
    public partial class EmployeeEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Gender { get; set; }
    }
}
