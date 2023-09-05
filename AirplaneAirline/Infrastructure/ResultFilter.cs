using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using Ticketing.BLL.Contract.Results;

namespace Ticketing.Host.Infrastructure;

public class ResultFilter : IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as OkObjectResult;

        if (result != null)
        {
            var res = result.Value as Result;

            if (res != null)
            {
                if (res.Status)
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status200OK;

                    context.HttpContext.Response.ContentType = new MediaTypeHeaderValue("application/json").ToString();

                    await context.HttpContext.Response.WriteAsJsonAsync(JsonSerializer.Serialize(res));
                }
                else
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

                    context.HttpContext.Response.ContentType = new MediaTypeHeaderValue("application/json").ToString();

                    await context.HttpContext.Response.WriteAsJsonAsync(res.Error);
                }
            }
        }
		else
		{
			var badRequestObjectResult = context.Result as BadRequestObjectResult;

			if (badRequestObjectResult.StatusCode == StatusCodes.Status400BadRequest)
			{
				var fieldName = ((ValidationProblemDetails)badRequestObjectResult.Value).Errors.Keys.First();

				var message = ((ValidationProblemDetails)badRequestObjectResult.Value).Errors.Values.Select(x => x.First()).ToList();

				context.HttpContext.Response.ContentType = new MediaTypeHeaderValue("application/json").ToString();

				context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

				await context.HttpContext.Response.WriteAsync(JsonSerializer.Serialize(new Result(message)));
			}
		}
	}
}
