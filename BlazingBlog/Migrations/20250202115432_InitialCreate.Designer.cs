﻿// <auto-generated />
using BlazingBlog.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazingBlog.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20250202115432_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("BlazingBlog.Shared.Models.BlogPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "This is the first post",
                            Title = "First post"
                        },
                        new
                        {
                            Id = 2,
                            Content = "This is the second post",
                            Title = "Second post"
                        },
                        new
                        {
                            Id = 3,
                            Content = "This is the third post",
                            Title = "Third post"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
