﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace HRM.ERP.MVC.CustomFilters
{
    /// <summary>
    /// Managing of session to restrict unauthorized logins
    /// </summary>
    public class AuthSessionManagement : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.HttpContext.Session.GetString("user") == null)
            {
                RouteValueDictionary redirectToAction = new RouteValueDictionary();
                redirectToAction.Add("action", "Login");
                redirectToAction.Add("controller", "Account");
                redirectToAction.Add("area", "");
                context.Result = new RedirectToRouteResult(redirectToAction);
            }
            base.OnActionExecuting(context);
        }
    }
}
