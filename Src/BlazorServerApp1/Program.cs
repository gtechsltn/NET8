using BlazorServerApp1.Data;
using ClassLibrary1.Data;
using ClassLibrary1.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MonsterContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MonsterContext"));
});

// Add services to the container.
builder.Services.AddScoped(sp => new HttpClient { 
    BaseAddress = new Uri(builder.Configuration.GetSection("BaseUri").Value) 
});

builder.Services.AddScoped<IMonsterService, ClientMonsterService>();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

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
