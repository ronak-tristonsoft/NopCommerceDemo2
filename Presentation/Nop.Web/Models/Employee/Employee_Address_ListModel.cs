using Nop.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Web.Models.Employee
{
    public class Employee_Address_ListModel : BaseNopModel
    {
        public Employee_Address_ListModel()
        {
            this.employee_Address_ListModels = new List<Employee_Address_ListModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public IList<Employee_Address_ListModel> employee_Address_ListModels { get; set; }
    }
}