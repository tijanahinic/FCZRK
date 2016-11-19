using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fczrk.API.Models.User
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
    }
}