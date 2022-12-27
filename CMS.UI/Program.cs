using CMS.UI.Data;
using CMS.UI.Models;
using CMS.UI.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connecctionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connecctionString, ServerVersion.AutoDetect(connecctionString)));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<IIDbInicializer, DbInicializer>();
// Configure the HTTP request pipeline.
var app = builder.Build();

//Siembra de datos
DataSeeding();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//Inicializa la base dedatos
void DataSeeding()
{
    using (var scope = app.Services.CreateScope())
    {

        var DbInicialize = scope.ServiceProvider.GetRequiredService<IIDbInicializer>();
        DbInicialize.Inicialize();
    }
}