﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using suitcase.Data;

namespace suitcase.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200412001946_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("suitcase.Models.Act", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PerformanceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PerformanceId");

                    b.ToTable("Acts");
                });

            modelBuilder.Entity("suitcase.Models.ActPerformer", b =>
                {
                    b.Property<Guid>("PerformerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ActId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PerformerId", "ActId");

                    b.HasIndex("ActId");

                    b.ToTable("ActPerformer");
                });

            modelBuilder.Entity("suitcase.Models.ActProp", b =>
                {
                    b.Property<Guid>("PropId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ActId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PropId", "ActId");

                    b.HasIndex("ActId");

                    b.ToTable("ActProp");
                });

            modelBuilder.Entity("suitcase.Models.Performance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Performances");
                });

            modelBuilder.Entity("suitcase.Models.Performer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HeadShotUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Performers");
                });

            modelBuilder.Entity("suitcase.Models.Prop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PropId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StorageLocation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Props");
                });

            modelBuilder.Entity("suitcase.Models.Act", b =>
                {
                    b.HasOne("suitcase.Models.Performance", "Performance")
                        .WithMany("Acts")
                        .HasForeignKey("PerformanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("suitcase.Models.ActPerformer", b =>
                {
                    b.HasOne("suitcase.Models.Act", "Act")
                        .WithMany("ActPerformers")
                        .HasForeignKey("ActId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("suitcase.Models.Performer", "Performer")
                        .WithMany("ActPerformers")
                        .HasForeignKey("PerformerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("suitcase.Models.ActProp", b =>
                {
                    b.HasOne("suitcase.Models.Act", "Act")
                        .WithMany("ActProps")
                        .HasForeignKey("ActId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("suitcase.Models.Prop", "Prop")
                        .WithMany("ActProps")
                        .HasForeignKey("PropId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}