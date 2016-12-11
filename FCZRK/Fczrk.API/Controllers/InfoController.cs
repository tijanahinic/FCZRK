using Fczrk.API.Models.Info;
using Fczrk.Core;
using Fczrk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Fczrk.API.Controllers
{
    public class InfoController : BaseController
    {
        [HttpGet]
        public InfoModel Get(int id)
        {
            Entities.Info info = InfoManager.Get(id);
            return Fczrk.API.Helpers.Mapper.Map(info);
        }
        [HttpGet]
        public List<Models.Info.InfoModel> GetAll()
        {
            List<Entities.Info> info = InfoManager.GetAll();
            List<Models.Info.InfoModel> infoModel = new List<Models.Info.InfoModel>();
            return info.Select (a => Fczrk.API.Helpers.Mapper.Map(a)).ToList();
        }
        [HttpPost]
        public InfoModel AddInfo(Models.Info.InfoModel infoModel)
        {
            Entities.Info info = InfoManager.AddInfo(infoModel.Description, infoModel.Mission, infoModel.Vision, infoModel.BecomeMember, infoModel.AboutUs, infoModel.AboutFax);
            return Fczrk.API.Helpers.Mapper.Map(info);
        }

        [HttpPost]
        public void Delete(int id)
        {
            InfoManager.Delete(id);
        }

        [HttpPost]
        public InfoModel Edit(InfoModel infoModel)
        {
            Info info = InfoManager.Edit(infoModel.Id, infoModel.Description, infoModel.Mission, infoModel.Vision, infoModel.BecomeMember, infoModel.AboutUs, infoModel.AboutFax);
            return Fczrk.API.Helpers.Mapper.Map(info);
        }
    }
}