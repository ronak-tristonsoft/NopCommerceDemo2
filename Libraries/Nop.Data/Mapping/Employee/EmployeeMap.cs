using Nop.Core.Domain.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Data.Mapping.Employee
{
    class EmployeeMap:NopEntityTypeConfiguration<EmployeeEntity>
    {
        public EmployeeMap()
        {
            this.ToTable("EmployeeEntity");
            this.HasKey(c => c.Id);
            this.Property(c => c.Name);
            this.Property(c => c.Gender);
        }
    }
}
