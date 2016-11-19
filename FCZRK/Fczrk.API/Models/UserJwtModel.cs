using System;
using System.Collections.Generic;

namespace Fczrk.API.Models
{
    /// <summary>
    /// UserJwtModel
    /// </summary>
    public class UserJwtModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Token { get; set; }
        public string LocalToken { get; set; }

        public List<string> Roles { get; set; } = new List<string>();
    }
}