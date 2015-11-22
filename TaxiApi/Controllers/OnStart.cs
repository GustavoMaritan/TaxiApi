using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;

namespace TaxiApi.Controllers
{
    public class OnStart : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var a = actionContext.Request.Headers
                .GetType().GetProperty("Authorization");

            var t = a.GetValue(actionContext.Request.Headers);
        }
    }
}