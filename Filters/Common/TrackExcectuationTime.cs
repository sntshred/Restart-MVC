﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;


namespace Filters.Common
{
    public class TrackExcectuationTime:ActionFilterAttribute,IExceptionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string message = "\n" + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + " -> " + filterContext.ActionDescriptor.ActionName + " -> " +
                "On Excecuting \t " + DateTime.Now.ToString();
            LogExecuationTime(message);

        }


        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            string message = "\n" + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + " -> " + filterContext.ActionDescriptor.ActionName + " -> " +
                " OnActionExecuted \t " + DateTime.Now.ToString();
            LogExecuationTime(message);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {

            string message = "\n" + filterContext.RouteData.Values["controller"].ToString() + " -> " + filterContext.RouteData.Values["action"].ToString() + " -> " +
                " OnResultExecuting \t " + DateTime.Now.ToString();
            LogExecuationTime(message);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string message = "\n" + filterContext.RouteData.Values["controller"].ToString() + " -> " + filterContext.RouteData.Values["action"].ToString() + " -> " +
               " OnResultExecuted \t " + DateTime.Now.ToString();
            LogExecuationTime(message);
            LogExecuationTime("-----------------------------------------------------");
            
        }

        public void OnException(ExceptionContext filterContext)
        {
            string message = "\n" + filterContext.RouteData.Values["controller"].ToString() + " -> " + filterContext.RouteData.Values["action"].ToString() + " -> " +
               filterContext.Exception.Message+" " + DateTime.Now.ToString();
            LogExecuationTime(message);
            LogExecuationTime("-----------------------------------------------------");



        }



        private void LogExecuationTime(string data)
        {
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/Data/Data.txt"),data);

        }

    }
}