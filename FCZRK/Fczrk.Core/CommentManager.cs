using Fczrk.Data;
using Fczrk.Entities;
using Fczrk.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NasaPatrola.Common.Helpers;

namespace Fczrk.Core
{
    public class CommentManager
    {
        public Comment Get(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Comment comment = uow.CommentRepository.Find(u => u.Id == id, includeProperties: "Member").FirstOrDefault();
                ValidationHelper.ValidateNotNull(comment);
                return comment;
            }
        }
    }
}
