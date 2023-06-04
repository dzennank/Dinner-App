using BuberDuinner.Application;
using BuberDinner.Infrastructure;
using BuberDuinner.Application.Common.Interfaces.Authentication.Commands;
using BuberDuinner.Application.Common.Interfaces.Authentication.Queries;

var builder = WebApplication.CreateBuilder(args);
{
builder.Services.AddControllers();
builder.Services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
builder.Services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
builder.Services
.AddApplication()
.AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
}
