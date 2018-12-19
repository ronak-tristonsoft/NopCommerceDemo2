using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Nop.Admin.Models.User;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;

namespace Nop.Admin.Models.User
{
    public partial class UserListModel : BaseNopEntityModel
    {
        public UserListModel()
        {
            Users = new List<UserListModel>();  
        }

        [NopResourceDisplayName("Admin.User.Field.Name")]
        public string Name { get; set; }
        [NopResourceDisplayName("Admin.User.Field.Gender")]
        public string Gender { get; set; }
        [NopResourceDisplayName("Admin.User.Field.EmailID")]
        public string EmailID { get; set; }

        
        public IList<UserListModel> Users { get; set; }

    }
}