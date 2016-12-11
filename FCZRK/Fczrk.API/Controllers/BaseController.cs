using Fczrk.API.Models;
using Fczrk.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fczrk.API.Controllers
{
    /// <summary>
    /// Base controller for all NasaPatrola controllers
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class BaseController : ApiController
    {
        internal UserJwtModel CurrentUser { get; set; }

        internal UserManager userManager;
        internal UserManager UserManager
        {
            get
            {
                return userManager ?? (userManager = new UserManager());
            }
        }

        internal CommentManager commentManager;
        internal CommentManager CommentManager
        {
            get
            {
                return commentManager ?? (commentManager = new CommentManager());
            }
        }
    }
}
