using CourseAPI.Services;
using Mango.Web.Service;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;
using BaseCourse.Service.IService;
using BaseCourse.AzureConfig;
using Learnify.Web.Service.IService;
using Learnify.Web.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
SD.CouponAPIbase = builder.Configuration["ServiceUrls:CouponAPI"];
SD.AuthAPIbase = builder.Configuration["ServiceUrls:AuthAPI"];
SD.CourseAPIbase = builder.Configuration["ServiceUrls:CourseAPI"];
SD.UserCourseAPIbase = builder.Configuration["ServiceUrls:UserCourse"];
SD.DocumentAPIbase = builder.Configuration["ServiceUrls:DocumentAPI"];

builder.Services.AddHttpClient();
builder.Services.Configure<StorageLecture>(builder.Configuration.GetSection("AzureOption:LectureAzureStorageConnectionS"));
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ILectureStorageService, LectureStorageService>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddScoped<IUserCourseService, UserCourseService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromHours(30);
    options.LoginPath = "/Auth/Login";
    options.AccessDeniedPath = "/Auth/AccessDenied";
    options.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
