//using Fczrk.API.Controllers;
//using Fczrk.API.Models;
//using Fczrk.Common.Exceptions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Configuration;
//using System.Web.Http;
//using System.Web.Http.Controllers;
//using System.Web.Http.Filters;

//namespace Fczrk.API.Helpers
//{
//    /// <summary>
//    /// TokenAuthorizeAttribute
//    /// </summary>
//    /// <seealso cref="System.Web.Http.Filters.ActionFilterAttribute" />
//    public class TokenAuthorizeAttribute : ActionFilterAttribute
//    {
//        /// <summary>
//        /// Gets or sets the roles the user is in.
//        /// </summary>
//        /// <value>
//        /// The roles.
//        /// </value>
//        public string Roles { get; set; }

//        /// <summary>
//        /// Occurs before the action method is invoked.
//        /// </summary>
//        /// <param name="actionContext">The action context.</param>
//        /// <exception cref="AuthenticationException">
//        /// No Authorization header present
//        /// or
//        /// Authorization header cannot be empty
//        /// or
//        /// Invalid token!
//        /// or
//        /// Token expired! Please, login again
//        /// or
//        /// You do not have permission to access this resource!
//        /// </exception>
//        public override void OnActionExecuting(HttpActionContext actionContext)
//        {
//            // Skip validation if AllowAnonymous attribute is set
//            if (!SkipValidation(actionContext))
//            {
//                var controller = actionContext.ControllerContext.Controller as BaseController;

//                // Check for authorization header
//                var authorizationHeader = actionContext.Request.Headers.FirstOrDefault(h => h.Key == "Authorization");
//                if (authorizationHeader.Key == null)
//                {
//                    throw new AuthenticationException("No Authorization header present");
//                }

//                // Get token from Authorization header
//                string tokenString = authorizationHeader.Value.FirstOrDefault();
//                if (string.IsNullOrWhiteSpace(tokenString))
//                {
//                    throw new AuthenticationException("Authorization header cannot be empty");
//                }

//                // Validate JWT token
//                var secretKey = WebConfigurationManager.AppSettings["JwtSecret"];
//                UserJwtModel user;

//                try
//                {
//                    user = JWT.JsonWebToken.DecodeToObject<UserJwtModel>(tokenString, secretKey);
//                }
//                catch (JWT.SignatureVerificationException)
//                {
//                    throw new AuthenticationException("Invalid token!");
//                }

//                if (user.Token != null)
//                {
//                    var userFromDb = controller.UserManager.GetByToken(user.LocalToken);
//                    if (userFromDb == null) throw new AuthenticationException("Invalid digits token (user not found)!");
//                    if (userFromDb.Id != user.Id) throw new AuthenticationException("Invalid digits token (id mismatch)!");
//                }
//                else if (user.ExpirationDate < DateTime.UtcNow)
//                {
//                    throw new AuthenticationException("Token expired! Please, login again");
//                }

//                // Validate roles
//                if (Roles != null && !Roles.Split(',').ToList().Intersect(user.Roles).Any())
//                {
//                    throw new AuthenticationException("You do not have permission to access this resource!");
//                }

//                // Add current user to base controller
//                controller.CurrentUser = user;
//                controller.userManager = new Core.UserManager(user.Id);
//            }

//            base.OnActionExecuting(actionContext);
//        }

//        private bool SkipValidation(HttpActionContext actionContext)
//        {
//            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
//                   || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
//        }
//    }
//}