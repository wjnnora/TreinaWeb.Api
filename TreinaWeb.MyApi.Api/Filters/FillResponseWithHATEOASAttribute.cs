using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using TreinaWeb.MyApi.Api.HATEOAS.Helpers;

namespace TreinaWeb.MyApi.Api.Filters
{
    public class FillResponseWithHATEOASAttribute : ActionFilterAttribute
    {
        public object ResourceBuilder { get; private set; }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if ((actionExecutedContext.Response.IsSuccessStatusCode || actionExecutedContext.Response.StatusCode == System.Net.HttpStatusCode.Found)
                && actionExecutedContext.Request.Headers.SelectMany(x => x.Value).Any(x => x.Contains("hal")))
            {
                ObjectContent responseContent = actionExecutedContext.Response.Content as ObjectContent;
                object responseValue = responseContent.Value;
                RestResourceBuilder.BuilderResource(responseValue, actionExecutedContext.Request);
            }
        }
    }
}