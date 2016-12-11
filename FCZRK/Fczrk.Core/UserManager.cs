using Fczrk.Data;
using Fczrk.Entities;
using Fczrk.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fczrk.Core
{
    public class UserManager
    {
        public User Get(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                User user = uow.UserRepository.Find(u => u.Id == id, includeProperties: "Member").FirstOrDefault();
                ValidationHelper.ValidateNotNull(user);
                return user;
            }
        }
    }
}
