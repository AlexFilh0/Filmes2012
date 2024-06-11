using Microsoft.EntityFrameworkCore;
using Filmes2012.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Filmes2012Context>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Filmes2012Context")));

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();