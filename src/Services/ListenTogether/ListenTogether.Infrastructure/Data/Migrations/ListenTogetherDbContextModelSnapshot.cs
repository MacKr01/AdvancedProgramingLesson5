﻿// <auto-generated />
using System;
using ListenTogether.Hub.Infrastructure.Data;
using ListenTogether.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ListenTogether.Hub.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ListenTogetherDbContext))]
    partial class ListenTogetherDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ListenTogether.Hub.Infrastructure.Data.Models.Episode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan?>("Duration")
                        .HasColumnType("time");

                    b.Property<Guid>("EpisodeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Published")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ShowId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ShowId");

                    b.ToTable("Episodes", (string)null);
                });

            modelBuilder.Entity("ListenTogether.Hub.Infrastructure.Data.Models.Room", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("EpisodeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PlayerState")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("ProgressAt")
                        .HasColumnType("time");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Code");

                    b.HasIndex("EpisodeId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("ListenTogether.Hub.Infrastructure.Data.Models.Show", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ShowId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shows", (string)null);
                });

            modelBuilder.Entity("ListenTogether.Hub.Infrastructure.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConnectionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomCode")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoomCode");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ListenTogether.Hub.Infrastructure.Data.Models.Episode", b =>
                {
                    b.HasOne("ListenTogether.Hub.Infrastructure.Data.Models.Show", "Show")
                        .WithMany()
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Show");
                });

            modelBuilder.Entity("ListenTogether.Hub.Infrastructure.Data.Models.Room", b =>
                {
                    b.HasOne("ListenTogether.Hub.Infrastructure.Data.Models.Episode", "Episode")
                        .WithMany()
                        .HasForeignKey("EpisodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Episode");
                });

            modelBuilder.Entity("ListenTogether.Hub.Infrastructure.Data.Models.User", b =>
                {
                    b.HasOne("ListenTogether.Hub.Infrastructure.Data.Models.Room", null)
                        .WithMany("Users")
                        .HasForeignKey("RoomCode");
                });

            modelBuilder.Entity("ListenTogether.Hub.Infrastructure.Data.Models.Room", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
