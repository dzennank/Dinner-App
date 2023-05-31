using BuberDuinner.Application;
using BuberDinner.Infrastructure;
using BuberDuinner.Application.Authentication;

var builder = WebApplication.CreateBuilder(args);
{
builder.Services.AddControllers();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddApplication().AddInfrastructure();
}

var app = builder.Build();
{
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
}
