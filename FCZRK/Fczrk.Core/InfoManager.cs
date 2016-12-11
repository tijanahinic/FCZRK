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
    public class InfoManager
    {
      public Info Get(int id)
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
                Info info = uow.InfoRepository.GetById(id);
                ValidationHelper.ValidateNotNull(info);
                return info;
            }
        }
        public List<Info> GetAll()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                List<Info> info = uow.InfoRepository.GetAll();
                return info;
            }
        }
        public Info AddInfo (string description, string mission, string vision, string becomeMember, string aboutUs, string aboutFax)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Info info = new Info
                {
                    Description = description,
                    Mission = mission,
                    Vision = vision,
                    BecomeMember = becomeMember,
                    AboutUs = aboutUs,
                    AboutFax = aboutFax
                };
                uow.InfoRepository.Insert(info);
                uow.Save();

                return info;
            }
        }

        

        public void Delete (int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Info info = uow.InfoRepository.GetById(id);
                ValidationHelper.ValidateNotNull(info);

                uow.InfoRepository.Delete(info);
                uow.Save();
            }
        }
        public Info Edit(int id, string description, string mission, string vision, string becomeMember, string aboutUs, string aboutFax)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Info info = uow.InfoRepository.GetById(id);
                info.Description = description;
                info.Mission = mission;
                info.Vision = vision;
                info.BecomeMember = becomeMember;
                info.AboutUs = aboutUs;
                info.AboutFax = aboutFax;

                uow.Save();
                return info;
            }
        }

    }
}
