using Common.Helper;
using Common.WebHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web.Attribute
{
    public class AuthorityFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            if (SessionHelper.Get("Account") == null)
            {
                filterContext.Result = new RedirectResult("/Login/Index");
                //filterContext.HttpContext.Response.Redirect("~/Login/Index");
                //filterContext.Result = new RedirectResult(filterContext.Controller.Action("Index", "Start", new {  area=""}););
                //跳转到登录页面
                //filterContext.Result = null;
                //filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary(new { Controller = "Login", Action = "Index" }));
            }
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                filterContext.HttpContext.Response.Redirect("/Error/Index");
            } 
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class LoginAllowViewAttribute : ActionFilterAttribute
    {

    }

}