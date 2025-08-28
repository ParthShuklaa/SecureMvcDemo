using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity; // Add this using directive
using SecureMvcDemo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// here we configure the database context
// builder.Services.AddDbContext<ApplicationDbContext>(options =>
// // options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // MS SQLServer
//     options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))); // SQLite

//     //Adding default identity for user authentication and authorization
//     builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseSqlite("Data Source=secure.db"));

// IdentityBuilder identityBuilder = builder.Services.AddDefaultIdentity<IdentityUser>(options => 
//     options.SignIn.RequireConfirmedAccount = false)
//     .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();



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
app.UseAuthentication();   // important
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
