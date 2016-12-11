using Fczrk.Common.Helpers;
using Fczrk.Data;
using Fczrk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fczrk.Core
{
    public class SponsorCategoryManager
    {
        public SponsorCategory AddSponsorCategory { get; set; }

        public SponsorCategory Get(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                SponsorCategory sponsorcategory = uow.SponsorCategoryRepository.GetById(id);
                ValidationHelper.ValidateNotNull(sponsorcategory);
                return sponsorcategory;
            }
        }
        public List<SponsorCategory> GetAll()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                List<SponsorCategory> sponsorcategory = uow.SponsorCategoryRepository.GetAll();
                return sponsorcategory;
            }
        }
        public SponsorCategory Add(string name)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                SponsorCategory sponsorcategory = new SponsorCategory
                {
                    Name = name
                };
                uow.SponsorCategoryRepository.Insert(sponsorcategory);
                uow.Save();

                return sponsorcategory;
            }
        }

        public void Delete(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                SponsorCategory sponsorcategory = uow.SponsorCategoryRepository.GetById(id);
                ValidationHelper.ValidateNotNull(sponsorcategory);

                uow.CommentRepository.Delete(sponsorcategory);
                uow.Save();

            }
        }
        public SponsorCategory Edit(int id, string name)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                SponsorCategory sponsorcategory = uow.SponsorCategoryRepository.GetById(id);
                sponsorcategory.Name = name;

                uow.Save();
                return sponsorcategory;
            }
        }
    }
}

