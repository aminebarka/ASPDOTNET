using GestiondeLocation.EF_core;
using GestiondeLocation.Models;
using GestiondeLocation.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextPool<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("LocationDBConnection"
)));


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRepository<Voiture>, SqlVoitureRepository>();
builder.Services.AddScoped<IRepository<Location>, SqlLocationRepository>();
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
