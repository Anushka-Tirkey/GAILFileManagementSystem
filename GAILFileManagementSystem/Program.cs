using GAILFileManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var provider = builder.Services.BuildServiceProvider(); //creating a service/service provider
var config = provider.GetRequiredService<IConfiguration>();
// ‘GetRequiredService’ is a generic method of ‘IConfiguration’ type
// Hence, line 1-> service create krna chha rhe hain;
// line 2-> wo service IConfiguration ki service hogi
builder.Services.AddDbContext<VendorDBContext>(item => item.UseSqlServer(config.GetConnectionString("dbcs")));
//we’re adding the dbcontext which is of the VendorDBContext type
//two namespaces will be added too 
//UseSqlServer -> Used to denote that we're using the SQL database provider
//dbcs-> name of the connection string
//GetConnectionString("dbcs") -> isse dbcs key ka value retrieve ho rha h; hence we have registered in it

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();   //Compulsory for forms

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "GAILRanchi/{controller=User}/{action=Index}/{id?}");


//app.MapControllerRoute(
//    name: "EnterFiles",
//    pattern: "{controller=User}/{action=Index/Files}/{id?}");

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=User}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
