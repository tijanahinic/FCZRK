using System;
using System.Collections.Generic;

namespace Fczrk.API.Models
{
    /// <summary>
    /// CommentJwtModel
    /// </summary>
    public class UserJwtModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public Boolean Active { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public string Token { get; set; }
        public string LocalToken { get; set; }

        public List<string> Roles { get; set; } = new List<string>();
    }
}