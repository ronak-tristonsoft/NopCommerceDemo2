using Nop.Core.Domain.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Employee
{
    public partial interface IEmployeeService
    {
        IList<EmployeeEntity> GetAllEmployee();
        void AddEmployee(EmployeeEntity employee);
        void DeleteEmployee(EmployeeEntity employee);
        EmployeeEntity FindById(int Id);
        void UpdateEmployee(EmployeeEntity employee);
    }
}
