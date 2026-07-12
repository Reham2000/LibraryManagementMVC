using LibraryMVC.Data;
using LibraryMVC.Repossitories;
using LibraryMVC.Repossitories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var con = builder.Configuration.GetConnectionString("con");

builder.Services.AddDbContext<AppDbContext>(
    op =>
    {
        op.UseSqlServer(con);
    }
    );
builder.Services.AddScoped<AppDbContext>();

builder.Services.AddScoped<LibraryMVC.Services.BookServices>();
//builder.Services.AddTransient<LibraryMVC.Services.BookServices>();
//builder.Services.AddSingleton<LibraryMVC.Services.BookServices>();

//builder.Services.AddScoped(typeof(IGenaricRepo<>), typeof(GenaricRepo<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
