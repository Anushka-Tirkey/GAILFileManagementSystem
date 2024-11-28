using GAILFileManagementSystem.Models;      //Refers to the models used in the project.
using Microsoft.EntityFrameworkCore;        //Needed for interacting with the Entity Framework Core, which handles database operations.
using Microsoft.Extensions.Configuration;   //Provides functionalities such as configuration (IConfiguration) and dependency injection (IServiceCollection).
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;         //For building and hosting ASP.NET Core web applications.
using Microsoft.AspNetCore.Hosting;
using GAILFileManagementSystem.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Get the configuration service
var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();

// Add the DbContext with the connection string from the configuration
// builder.Services.AddDbContext<myDbContext>(options =>               /*Dependency Injection*/
//    options.UseSqlServer(config.GetConnectionString("dbcs")));
builder.Services.AddDbContext<myDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("dbcs")));
builder.Services.AddDbContext<myDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("dbcs")).EnableSensitiveDataLogging()
               .LogTo(Console.WriteLine));
builder.Services.AddDbContext<myDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("dbcs")));
builder.Services.AddDbContext<myDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("dbcs")));
builder.Services.AddDbContext<myDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("dbcs")));

builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
//EXCEPTION HANDLING:
if (!app.Environment.IsDevelopment())       //If the app is not in the development environment, it sets up an 
{                                           //exception handler and enables HTTP Strict Transport Security (HSTS) 
    app.UseExceptionHandler("/Home/Error"); //to enforce secure (HTTPS) connections.
    app.UseHsts();
}

//Middlewares
app.UseSession();
app.UseHttpsRedirection();  //Redirects HTTP requests to HTTPS.
app.UseStaticFiles();       //Serves static files like CSS, JavaScript, and images.
app.UseRouting();           //Enables routing for the application.
app.UseAuthorization();     //Enables authorization checks.

//Router
app.MapControllerRoute(
    name: "default",
    pattern: "GAILRanchi/{controller=User}/{action=Index}/{id?}");      //id is optional

app.Run();  //runs the application and starts listening for incoming HTTP requests.

/*Summary:
1. The code sets up an ASP.NET Core MVC web application with SQL Server as the database.
2. myDbContext is configured to use the connection string stored in the app’s configuration file.
3. Middleware is set up for routing, static files, HTTPS, and error handling.
4. The route configuration defaults to using the User controller’s Index action.*/