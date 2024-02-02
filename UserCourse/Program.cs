using CourseAPI.Repository.IRepository;
using CourseAPI.Repository;
using CourseAPI.Services.IService;
using CourseAPI.Services;
using BaseCourse.Models;
using Microsoft.EntityFrameworkCore;
using AuthAPI.Repositorys.IRepository;
using AuthAPI.Repositorys;
using UserCourseAPI.Middleware;
using CourseAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CourseContext>(option =>
{
	option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IGetUserService, GetUserService>();
builder.Services.AddScoped<IUserCourseRepository, UserCourseRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddTransient<TokenMiddleware>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<TokenMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
