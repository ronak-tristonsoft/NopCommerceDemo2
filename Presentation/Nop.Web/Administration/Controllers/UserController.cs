using Nop.Admin.Models.User;
using Nop.Services.User;
using Nop.Core.Domain.User;
using System.Linq;
using Nop.Admin.Extensions;
using System.Web.Mvc;
using Nop.Services.Localization;

namespace Nop.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        private readonly IUserService _userService;
        private readonly ILocalizationService _localizationService;

        public UserController(IUserService userService, ILocalizationService localizationService)
        {
            this._userService = userService;
            this._localizationService = localizationService;
        }
        // GET: User
        public ActionResult Index()
        {
            UserModel userModel = new UserModel();
            var UserList = _userService.GetList();
            foreach (var item in UserList)
            {
                userModel.Users.Add(new UserModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Gender = item.Gender,
                    EmailID = item.EmailID,
                });
            }
            return View(userModel);
        }

        [HttpPost]
        public virtual ActionResult Index(UserModel model)
        {
            var user = _userService.GetAllUsers(model.EmailID, model.Name, model.Gender);

            foreach (var item in user)
            {
                model.Users.Add(new UserModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Gender = item.Gender,
                    EmailID = item.EmailID,
                });
            }
            return View(model);
        }

            public ActionResult Create()
        {
            UserModel userModel = new UserModel();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult Create(UserModel Model)
        {
            //Mapping

            UserEntity Entity = new UserEntity();


            Entity.Name = Model.Name;
            Entity.Gender = Model.Gender;
            Entity.EmailID = Model.EmailID;
            Entity.Password = Model.Password;
            Entity.ConfirmPassword = Model.ConfirmPassword;

            var UserList = _userService.GetList();
            var email = UserList.Where(x => x.EmailID == Model.EmailID).Count();

            if (email > 0)
            {
                ErrorNotification(_localizationService.GetResource("Admin.UserMaster.Create.EmailIdRegistered"));
                return View(Model);
            }

            else if (Model.Password != Model.ConfirmPassword)
            {
                ErrorNotification(_localizationService.GetResource("Admin.UserMaster.Create.ConfirmPasswordNotMatch"));
                return View(Model);
            }

            else
            {
                //Adding User
                _userService.AddUser(Entity);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            var user = _userService.FindById(Id);
            UserModel userModel = new UserModel();
            userModel.Id = user.Id;
            userModel.Name = user.Name;
            userModel.Gender = user.Gender;
            userModel.EmailID = user.EmailID;
            return View(userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserModel Model)
        {
            var UserList = _userService.GetList();
            var email = UserList.Where(x => x.EmailID == Model.EmailID).Count();
            var user = _userService.FindById(Model.Id);

            if (Model.Password != Model.ConfirmPassword)
            {
                ErrorNotification(_localizationService.GetResource("Admin.User.Edit.ConfirmPasswordNotMatch"));
                return View(Model);
            }
            else if (user.EmailID == Model.EmailID || email == 0)
            {
                user.Name = Model.Name;
                user.Gender = Model.Gender;
                user.EmailID = Model.EmailID;
                user.Password = Model.Password;
                user.ConfirmPassword = Model.ConfirmPassword;

                _userService.UpdateUser(user);
                SuccessNotification(_localizationService.GetResource("Admin.User.Edit.EmailIdRegistered"));
            }
            else
            {
                ErrorNotification(_localizationService.GetResource("Admin.UserMaster.Create.EmailIdRegistered"));
                return View(Model);
            }
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id)
        {
           var user = _userService.FindById(Id);
            _userService.DeleteUser(user);
            return RedirectToAction("Index");
        }

    }
}