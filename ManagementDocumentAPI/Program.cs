using AuthAPI.Repositorys;
using AuthAPI.Repositorys.IRepository;
using BaseCourse.Models;
using ManagementDocumentAPI.Middleware;
using ManagementDocumentAPI.Repository;
using ManagementDocumentAPI.Repository.IRepository;
using ManagementDocumentAPI.Services;
using ManagementDocumentAPI.Services.IService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CourseContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IGetUserService, GetUserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddTransient<TokenMiddleware>();
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
	app.UseMiddleware<TokenMiddleware>();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
