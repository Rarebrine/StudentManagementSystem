using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddSession();

builder.Services.Configure<ServiceUrls>(builder.Configuration.GetSection("ServiceUrls"));

builder.Services.AddHttpClient("StudentService", client =>
{
    var url = builder.Configuration["ServiceUrls:StudentService"];
    client.BaseAddress = new Uri(url!);
});
builder.Services.AddHttpClient("CourseService", client =>
{
    var url = builder.Configuration["ServiceUrls:CourseService"];
    client.BaseAddress = new Uri(url!);
});
builder.Services.AddHttpClient("AuthService", client =>
{
    var url = builder.Configuration["ServiceUrls:AuthService"];
    client.BaseAddress = new Uri(url!);
});

builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseSession(); 

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}"
);

app.Run();

// strong-typed binding for URLs
public class ServiceUrls
{
    public string StudentService { get; set; } = null!;
    public string CourseService { get; set; } = null!;
    public string AuthService { get; set; } = null!;
}
