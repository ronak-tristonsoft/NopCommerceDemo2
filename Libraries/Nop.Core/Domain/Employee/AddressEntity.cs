using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.Employee
{
    public partial class AddressEntity : BaseEntity
    {
        public int EmployeeId { get; set; }
        public string Address { get; set; }
    }
}
