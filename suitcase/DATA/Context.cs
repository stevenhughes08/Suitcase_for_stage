using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using suitcase.Models;

namespace suitcase.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=suitcaseContext.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<ActPerformer>().HasKey(t => new { t.PerformerId, t.ActId });
            modelBuilder.Entity<ActProp>().HasKey( t => new { t.PropId, t.ActId });
        }
        DbSet<Act> Acts { get; set; }
        DbSet<Performance> Performances { get; set; }
        DbSet<Performer> Performers { get; set; }
        DbSet<Prop> Props {get; set; }
    }

    
}