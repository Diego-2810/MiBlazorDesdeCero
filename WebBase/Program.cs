using WebBase.Csharp.dapper;
using WebBase.Csharp.Entidades;


string cadena = "server=localhost;database=NetflixLibroBD;user=5to_agbd;password=Trigg3rs!;";

var _adoDapper = new AdoDapper(cadena);

Genero genero = new Genero
{
    idGenero = 1,
    genero = "Uwu"
};

_adoDapper.AltaGenero(genero);


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


// Razor/Blazor
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// IAdo con Dapper + MySQL
var cs = builder.Configuration.GetConnectionString("default")!;
builder.Services.AddScoped<IAdo>(sp => new AdoDapper(cs));

// pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

