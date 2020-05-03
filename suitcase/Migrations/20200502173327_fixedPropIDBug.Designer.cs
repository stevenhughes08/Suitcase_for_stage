﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using suitcase.Data;

namespace suitcase.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200502173327_fixedPropIDBug")]
    partial class fixedPropIDBug
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("suitcase.Models.Act", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(80);

                    b.Property<Guid>("PerformanceId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PerformanceId");

                    b.ToTable("Acts");
                });

            modelBuilder.Entity("suitcase.Models.ActPerformer", b =>
                {
                    b.Property<Guid>("PerformerId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ActId")
                        .HasColumnType("TEXT");

                    b.HasKey("PerformerId", "ActId");

                    b.HasIndex("ActId");

                    b.ToTable("ActPerformer");
                });

            modelBuilder.Entity("suitcase.Models.ActProp", b =>
                {
                    b.Property<Guid>("PropId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ActId")
                        .HasColumnType("TEXT");

                    b.HasKey("PropId", "ActId");

                    b.HasIndex("ActId");

                    b.ToTable("ActProp");
                });

            modelBuilder.Entity("suitcase.Models.Performance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.ToTable("Performances");
                });

            modelBuilder.Entity("suitcase.Models.Performer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("HeadShotUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.ToTable("Performers");
                });

            modelBuilder.Entity("suitcase.Models.Prop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PropId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(80);

                    b.Property<Guid>("PropId")
                        .HasColumnName("PropId1")
                        .HasColumnType("TEXT");

                    b.Property<string>("StorageLocation")
                        .HasColumnType("TEXT");

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
