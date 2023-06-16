using BuberDuinner.Application;
using BuberDinner.Infrastructure;
using BuberDinner.Api.Mapping;

var builder = WebApplication.CreateBuilder(args);
{
builder.Services.AddControllers();

builder.Services
.AddApplication()
.AddInfrastructure(builder.Configuration)
.AddMappings();
}

var app = builder.Build();
{
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
}
