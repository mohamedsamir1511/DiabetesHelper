using DiabetesHelper.BLL.Interfaces;
using DiabetesHelper.BLL.Repositories;
using DiabetesHelper.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ????? ??????? ?????? ????????
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=.;Database=DiabetesHelperDb;TrustServerCertificate=True;Trusted_Connection=True"));

// ??? ???????? ???? Repositories
builder.Services.AddScoped<IUserInterface, UserRepository>();
builder.Services.AddScoped<IGlucoseReadingInterface, GloucoseReadingRepository>();
builder.Services.AddScoped<IAlertInterface, AlertRepository>();

// ????? ??? Session
builder.Services.AddSession();

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

// ????? ??? Session ?? ?????? ???
app.UseSession();

app.UseAuthorization(); // ??? authorization ???? authentication

// ????? ??????
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Welcome}/{id?}");

app.Run();
