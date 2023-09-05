using Ticketing.Host.MyUtilities;

namespace Ticketing.Host.Infrastructure;

public static class ExceptionMiddleware
{
    public static async Task Handle(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var message = Utilities.WriteLoges(ex);

            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            await context.Response.WriteAsync(message);
        }
    }
}
