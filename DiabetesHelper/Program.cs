using DiabetesHelper.BLL.Interfaces;
using DiabetesHelper.BLL.Repositories;
using DiabetesHelper.DAL;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer("Server=.;Database=DiabetesHelperDb;TrustServerCertificate=True;Trusted_Connection=True"));
builder.Services.AddScoped<IUserInterface, UserRepository>();
builder.Services.AddScoped<IGlucoseReadingInterface,GloucoseReadingRepository>();
builder.Services.AddScoped<IAlertInterface, AlertRepository>();
builder.Services.AddSession();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Welcome}/{id?}");

app.Run();
