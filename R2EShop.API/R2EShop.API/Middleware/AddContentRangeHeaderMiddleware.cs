using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace R2EShop.API.Middleware
{

    public class AddContentRangeHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public AddContentRangeHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.OnStarting(() =>
            {
                if (context.Response.StatusCode == StatusCodes.Status200OK &&
                    context.Request.Headers.ContainsKey("Range") &&
                    !context.Response.Headers.ContainsKey("Content-Range"))
                {
                    // Add Content-Range header
                    context.Response.Headers.Add("Content-Range", "items 0-9/*");
                }

                return Task.CompletedTask;
            });

            await _next(context);
        }
    }

}
