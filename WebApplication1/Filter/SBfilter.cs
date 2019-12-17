using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Helper;


namespace WebApplication1.Filter
{
    public class SBfilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           string method =  filterContext.ActionDescriptor.ActionName;
           string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string msg = string.Format("/{0}/{1} is getting Called", method, controller);
            Logger.currentLogger.Log(msg);


        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string method = filterContext.ActionDescriptor.ActionName;
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string msg = string.Format("/{0}/{1} is getting Called", method, controller);
            Logger.currentLogger.Log(msg);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string msg;
            if (filterContext.Result is ViewResult)
            {
                string pageName = (filterContext.Result as ViewResult).ViewName;
                msg = string.Format("{0} page is about get Processed", pageName);
            }
            else
            {
                msg = "Result Executed";
            }
            Logger.currentLogger.Log(msg);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string msg;
            if(filterContext.Result is ViewResult)
            {
                string pageName = (filterContext.Result as ViewResult).ViewName;
                msg = string.Format("{0} page is processed", pageName);
            }
            else
            {
                msg = "Result Executed";
            }
            Logger.currentLogger.Log(msg);
        }
    }
}