using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GEST.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using GEST.Areas.Admin.Data;
using GEST.Areas.Admin.Data.GEST.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GESTContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GESTContext") ?? throw new InvalidOperationException("Connection string 'GESTContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.LoginPath = "/Admin";
        options.AccessDeniedPath = "/Forbidden/";
    });

var app = builder.Build();

SeedDatabase();
void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
        try
        {
            var scopedContext = scope.ServiceProvider.GetRequiredService<GESTContext>();
            Seeder.Seed(scopedContext);
        }
        catch
        {
            throw;
        }
}

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Login}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
