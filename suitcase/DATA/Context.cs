using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using suitcase.Models;

namespace suitcase.Data
{
    public class Context : DbContext
    {
        private DbSet<Prop> props;

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=suitcaseContext.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Prop>()
            //     .HasMany<Act>(a => a.Acts)
            //     .WithMany<Prop>(p => p.Props)
            //     .Map(cs => {
            //         cs.MapLeftKey("ActId");
            //         cs.MapRightKey("PropId");
            //         cs.ToTable("ActProps");
            //     });

                
        
            modelBuilder.Entity<ActPerformer>().HasKey(t => new { t.PerformerId, t.ActId });
            modelBuilder.Entity<ActProp>().HasKey(t => new { t.PropId, t.ActId });
        }
        public DbSet<Act> Acts { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Prop> Props { get => props; set => props = value; }
    }


}