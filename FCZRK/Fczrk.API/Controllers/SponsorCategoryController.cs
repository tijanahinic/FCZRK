using AutoMapper;
using Fczrk.API.Models.SponsorCategory;
using Fczrk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Fczrk.API.Controllers
{
    public class SponsorCategoryController : BaseController
    {
        [HttpGet]
        public SponsorCategoryModel Get(int id)
        {
            SponsorCategory sponsorcategory = SponsorCategoryManager.Get(id);
            return Fczrk.API.Helpers.Mapper.Map(sponsorcategory);
        }
        [HttpGet]
        public List<SponsorCategoryModel> GetAll()
        {
            List<SponsorCategory> sponsorcategory = SponsorCategoryManager.GetAll();
            return sponsorcategory.Select(a => Fczrk.API.Helpers.Mapper.Map(a)).ToList();
        }
        [HttpPost]
        public SponsorCategoryModel AddSponsorCategory(SponsorCategoryModel sponsorcategoryModel)
        {
            SponsorCategory sponsorcategory = SponsorCategoryManager.Add(sponsorcategoryModel.Name);
            return Fczrk.API.Helpers.Mapper.Map(sponsorcategory);
        }
        [HttpPost]
        public void Delete(int id)
        {
            SponsorCategoryManager.Delete(id);
        }
        [HttpPost]
        public SponsorCategoryModel Edit(SponsorCategoryModel sponsorcategoryModel)
        {
            SponsorCategory sponsorcategory = SponsorCategoryManager.Edit(sponsorcategoryModel.Id, sponsorcategoryModel.Name);
            return Fczrk.API.Helpers.Mapper.Map(sponsorcategory);
        }
    }
}
