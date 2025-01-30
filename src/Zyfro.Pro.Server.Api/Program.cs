using Zyfro.Pro.Server.Api.Extensions;
using Zyfro.Pro.Server.Application.Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseServices();

app.MapControllers();
app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<RateLimitingMiddleware>();

app.Run();