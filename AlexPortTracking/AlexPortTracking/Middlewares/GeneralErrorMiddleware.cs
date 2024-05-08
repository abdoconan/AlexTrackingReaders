using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace AlexPortTracking.Middlewares
{
    public class GeneralErrorMiddleware
    {
        private readonly RequestDelegate next;

        public GeneralErrorMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                var errorResponse = new
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "An error occurred.",
                    ExceptionMessage = e.Message
                };

                var jsonResponse = JsonSerializer.Serialize(errorResponse);

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}
