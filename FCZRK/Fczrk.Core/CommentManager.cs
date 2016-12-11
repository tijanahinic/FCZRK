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
    public class CommentManager
    {
        public Comment Get(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Comment comment = uow.CommentRepository.GetById(id);
                ValidationHelper.ValidateNotNull(comment);
                return comment;
            }
        }

        public List<Comment> GetAll()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                List<Comment> comments = uow.CommentRepository.GetAll();
                return comments;
            }
        }

        public Comment AddComment(string name, string text, int projectId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Comment comment = new Comment
                {
                    Name = name,
                    Text = text,
                    DateCreated = DateTime.UtcNow,
                    ProjectId = projectId
                };

                uow.CommentRepository.Insert(comment);
                uow.Save();

                return comment;
            }
        }

        public void Delete(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Comment comment = uow.CommentRepository.GetById(id);
                ValidationHelper.ValidateNotNull(comment);

                uow.CommentRepository.Delete(comment);
                uow.Save();
            }
        }

        public Comment Edit(int id, string name, string text)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Comment comment = uow.CommentRepository.GetById(id);
                comment.Name = name;
                comment.Text = text;

                uow.Save();
                return comment;
            }
        }

        public Comment ToggleActive(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Comment comment = uow.CommentRepository.GetById(id);
                comment.Active = !comment.Active;

                uow.Save();
                return comment;
            }
        }
    }
}
