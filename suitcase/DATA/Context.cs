using Microsoft.EntityFrameworkCore;
using System.Data;
using suitcase.Models;

namespace suitcase.Data
{
    public class Context : DbContext
    {
       
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Prop> Props { get; set; }
        public DbSet<Act> Acts { get; set; }
        public DbSet<Performer> Performers { get; set; }

        public DbSet<Performance> Performances { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=suitcaseContext.db");
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        
            modelBuilder.Entity<ActPerformer>()
                .HasKey(t => new { t.PerformerId, t.ActId });
            modelBuilder.Entity<ActProp>()
                .HasKey(t => new { t.PropId, t.ActId });
        }
        public DbSet<Act> Acts { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Prop> Props { get => props; set => props = value; }
    }


}