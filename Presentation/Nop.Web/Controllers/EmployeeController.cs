using Nop.Core.Domain.Employee;
using Nop.Services.Employee;
using Nop.Web.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nop.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IAddressService addressService, IEmployeeService employeeService)
        {
            this._addressService = addressService;
            this._employeeService = employeeService;
        }
       [HttpGet]
        public ActionResult ListofEmp()
        {
            var EmployeeList = _employeeService.GetAllEmployee();
            var AddressList = _addressService.GetAddress();
            Employee_Address_ListModel Model = new Employee_Address_ListModel();

            var query =
                    from Emp in EmployeeList
                    join Add in AddressList on Emp.Id equals Add.EmployeeId
                    select new { Emp.Id, Emp.Name, Emp.Gender, Add.Address };

            foreach (var item in query)
            {
                Model.employee_Address_ListModels.Add(new Employee_Address_ListModel {
                    Id = item.Id,
                    Name = item.Name,
                    Gender = item.Gender,
                    Address = item.Address,
                });
            }
            return View(Model);
        }

        public ActionResult Create()
        {
            Employee_Address_ListModel Model = new Employee_Address_ListModel();
            return View(Model);
        }

        [HttpPost]
        public ActionResult Create(Employee_Address_ListModel Model)
        {
            EmployeeEntity employee = new EmployeeEntity();
            AddressEntity addressEntity = new AddressEntity();

            employee.Name = Model.Name;
            employee.Gender = Model.Gender;
            _employeeService.AddEmployee(employee);

            addressEntity.Address = Model.Address;
            addressEntity.EmployeeId = employee.Id;
           
            _addressService.ADD(addressEntity);

            return RedirectToAction("ListofEmp");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {

            var DataEmp = _employeeService.FindById(Id);
            var DataAdd =_addressService.FindById(Id);

            Employee_Address_ListModel Model = new Employee_Address_ListModel();

            Model.Id = DataEmp.Id;
            Model.Name = DataEmp.Name;
            Model.Gender = DataEmp.Gender;
            Model.Address = DataAdd.Address;

            return View(Model);
        }

        [HttpPost]
        public ActionResult Edit(Employee_Address_ListModel Model)
        {
            var data = _employeeService.FindById(Model.Id);

            data.Id = Model.Id;
            data.Name = Model.Name;
            data.Gender = Model.Gender;

            _employeeService.UpdateEmployee(data);

            var data2 = _addressService.FindById(Model.Id);

            data2.EmployeeId = Model.Id;
            data2.Address = Model.Address;

            _addressService.UpdateAddress(data2);

            return RedirectToAction("ListofEmp");
        }

        public ActionResult Delete(Employee_Address_ListModel Model)
        {
            var data = _employeeService.FindById(Model.Id);
            _employeeService.DeleteEmployee(data);

            var data2 = _addressService.FindById(Model.Id);
            _addressService.DeleteAddress(data2);

            return RedirectToAction("ListofEmp");
        }
    }
}