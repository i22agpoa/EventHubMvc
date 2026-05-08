using EventHubMvc.Data;
using EventHubMvc.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    if (!context.Categories.Any())
    {
        context.Categories.AddRange(
            new Category { Name = "Technology" },
            new Category { Name = "Business" },
            new Category { Name = "Music" }
        );
    }

    if (!context.Venues.Any())
    {
        context.Venues.AddRange(
            new Venue
            {
                Name = "Craiova Innovation Hall",
                City = "Craiova",
                Address = "Main Street 10",
                Capacity = 300
            },
            new Venue
            {
                Name = "Bucharest Arena",
                City = "Bucharest",
                Address = "Victory Avenue 25",
                Capacity = 1000
            }
        );
    }

    if (!context.Organizers.Any())
    {
        context.Organizers.AddRange(
            new Organizer
            {
                Name = "EventHub Team",
                Email = "team@eventhub.com"
            },
            new Organizer
            {
                Name = "Student Events Association",
                Email = "contact@sea.com"
            }
        );
    }

    context.SaveChanges();
}

app.Run();
