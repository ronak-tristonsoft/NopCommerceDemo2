using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.User
{
    public partial class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
