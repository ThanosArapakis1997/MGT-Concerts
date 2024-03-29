﻿// <auto-generated />
using MGTConcerts.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MGTConcerts.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240115133649_Seed_MusicVenues_Table")]
    partial class Seed_MusicVenues_Table
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MGTConcerts.Models.MusicVenue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Music_Venues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Τεχνόπολη Δήμου Αθηναίων",
                            Name = "Τεχνοπολις"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Music Club",
                            Name = "Fuzz"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Συναυλιακός Χώρος Δήμου Πειραιά",
                            Name = "Λιπάσματα"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
