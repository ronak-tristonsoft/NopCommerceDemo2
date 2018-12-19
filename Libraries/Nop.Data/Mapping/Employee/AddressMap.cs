
using Nop.Core.Domain.Employee;

namespace Nop.Data.Mapping.Employee
{
    class AddressMap : NopEntityTypeConfiguration<AddressEntity>
    {
        public AddressMap()
        {
            this.ToTable("AddressEntity");
            this.HasKey(c => c.Id);
            this.Property(c => c.EmployeeId);
            this.Property(c => c.Address);
        }
    }
}
