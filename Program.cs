using Microsoft.EntityFrameworkCore;
using LeadHunterUI.Data;
using LeadHunterUI.Services;
using LeadHunterUI.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<LeadDbContext>(options =>
    options.UseSqlite("Data Source=leads.db"));

var apiKey = builder.Configuration["GooglePlacesApiKey"]
    ?? Environment.GetEnvironmentVariable("GOOGLE_PLACES_API_KEY")
    ?? "";

builder.Services.AddSingleton(new GooglePlacesService(apiKey));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LeadDbContext>();
    db.Database.EnsureCreated();
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// This pulls the PORT from Render's environment, or defaults to 8080
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Run($"http://0.0.0.0:{port}");

