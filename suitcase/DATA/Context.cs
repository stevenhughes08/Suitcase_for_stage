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
            modelBuilder.Entity<Prop>()
                    .Property(p => p.Id)
                    .HasColumnName("PropId");

            modelBuilder.Entity<ActPerformer>().HasKey(apr => new { apr.PerformerId, apr.ActId });
            modelBuilder.Entity<ActPerformer>()
                .HasOne(apr => apr.Act).WithMany(a => a.ActPerformers).HasForeignKey(apr => apr.ActId);
            
            modelBuilder.Entity<ActPerformer>().HasOne<Performer>(p => p.Performer ).WithMany(a => a.ActPerformers)
.HasForeignKey(p => p.PerformerId);
         
            modelBuilder.Entity<ActProp>().HasKey(t => new { t.PropId, t.ActId });
                
            modelBuilder.Entity<ActProp>()
                .HasOne(ap => ap.Act)
                .WithMany(p => p.ActProps)
                .HasForeignKey(ap => ap.ActId);

            modelBuilder.Entity<ActProp>()
                .HasOne(ap => ap.Prop)
                .WithMany(p => p.ActProps)
                .HasForeignKey(ap => ap.PropId);

        }

        public DbSet<Act> Acts { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Prop> Props { get; set; }
    }


}