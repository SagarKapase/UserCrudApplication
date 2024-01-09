using Microsoft.EntityFrameworkCore;

namespace UserCRUDApplication.Models
{
    public class UserDbContext : DbContext
    {
      public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
      {
        
      }

 /*       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=root;database=user");
            }
        }*/
        public DbSet<User> Users { get; set; }
    }
}
