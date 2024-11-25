using Microsoft.EntityFrameworkCore;
using CampeonatoOrganizado.Models;
    
var builder = WebApplication.CreateBuilder(args);

var connString =
    builder
    .Configuration["ConnectionStrings:DefaultConnection"];

// Fazemos a configuração do DbContext com
// o banco de dados específico, neste caso
// o SQLServer
builder.Services.AddDbContext<BancoDadosContext>(
    o => o.UseSqlServer(connString)
);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<PontuacaoService>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Atleta}/{action=Index}/{id?}");


app.Run();
