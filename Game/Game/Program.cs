using Dal.Extensions;
using Business.Entensions;
using Model.Entities;
using Dal.Context;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();
//buraya Extension metodu yazýlýr.
builder.Services.LoadDalLayerExtension(builder.Configuration);
builder.Services.LoadBusinessLayerExtension();
builder.Services.AddIdentity<User, IdentityRole>(option =>
{
    //password
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireDigit = false;
    option.Password.RequireLowercase = false;
    option.Password.RequireUppercase = false;
    option.Password.RequiredLength = 4;
    option.Password.RequiredUniqueChars = 0;

}).AddEntityFrameworkStores<GameDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(configure =>
{
    configure.LoginPath = "/Home/Index";
    configure.LogoutPath = new PathString("/Home/Index");
    configure.Cookie = new CookieBuilder()
    {
        Name = "Game",
        HttpOnly = false,
        SameSite = SameSiteMode.Lax,
        SecurePolicy = CookieSecurePolicy.Always
    };
    configure.SlidingExpiration = true;
    configure.ExpireTimeSpan = TimeSpan.FromHours(2);
});
builder.Services.AddSession();
builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
