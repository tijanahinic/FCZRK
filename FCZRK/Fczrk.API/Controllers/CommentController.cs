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
    public class CommentController : BaseController
    {
        [HttpGet]
        public CommentModel Get(int id)
        {
            Comment comment = CommentManager.Get(id);
            return Mapper.Map(comment);
        }

        [HttpGet]
        public List<CommentModel> GetAll()
        {
            List<Comment> comments = CommentManager.GetAll();
            List<CommentModel> commentsModel = new List<CommentModel>();
            return comments.Select(a => Mapper.Map(a)).ToList();
        }

        [HttpPost]
        public CommentModel AddComment(CommentModel commentModel)
        {
            Comment comment = CommentManager.AddComment(commentModel.Name, commentModel.Text, commentModel.ProjectId);
            return Mapper.Map(comment); 
        } 

        [HttpPost]
        public void Delete(int id)
        {
            CommentManager.Delete(id);
        }

        [HttpPost]
        public CommentModel Edit(CommentModel commentModel)
        {
            Comment comment = CommentManager.Edit(commentModel.Id, commentModel.Name, commentModel.Text);
            return Mapper.Map(comment);
        }

        [HttpPost]
        public CommentModel ToggleActive (int id)
        {
            Comment comment = CommentManager.ToggleActive(id);
            return Mapper.Map(comment);
        }
    }


}