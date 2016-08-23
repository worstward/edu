using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edu.Helpers
{
    public class ResultAttribute : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            context.Controller.ViewBag.OnResultExecuted = "Result executed";
        }
        public  void OnResultExecuting(ResultExecutingContext context)
        {
            context.Controller.ViewBag.OnResultExecuting = "Result executing";
        }
    }
}