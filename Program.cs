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

app.Run();
