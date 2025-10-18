using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor(); // keep if you use Server Blazor; remove if not applicable
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllers();

// Map MVC endpoints under /mvc to avoid colliding with Blazor @page routes
app.MapControllerRoute(
    name: "mvc",
    pattern: "mvc/{controller=Invoice}/{action=Index}/{id?}"
);

// Keep your Blazor fallback (pick the one that matches your project):
// For Blazor Server:
app.MapFallbackToPage("/_Host");
// For Blazor WebAssembly hosted (uncomment if appropriate):
// app.MapFallbackToFile("index.html");

app.Run();
