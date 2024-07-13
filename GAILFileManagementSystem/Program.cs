using FILESMGMT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
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
//builder.Services.AddDbContext<myDbContext>(options =>
//    options.UseSqlServer(config.GetConnectionString("dbcs")));
builder.Services.AddDbContext<VendorDBContext>(options =>
    options.UseSqlServer(config.GetConnectionString("dbcs")));
builder.Services.AddDbContext<FileDBContext>(options =>
    options.UseSqlServer(config.GetConnectionString("dbcs")).EnableSensitiveDataLogging()
               .LogTo(Console.WriteLine));
builder.Services.AddDbContext<ContractDBContext>(options =>
    options.UseSqlServer(config.GetConnectionString("dbcs")));
builder.Services.AddDbContext<LocationDBContext>(options =>
    options.UseSqlServer(config.GetConnectionString("dbcs")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "GAILRanchi/{controller=User}/{action=Index}/{id?}");

app.Run();
