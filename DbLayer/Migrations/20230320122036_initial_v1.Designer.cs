﻿// <auto-generated />
using System;
using DbLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbLayer.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230320122036_initial_v1")]
    partial class initial_v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DbLayer.Models.Clouds", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("All")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Clouds");
                });

            modelBuilder.Entity("DbLayer.Models.Coord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<double>("Lat")
                        .HasColumnType("float");

                    b.Property<double>("Lon")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Coord");
                });

            modelBuilder.Entity("DbLayer.Models.Main", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("Humidity")
                        .HasColumnType("bigint");

                    b.Property<double>("Percepita")
                        .HasColumnType("float");

                    b.Property<long>("Pressure")
                        .HasColumnType("bigint");

                    b.Property<double>("TempMax")
                        .HasColumnType("float");

                    b.Property<double>("TempMin")
                        .HasColumnType("float");

                    b.Property<double>("Temperature")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Main");
                });

            modelBuilder.Entity("DbLayer.Models.Sys", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Message")
                        .HasColumnType("float");

                    b.Property<long>("Sunrise")
                        .HasColumnType("bigint");

                    b.Property<long>("Sunset")
                        .HasColumnType("bigint");

                    b.Property<long>("Type")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Sys");
                });

            modelBuilder.Entity("DbLayer.Models.Weather", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Visibility")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("WeatherDataId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("WeatherDataId");

                    b.ToTable("Weather");
                });

            modelBuilder.Entity("DbLayer.Models.WeatherData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Base")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CloudsId")
                        .HasColumnType("bigint");

                    b.Property<long>("Cod")
                        .HasColumnType("bigint");

                    b.Property<long>("CoordId")
                        .HasColumnType("bigint");

                    b.Property<long>("Dt")
                        .HasColumnType("bigint");

                    b.Property<long>("MainId")
                        .HasColumnType("bigint");

                    b.Property<long>("SysId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Visibility")
                        .HasColumnType("bigint");

                    b.Property<long>("WindId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CloudsId");

                    b.HasIndex("CoordId");

                    b.HasIndex("MainId");

                    b.HasIndex("SysId");

                    b.HasIndex("WindId");

                    b.ToTable("WeatherData");
                });

            modelBuilder.Entity("DbLayer.Models.Wind", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("Deg")
                        .HasColumnType("bigint");

                    b.Property<double>("Speed")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Wind");
                });

            modelBuilder.Entity("DbLayer.Models.Weather", b =>
                {
                    b.HasOne("DbLayer.Models.WeatherData", null)
                        .WithMany("Weather")
                        .HasForeignKey("WeatherDataId");
                });

            modelBuilder.Entity("DbLayer.Models.WeatherData", b =>
                {
                    b.HasOne("DbLayer.Models.Clouds", "Clouds")
                        .WithMany()
                        .HasForeignKey("CloudsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbLayer.Models.Coord", "Coord")
                        .WithMany()
                        .HasForeignKey("CoordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbLayer.Models.Main", "Main")
                        .WithMany()
                        .HasForeignKey("MainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbLayer.Models.Sys", "Sys")
                        .WithMany()
                        .HasForeignKey("SysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbLayer.Models.Wind", "Wind")
                        .WithMany()
                        .HasForeignKey("WindId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clouds");

                    b.Navigation("Coord");

                    b.Navigation("Main");

                    b.Navigation("Sys");

                    b.Navigation("Wind");
                });

            modelBuilder.Entity("DbLayer.Models.WeatherData", b =>
                {
                    b.Navigation("Weather");
                });
#pragma warning restore 612, 618
        }
    }
}
