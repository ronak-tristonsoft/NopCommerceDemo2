using Nop.Core;
using Nop.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.User
{
    public partial interface IUserService
    {
        IList<UserEntity> GetList();
        void AddUser(UserEntity userEntity);
        UserEntity FindById(int Id);
        void UpdateUser(UserEntity userEntity);
        void DeleteUser(UserEntity entity);
        IList<UserEntity> GetAllUsers(string Email = null, string Name = null, string Gender= null);
    }
}
