using Fczrk.API.Helpers;
using Fczrk.API.Models.User;
using Fczrk.Entities;
using Fczrk.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Fczrk.Core;

namespace Fczrk.API.Controllers
{
    public class CommentController 
    {
        [HttpGet]
        public CommentModel Get(int id)
        {
            Comment comment = CommentManager.Get(id);
            return new CommentModel
            {
                Name = comment.Name,
                Text = comment.Text,
                Id = comment.Id,
                Active = comment.Active,
                DateCreated = comment.DateCreated
            };
        }
    }
}