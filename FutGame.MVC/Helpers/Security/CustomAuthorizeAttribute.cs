using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FutGame.MVC.Helpers.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public string UsersConfigKey { get; set; }

        protected virtual CurrentUser CurrentUser
        {
            get { return HttpContext.Current.User as CurrentUser; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                var authorizedUsers = ConfigurationManager.AppSettings["2,3"];
                
                Users = String.IsNullOrEmpty(Users) ? authorizedUsers : Users;
                
                //if (!String.IsNullOrEmpty(Roles))
                //{
                //    if (!CurrentUser.IsInRole(Roles))
                //    {
                //        filterContext.Result = new RedirectToRouteResult(new
                //     RouteValueDictionary(new { controller = "Error", action = "Index" }));

                //        // base.OnAuthorization(filterContext); //returns to login url
                //    }
                //}

                if (!String.IsNullOrEmpty(Users))
                {
                    if (!Users.Contains(CurrentUser.UserId.ToString()))
                    {
                        filterContext.Result = new RedirectToRouteResult(new
                     RouteValueDictionary(new { controller = "Error", action = "Index" }));

                        // base.OnAuthorization(filterContext); //returns to login url
                    }
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                     RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
        }
    }
}