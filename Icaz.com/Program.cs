using Icaz.com.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IcazContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

builder.Services.AddIdentity<Member, Rol>().AddEntityFrameworkStores<IcazContext>().AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/error/PageNotFound";
        await next();
    }
    else if (context.Response.StatusCode == 502)
    {
        context.Request.Path = "/error/PageNotFound";
        await next();
    }
    else if (context.Response.StatusCode == 401)
    {
        context.Request.Path = "/error/PageNotFound";
        await next();
    }
    else if (context.Response.StatusCode == 403)
    {
        context.Request.Path = "/error/PageNotFound";
        await next();
    }
    else if (context.Response.StatusCode == 405)
    {
        context.Request.Path = "/error/PageNotFound";
        await next();
    }
    else if (context.Response.StatusCode == 409)
    {
        context.Request.Path = "/error/PageNotFound";
        await next();
    }
});
    
    
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error", "?code={0}");//buradaki id ismi controllerdaki parametre ismi ile ayný olmalýdýr.

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
