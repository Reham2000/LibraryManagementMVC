using LibraryMVC.Data;
using LibraryMVC.Data.Seed;
using LibraryMVC.Models;
using LibraryMVC.Repossitories;
using LibraryMVC.Repossitories.Interfaces;
using LibraryMVC.Services;
using LibraryMVC.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
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

builder.Services.AddIdentity<User, IdentityRole>(
    op =>
    {
        //op.Password.RequiredUniqueChars = true;
        op.Password.RequireNonAlphanumeric = true;
        op.Password.RequiredLength = 6;
        op.Password.RequireUppercase = true;
        op.Password.RequireLowercase = true;
    }
    ).AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


builder.Services.ConfigureApplicationCookie(
    option =>
    {
        option.LoginPath = "/Account/Login";
        option.LogoutPath = "/Account/Logout";
        option.AccessDeniedPath = "/Account/AccessDenied";
    }
    );


builder.Services.AddScoped<AppDbContext>();

builder.Services.AddScoped<IBookService,BookService>();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IAccountService,AccountService>();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();


using(var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider
                    .GetRequiredService<RoleManager<IdentityRole>>();
    await RolesSeeder.SeedRoles(roleManager);
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
