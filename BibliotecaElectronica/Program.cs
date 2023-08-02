using BibliotecaElectronica.Data.Context;
using BibliotecaElectronica.Data.Services;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;
using System.Globalization;


var builder = WebApplication.CreateBuilder(args);
CultureInfo culturaEs = new CultureInfo("es-ES");
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<BibliotecaElectronicaDbContext>();
builder.Services.AddScoped<IBibliotecaElectronicaDbContext, BibliotecaElectronicaDbContext>();
builder.Services.AddScoped<ILibroServices, LibroServices>();
builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();
builder.Services.AddSingleton<UserDataService>();
builder.Services.AddScoped<IMatDialogService, MatDialogService>();
builder.Services.AddMudServices();
builder.Services.AddMatBlazor();
builder.Services.AddScoped<IColor, Color>();
CultureInfo.DefaultThreadCurrentCulture = culturaEs;
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
