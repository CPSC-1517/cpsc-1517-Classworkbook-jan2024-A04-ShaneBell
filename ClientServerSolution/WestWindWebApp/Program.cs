using Microsoft.EntityFrameworkCore;
using WestWindSystem;
using WestWindWebApp.Components;

var builder = WebApplication.CreateBuilder(args);

//ADDED
var connectionString = builder.Configuration.GetConnectionString("WWDB");
builder.Services.WWExtensions(options=> options.UseSqlServer(connectionString));







// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
