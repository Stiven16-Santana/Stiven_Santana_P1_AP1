using Microsoft.EntityFrameworkCore;
using Stiven_Santana_P1_AP1.Components;
using Stiven_Santana_P1_AP1.DAL;
using Stiven_Santana_P1_AP1.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Obtenemos el ConStr para usarlo en el contexto
var ConStr = builder.Configuration.GetConnectionString("SqlConStr");

builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(ConStr));

//Inyeccion del service
builder.Services.AddScoped<AportesService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
