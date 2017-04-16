using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace WebApiTestToDo.ExceptionHandling
{
    public class HotelGlobalExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext cntxt)
        {
            var exceptionType = cntxt.Exception.GetType();


            //cntxt.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            int id = 10;
            // cntxt.Response.StatusCode = HttpStatusCode.Unauthorized;
            var message = string.Format("Global - Product with id = {0} not found", id);
            HttpError err = new HttpError(message);
            cntxt.Response = cntxt.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, err);

            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                cntxt.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
        }
    }
}