using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using WestWindSystem;
using WestWindWebApp.Data;

var builder = WebApplication.CreateBuilder(args);

//ADDED
//Retrieve the connectionstring from the appsettings
//The connection string will be passed to the library extension method for use in registering the access to the DB
var connectionString = builder.Configuration.GetConnectionString("WWDB");
//Set up the registration of the services to be aavailable for use by the web app
builder.Services.WWExtensions(options => options.UseSqlServer(connectionString));




// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

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
