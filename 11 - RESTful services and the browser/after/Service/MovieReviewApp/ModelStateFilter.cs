using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace MovieReviewApp
{
    public class ModelStateFilter : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuted(System.Web.Http.Filters.HttpActionExecutedContext actionExecutedContext)
        {
            if (!actionExecutedContext.Response.IsSuccessStatusCode)
            {
                var contentObject = actionExecutedContext.Response.Content as ObjectContent;
                if (contentObject != null)
                {
                    var modelState = contentObject.Value as ModelStateDictionary;
                    if (modelState != null)
                    {
                        var errors =
                            (from item in modelState
                            from value in item.Value.Errors
                            select value.ErrorMessage).ToArray();

                        var configuration = actionExecutedContext.Request.GetConfiguration();
                        var contentNegotiator = configuration.Services.GetContentNegotiator();
                        var formatters = configuration.Formatters;
                        var result = contentNegotiator.Negotiate(errors.GetType(), actionExecutedContext.Request, formatters);
                        var content = new ObjectContent(errors.GetType(), errors, result.Formatter, result.MediaType.MediaType);
                        actionExecutedContext.Response.Content = content;
                    }
                }
            }
        }
    }
}