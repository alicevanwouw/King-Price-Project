using King_Price_Assessment.Controllers;
using King_Price_Assessment.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//builder.Services.AddDbContext<UserManagementContext>(options =>
//                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<UserManagementContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddRazorPages();
builder.Services.AddControllers();

//var host = Host.CreateDefaultBuilder(args).Build();

//using (var scope = host.Services.CreateScope())
//{
//    Console.WriteLine("here");
//    var services = scope.ServiceProvider;
//    try
//    {
//        var context = services.GetRequiredService<UserManagementContext>();
//        DatabaseInitializer.Initialize(context);
//    }
//    catch (Exception ex)
//    {
//        var logger = services.GetRequiredService<ILogger<Program>>();
//        logger.LogError(ex, "An error occurred while seeding the database.");
//    }
//}

builder.Services.AddScoped<DatabaseInitializer>();
builder.Services.AddScoped<UserController>();
builder.Services.AddScoped<GroupController>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


app.Run();

