﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using amazingShop.Infra;

namespace amazingShop.Infra.Migrations
{
    [DbContext(typeof(ShopContext))]
    partial class ShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:IdentityIncrement", 1)
                .HasAnnotation("SqlServer:IdentitySeed", 1)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("amazingShop.Domain.Core.Events.Event", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("Event");
                });

            modelBuilder.Entity("amazingShop.Domain.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(512)")
                        .HasMaxLength(512);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "camiseta",
                            ImageUrl = "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg",
                            Name = "camiseta",
                            Price = 18.280000000000001
                        },
                        new
                        {
                            Id = 2L,
                            Description = "camiseta",
                            ImageUrl = "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg",
                            Name = "camiseta",
                            Price = 18.280000000000001
                        },
                        new
                        {
                            Id = 3L,
                            Description = "camiseta",
                            ImageUrl = "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg",
                            Name = "camiseta",
                            Price = 18.280000000000001
                        },
                        new
                        {
                            Id = 4L,
                            Description = "camiseta",
                            ImageUrl = "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg",
                            Name = "camiseta",
                            Price = 18.280000000000001
                        },
                        new
                        {
                            Id = 5L,
                            Description = "camiseta",
                            ImageUrl = "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg",
                            Name = "camiseta",
                            Price = 18.280000000000001
                        },
                        new
                        {
                            Id = 6L,
                            Description = "camiseta",
                            ImageUrl = "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg",
                            Name = "camiseta",
                            Price = 18.280000000000001
                        },
                        new
                        {
                            Id = 7L,
                            Description = "camiseta",
                            ImageUrl = "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg",
                            Name = "camiseta",
                            Price = 18.280000000000001
                        },
                        new
                        {
                            Id = 8L,
                            Description = "camiseta",
                            ImageUrl = "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg",
                            Name = "camiseta",
                            Price = 18.280000000000001
                        },
                        new
                        {
                            Id = 9L,
                            Description = "camiseta",
                            ImageUrl = "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg",
                            Name = "camiseta",
                            Price = 18.280000000000001
                        },
                        new
                        {
                            Id = 10L,
                            Description = "camiseta",
                            ImageUrl = "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg",
                            Name = "camiseta",
                            Price = 18.280000000000001
                        },
                        new
                        {
                            Id = 11L,
                            Description = "camiseta",
                            ImageUrl = "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg",
                            Name = "camiseta",
                            Price = 18.280000000000001
                        },
                        new
                        {
                            Id = 12L,
                            Description = "camiseta",
                            ImageUrl = "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg",
                            Name = "camiseta",
                            Price = 18.280000000000001
                        },
                        new
                        {
                            Id = 13L,
                            Description = "camiseta",
                            ImageUrl = "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg",
                            Name = "camiseta",
                            Price = 18.280000000000001
                        },
                        new
                        {
                            Id = 14L,
                            Description = "camiseta",
                            ImageUrl = "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg",
                            Name = "camiseta",
                            Price = 18.280000000000001
                        },
                        new
                        {
                            Id = 15L,
                            Description = "camiseta",
                            ImageUrl = "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg",
                            Name = "camiseta",
                            Price = 18.280000000000001
                        },
                        new
                        {
                            Id = 16L,
                            Description = "camiseta",
                            ImageUrl = "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg",
                            Name = "camiseta",
                            Price = 18.280000000000001
                        },
                        new
                        {
                            Id = 17L,
                            Description = "camiseta",
                            ImageUrl = "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg",
                            Name = "camiseta",
                            Price = 18.280000000000001
                        },
                        new
                        {
                            Id = 18L,
                            Description = "camiseta",
                            ImageUrl = "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg",
                            Name = "camiseta",
                            Price = 18.280000000000001
                        },
                        new
                        {
                            Id = 19L,
                            Description = "camiseta",
                            ImageUrl = "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg",
                            Name = "camiseta",
                            Price = 18.280000000000001
                        },
                        new
                        {
                            Id = 20L,
                            Description = "camiseta",
                            ImageUrl = "https://wallpaperplay.com/walls/full/2/c/2/58072.jpg",
                            Name = "camiseta",
                            Price = 18.280000000000001
                        });
                });

            modelBuilder.Entity("amazingShop.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasAlternateKey("Email");

                    b.HasAlternateKey("Name");

                    b.HasIndex("Name");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
