using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthAPI.Models.Data
{
    public class AppDbcontext : IdentityDbContext<ApplicationUser>
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }
    }
}
