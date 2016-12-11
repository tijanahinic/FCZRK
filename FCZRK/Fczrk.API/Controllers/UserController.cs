using Fczrk.API.Helpers;
using Fczrk.API.Models.User;
using Fczrk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Fczrk.API.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public UserModel Get(int id)
        {
            User user = UserManager.Get(id);
            return new UserModel
            {
                FirstName = user.Member.FirstName,
                Email = user.Email,
                Id = user.Id,
                Name = user.Username
            };
        }
    }
}