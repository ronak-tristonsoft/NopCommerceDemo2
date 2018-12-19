using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Data;
using Nop.Core.Domain.Employee;

namespace Nop.Services.Employee
{
    public partial class AddressService : IAddressService
    {
        private readonly IRepository<AddressEntity> _addressEntity;
        public AddressService(IRepository<AddressEntity> addressEntity)
        {
            this._addressEntity = addressEntity;
        }

        public void ADD(AddressEntity address)
        {
            _addressEntity.Insert(address);
        }

        public IList<AddressEntity> GetAddress()
        {
            return _addressEntity.Table.ToList();
        }
        public AddressEntity FindById(int Id)
        {
            AddressEntity address = new AddressEntity();
            address.EmployeeId = Id;
            return _addressEntity.GetById(address.EmployeeId);
        }

        public void UpdateAddress(AddressEntity address)
        {
            _addressEntity.Update(address);
        }

        public void DeleteAddress(AddressEntity address)
        {
            _addressEntity.Delete(address);
        }
    }
}
