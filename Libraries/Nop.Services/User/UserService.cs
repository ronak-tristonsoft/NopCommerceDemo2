using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.User
{
    public partial class UserService : IUserService
    {
        protected readonly IRepository<UserEntity> _userMasterRepository;

        public UserService(IRepository<UserEntity> userMasterRepository)
        {
            this._userMasterRepository = userMasterRepository;
        }

        public virtual IList<UserEntity> GetList()
        {
            var List = _userMasterRepository.Table.ToList();
            return List;
        }
        public void AddUser(UserEntity userEntity)
        {
            _userMasterRepository.Insert(userEntity);
        }

        public void UpdateUser(UserEntity userEntity)
        {
            _userMasterRepository.Update(userEntity);
        }

        public UserEntity FindById(int Id)
        {
           return _userMasterRepository.GetById(Id);
        }

        public void DeleteUser(UserEntity userEntity)
        {
            _userMasterRepository.Delete(userEntity);
        }

        public virtual IList<UserEntity> GetAllUsers(string Email = null, string Name = null, string Gender = null)
        {
            var query = _userMasterRepository.Table;

            if (!String.IsNullOrWhiteSpace(Email))
                query = query.Where(c => c.EmailID.Contains(Email));
            if (!String.IsNullOrWhiteSpace(Name))
                   query = query.Where(c => c.Name.Contains(Name));
            if (!String.IsNullOrWhiteSpace(Gender))
                query = query.Where(c => c.Gender.Contains(Gender));

            return query.ToList();
        }

    }
}
