using Nop.Data;
using Nop.Services.Localization;
using FluentValidation;
using Nop.Web.Framework.Validators;
using Nop.Admin.Models.User;
using Nop.Core.Domain.User;

namespace Nop.Admin.Validators.User
{
    public partial class UserValidator : BaseNopValidator<UserModel>
    {
        public UserValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.User.Fields.Name.Required"));
            RuleFor(x => x.Gender).NotEmpty().WithMessage(localizationService.GetResource("Admin.User.Fields.Gender.Required"));
            RuleFor(x => x.EmailID).NotEmpty().EmailAddress().WithMessage(localizationService.GetResource("Admin.Common.WrongEmail"));
            RuleFor(x => x.Password).NotEmpty().WithMessage(localizationService.GetResource("Admin.User.Fields.Password.Required"));
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage(localizationService.GetResource("Admin.User.Fields.ConfirmPassword.Required"));

            SetDatabaseValidationRules<UserEntity>(dbContext);
        }
    }
}