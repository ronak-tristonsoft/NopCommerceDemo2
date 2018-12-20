using Nop.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Name is required field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Gender is requried field")]
        [RegularExpression("[a-zA-Z]+\\.?")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Address is requried field")]
        public string Address { get; set; }
        public IList<Employee_Address_ListModel> employee_Address_ListModels { get; set; }
    }
}