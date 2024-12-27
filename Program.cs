using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Web_Odev.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//HttpClient ekleme
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseUrl"]);
});



// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false; // Rakam zorunlu de�il
    options.Password.RequiredLength = 3;  // Minimum uzunluk 3 karakter
    options.Password.RequireNonAlphanumeric = false; // �zel karakter zorunlu de�il
    options.Password.RequireUppercase = false; // B�y�k harf zorunlu de�il
    options.Password.RequireLowercase = false; // K���k harf zorunlu de�il
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Authentication and Authorization
app.UseAuthentication();
app.UseAuthorization();

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map Razor Pages for Identity UI
app.MapRazorPages();

app.Run();
