using FluentValidation.Attributes;
using Nop.Admin.Validators.User;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Admin.Models.User
{
    [Validator(typeof(UserValidator))]
    public partial class UserModel : BaseNopEntityModel
    {
        public UserModel()
        {
            this.Users = new List<UserModel>();
        }

        [NopResourceDisplayName("Admin.User.Field.Name")]
        public string Name { get; set; }
        [NopResourceDisplayName("Admin.User.Field.Gender")]
        public string Gender { get; set; }
        [NopResourceDisplayName("Admin.User.Field.EmailID")]
        public string EmailID { get; set; }
        [NopResourceDisplayName("Admin.User.Field.Password")]
        public string Password { get; set; }
        [NopResourceDisplayName("Admin.User.Field.ConfirmPassword")]
        public string ConfirmPassword { get; set; }
        public IList<UserModel> Users { get; set; }
    }
}