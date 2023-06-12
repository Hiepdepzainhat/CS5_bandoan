using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CSharp5_Web_Client.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CSharp5_Web_ClientContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CSharp5_Web_ClientContext") ?? throw new InvalidOperationException("Connection string 'CSharp5_Web_ClientContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
