using Nop.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Web.Models.Employee
{
    public class EmployeeModel : BaseNopModel
    {
        public string Name { get; set; }
        public string Gender { get; set; }
    }
}