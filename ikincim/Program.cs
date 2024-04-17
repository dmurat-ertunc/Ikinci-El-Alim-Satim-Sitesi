using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using ikincim.Localization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof (Program));
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser,AppRole>(options =>
{
    options.User.RequireUniqueEmail = true; // email unique deðer olacak
    options.Password.RequiredLength = 6;  // þifre en az 6 karakterden olacak
    options.Password.RequireNonAlphanumeric = false; // -*? gibi karakterler zorunlu deðil
    options.Password.RequireDigit = false; // sayý olmak zorunda deðil
    options.Password.RequireLowercase = false; 
    options.Password.RequireUppercase = false;
}).AddErrorDescriber<LocalizationErrorDescriber>().AddEntityFrameworkStores<Context>();

builder.Services.ConfigureApplicationCookie(opt =>
{
    var cookieBuilder = new CookieBuilder();

    cookieBuilder.Name = "Kokiyim";
    opt.LoginPath = new PathString("/Login/Index"); // Giriþin engellendiði sayfaya týklayýnca bizi atacaðý sayfa
    opt.LogoutPath = new PathString("/Register/LogOut");
    opt.Cookie= cookieBuilder;
    opt.ExpireTimeSpan = TimeSpan.FromDays(10);
    opt.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HomePage}/{action=Index}/{id?}");

app.Run();
