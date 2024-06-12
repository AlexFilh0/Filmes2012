using Microsoft.EntityFrameworkCore;
using Filmes2012.Data;
using Filmes2012.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner.
var connectionString = builder.Configuration.GetConnectionString("Filmes2012Context");
builder.Services.AddDbContext<Filmes2012Context>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddControllersWithViews();

// Configurar HttpClient com ignorar erros de certificado SSL (apenas para desenvolvimento)
builder.Services.AddHttpClient<FilmesController>(client =>
{
    client.BaseAddress = new Uri("https://localhost:5146"); // Ajuste a URL conforme necessário
})
.ConfigurePrimaryHttpMessageHandler(() =>
{
    return new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
    };
});

var app = builder.Build();

// Configura o pipeline de requisição HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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