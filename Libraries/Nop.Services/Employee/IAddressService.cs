using Nop.Core.Domain.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Employee
{
    public partial interface IAddressService
    {
        IList<AddressEntity> GetAddress();
        void ADD(AddressEntity address);
        AddressEntity FindById(int Id);
        void UpdateAddress(AddressEntity address);
        void DeleteAddress(AddressEntity address);
    }
}
