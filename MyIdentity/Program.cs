
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyIdentity.Authentication;
using MyIdentity.Authorization;
using MyIdentity.Data;
using AuthenticationOptions = MyIdentity.Authentication.AuthenticationOptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDbContext>(cfg => cfg.UseSqlServer(config.GetConnectionString("Database")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer();
builder.Services.Configure<AuthenticationOptions>(config.GetSection("Authentication"));

builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddScoped<IJwtService, JwtService>();


builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserContext, UserContext>();

builder.Services.AddScoped<AuthorizationService>();
builder.Services.AddTransient<IClaimsTransformation, CustomClaimsTransformation>();
builder.Services.AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>();
builder.Services.AddTransient<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

var app = builder.Build();
Console.WriteLine("App built successfully");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    Console.WriteLine("Enabling Swagger...");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

Console.WriteLine("Using HTTPS Redirection");
app.UseAuthentication();

Console.WriteLine("Using Authentication");
app.UseAuthorization();

Console.WriteLine("Using Authorization");


app.MapControllers();
Console.WriteLine("Mapped Controllers");
app.Run();
