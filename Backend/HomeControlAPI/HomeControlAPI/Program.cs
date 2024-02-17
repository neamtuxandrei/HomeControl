using HomeControlAPI.Data;
using HomeControlAPI.DataAccess;
using HomeControlAPI.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDbContext<HomeControlDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddControllersWithViews()
    .AddJsonOptions(x =>
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Home Control API", Version = "v1" });
});

// dependency injection
builder.Services.RegisterApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();



bool isFirstRun = !File.Exists("firstrun.flag");
if (isFirstRun)
{
    // to initiate migrations and seed data every time the app is built.
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var homeControlDbContext = services.GetRequiredService<HomeControlDbContext>();
        var applicationDbContext = services.GetRequiredService<ApplicationDbContext>();
        //RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        try
        {
            await homeControlDbContext.Database.MigrateAsync();
            await applicationDbContext.Database.MigrateAsync();

            await HomeControlSeedData.SeedDataAsync(homeControlDbContext);

            File.WriteAllText("firstrun.flag", "Migration and seeding completed.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

app.Run();
