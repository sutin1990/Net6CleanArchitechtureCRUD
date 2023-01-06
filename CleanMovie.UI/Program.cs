global using Microsoft.AspNetCore.Components.Authorization;
global using CleanMovie.UI.Services;
global using CleanMovie.UI.Data;
global using CleanMovie.Domain.DBModels;
global using Blazored.LocalStorage;
global using Microsoft.JSInterop;
global using CleanMovie.Domain.ReponseModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using CleanMovie.UI.Provider;


var builder = WebApplication.CreateBuilder(args);

//Register Configuration
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(configuration.GetSection("BaseApi").Value) });

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IMoviesRentalTransactionService, MoviesRentalTransactionService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<AuthenticationStateProvider, CutomAuthStateProvider>();
//builder.Services.AddBlazoredLocalStorage(config =>
//{
//    //config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
//    //config.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
//    //config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
//    //config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
//    //config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
//    //config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
//    config.JsonSerializerOptions.WriteIndented = false;
//});
builder.Services.AddAuthenticationCore();

builder.Services.AddBlazoredLocalStorage();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
