using BibliotecaElectronica.Data.Context;
using BibliotecaElectronica.Data.Services;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<BibliotecaElectronicaDbContext>();
builder.Services.AddScoped<IBibliotecaElectronicaDbContext, BibliotecaElectronicaDbContext>();
builder.Services.AddScoped<ILibroServices, LibroServices>();
builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();
builder.Services.AddSingleton<UserDataService>();
builder.Services.AddScoped<IMatDialogService, MatDialogService>();

builder.Services.AddMatBlazor();

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
