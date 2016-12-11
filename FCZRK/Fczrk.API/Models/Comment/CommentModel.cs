using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fczrk.API.Models.User
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
