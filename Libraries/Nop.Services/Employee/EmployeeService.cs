using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Data;
using Nop.Core.Domain.Employee;

namespace Nop.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<EmployeeEntity> _employeeEntity;
        public EmployeeService(IRepository<EmployeeEntity> employeeEntity)
        {
            this._employeeEntity = employeeEntity;
        }

        public void AddEmployee(EmployeeEntity employee)
        {
            _employeeEntity.Insert(employee);
        }

        public IList<EmployeeEntity> GetAllEmployee()
        {
            return _employeeEntity.Table.ToList();
        }
        public EmployeeEntity FindById(int Id)
        {
            return _employeeEntity.GetById(Id);
        }

        public void UpdateEmployee(EmployeeEntity employee)
        {
            _employeeEntity.Update(employee);
        }

        public void DeleteEmployee(EmployeeEntity employee)
        {
            _employeeEntity.Delete(employee);
        }
    }
}
