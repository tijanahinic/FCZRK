using Fczrk.Data.Model;
using Fczrk.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Fczrk.Data
{
    public class UnitOfWork : IDisposable
    {
        #region Fields

        /// <summary>
        /// Data context
        /// </summary>
        private DbContext context;

        private UserRepository userRepository;
        private CommentRepository commentRepository;
        private SponsorCategoryRepository sponsorcategoryRepository;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Data context
        /// </summary>
        public DbContext DataContext
        {
            get
            {
                return context ?? (context = new FCZRKEntities());
            }
        }

        #region Repository


        public UserRepository UserRepository
        {
            get
            {
                return userRepository ?? (userRepository = new UserRepository(DataContext));
            }
        }

        public CommentRepository CommentRepository
        {
            get
            {
                return commentRepository ?? (commentRepository = new CommentRepository(DataContext));
            }
        }
        public SponsorCategoryRepository SponsorCategoryRepository
        {
            get
            {
                return sponsorcategoryRepository ?? (sponsorcategoryRepository = new SponsorCategoryRepository(DataContext));
            }
        }

        #endregion Repository

        #endregion Properties

        #region Methods

        /// <summary>
        /// Save changes for unit of work async
        /// </summary>
        public async Task SaveAsync()
        {
            context.ChangeTracker.DetectChanges();
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Save changes for unit of work
        /// </summary>
        public void Save()
        {
            context.ChangeTracker.DetectChanges();
            context.SaveChanges();
        }

        #endregion Methods

        #region IDisposable Members

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (context != null)
                        context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose objects
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

    }
}
