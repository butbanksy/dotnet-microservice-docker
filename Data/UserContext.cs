using Microsoft.EntityFrameworkCore;
using UsersMicroservice.Models;

namespace UsersMicroservice.Data
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public UserContext(DbContextOptions<UserContext> opt) : base(opt)
        {
            
        }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=dockerization;Username=postgres;Password=postgres");
    }
}