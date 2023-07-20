using BSATask.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BSATask.DAL.Context
{
    public class BSATaskContext : DbContext
    {
        public BSATaskContext(DbContextOptions<BSATaskContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
