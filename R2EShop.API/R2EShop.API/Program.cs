using Newtonsoft.Json;
using R2EShop.API;
using R2EShop.API.Middleware;
using R2EShop.Application;
using R2EShop.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure();

var app = builder.Build();
app.UseMiddleware<AddContentRangeHeaderMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");

//app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
