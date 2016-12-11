using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fczrk.API.Models.Info
{
    public class InfoModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Mission { get; set; }
        public string Vision { get; set; }
        public string BecomeMember { get; set; }
        public string AboutUs { get; set; }
        public string AboutFax { get; set; }
    }
}