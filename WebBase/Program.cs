using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Agregamos soporte para Razor Pages y Blazor Server
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();      // wwwroot habilitado
app.UseRouting();          // Habilita el enrutamiento interno

// Configura el endpoint de Blazor
app.MapBlazorHub();

// Fallback a Razor si la URL no coincide con nada (en vez de usar index.html)
app.MapFallbackToPage("/_Host");

app.Run();

