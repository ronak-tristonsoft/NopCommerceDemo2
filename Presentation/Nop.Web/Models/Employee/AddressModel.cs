using Nop.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Web.Models.Employee
{
    public class AddressModel : BaseNopModel
    {
        public int EmployeeId { get; set; }
        public string Address { get; set; }
    }
}