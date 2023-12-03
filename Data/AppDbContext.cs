using Microsoft.EntityFrameworkCore;
using final_project_it3045c.Models;

namespace final_project_it3045c.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<MemberDetails> MemberDetails { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
