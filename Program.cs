using MovieDbAngDotNet.Controllers;
using MovieDbAngDotNet.DataAccessLayer;
using MovieDbAngDotNet.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var EnvPol = "_envPol";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<MoviesContext>();

builder.Services.AddControllers();

builder.Services.AddScoped<IMovieDb, MovieDataAccess>();
builder.Services.AddScoped<IUserDb, UserDataAccess>();




builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: EnvPol, builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod()
                .SetIsOriginAllowed(SeekOrigin => true).AllowCredentials();
    });
});


builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddScoped<IMovieDb, MovieDbController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseHttpsRedirection();

app.UseRouting();
app.UseCors(EnvPol);
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
