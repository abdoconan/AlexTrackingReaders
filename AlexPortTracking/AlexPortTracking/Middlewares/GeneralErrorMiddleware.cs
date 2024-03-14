using AlexPortTracking.Data;
using System.Net;

namespace AlexPortTracking.Middlewares
{
    public class GeneralErrorMiddleware
    {
        private readonly RequestDelegate next;

        public GeneralErrorMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke (HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync(e);
            }
        }
    }
}
