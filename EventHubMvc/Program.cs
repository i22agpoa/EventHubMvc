using EventHubMvc.Data;
using EventHubMvc.Models;
using Microsoft.EntityFrameworkCore;
using EventHubMvc.Repositories;
using EventHubMvc.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;

    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 3;
    options.Password.RequiredUniqueChars = 1;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IVenueRepository, VenueRepository>();
builder.Services.AddScoped<IVenueService, VenueService>();

builder.Services.AddScoped<IOrganizerRepository, OrganizerRepository>();
builder.Services.AddScoped<IOrganizerService, OrganizerService>();

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

app.UseAuthentication();
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

app.MapRazorPages();

app.Run();
