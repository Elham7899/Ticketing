using Ticketing.Host.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(option =>
{
    option.Filters.Add<ResultFilter>();
});

builder.RegisterationService();

var app = builder.Build();

app.MapControllers();

app.UseAuthentication();

app.UseAuthorization();

app.Use(ExceptionMiddleware.Handle);

app.Run();