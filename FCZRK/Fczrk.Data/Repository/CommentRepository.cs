﻿using Fczrk.Data.Infrastructure;
using Fczrk.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fczrk.Data.Repository
{
    public class CommentRepository : GenericRepository<Comment>
    {
        public CommentRepository(DbContext dbContext) : base(dbContext) { }
    }
}
