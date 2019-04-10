using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Filters
{
    public class AuthFilter : AuthorizeAttribute, IAuthorizationFilter
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                // Don't check for authorization as AllowAnonymous filter is applied to the action or controller  
                return;
            }

            // Check for authorization  
            if (!String.IsNullOrEmpty(Roles) &&
                filterContext.HttpContext.Session["userRole"] != null &&
                Roles.Contains(filterContext.HttpContext.Session["userRole"].ToString()))
            {
                //allow
            }
            else
            {
                //nope
                filterContext.Result = new RedirectResult("/Home/Index");
            }
        }
    }
}