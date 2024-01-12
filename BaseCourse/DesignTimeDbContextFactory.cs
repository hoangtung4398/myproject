using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BaseCourse.Models;

namespace BaseCourse
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CourseContext>
	{
		CourseContext IDesignTimeDbContextFactory<CourseContext>.CreateDbContext(string[] args)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			var builder = new DbContextOptionsBuilder<CourseContext>();
			var connectionString = configuration.GetConnectionString("DefaultConnection");

			builder.UseSqlServer(connectionString);

			return new CourseContext(builder.Options);
		}
	}
}
