
using AuthAPI.Repositorys;
using AuthAPI.Repositorys.IRepository;
using BaseCourse.Models;
using CourseAPI.Middleware;
using CourseAPI.Models;
using CourseAPI.Models.AzureConfig;
using CourseAPI.Repository;
using CourseAPI.Repository.IRepository;
using CourseAPI.Services;
using CourseAPI.Services.IService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CourseContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.Configure<StorageLecture>(builder.Configuration.GetSection("AzureOption:LectureAzureStorageConnectionS"));
builder.Services.AddScoped<ICourseRepository,CourseRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILectureRepository,LectureRepository >();
builder.Services.AddScoped<ISectionRepository, SectionRepository>();
builder.Services.AddScoped<IUserCourseRepository, UserCourseRepository>();
builder.Services.AddScoped<ILectureStorageService, LectureStorageService>();
builder.Services.AddScoped<ICategoryCourseRepository, CategoryCourseRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IGetUserService, GetUserService>();
builder.Services.AddTransient<GetTokenMiddleware>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseMiddleware<GetTokenMiddleware>();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
