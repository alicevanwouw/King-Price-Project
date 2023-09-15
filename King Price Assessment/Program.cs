using King_Price_Assessment.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

//builder.Services.AddScoped<UserController>();
//builder.Services.AddScoped<GroupController>();

//builder.Services.AddDbContext<UserManagementContext>(options =>
//               options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresEntity")));


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
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


app.Run();
