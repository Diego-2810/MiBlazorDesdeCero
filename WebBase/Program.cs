using WebBase.Csharp.dapper;

var builder = WebApplication.CreateBuilder(args);

// Configuración (lee la connection string desde appsettings)
var cs = builder.Configuration.GetConnectionString("Default")!;

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Inyección de dependencia de IAdo
builder.Services.AddScoped<IAdo>(_ => new AdoDapper(cs));

var app = builder.Build();

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
