﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SpecPattern.Infrastructure.Data;

namespace SpecPattern.Infrastructure.Migrations
{
    [DbContext(typeof(DbSpecPattern))]
    [Migration("20201116225006_seed")]
    partial class seed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SpecPattern.Domain.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnName("genre")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<int>("MpaaRating")
                        .HasColumnName("mpaa_rating")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<double>("Rating")
                        .HasColumnName("rating")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnName("release_date")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id")
                        .HasName("pk_movies");

                    b.ToTable("movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Genre = "Adventure",
                            MpaaRating = 3,
                            Name = "The Amazing Spider-Man",
                            Rating = 7.0,
                            ReleaseDate = new DateTime(2019, 11, 16, 23, 50, 5, 310, DateTimeKind.Local).AddTicks(6680)
                        },
                        new
                        {
                            Id = 2,
                            Genre = "Family",
                            MpaaRating = 3,
                            Name = "Beauty and the Beast",
                            Rating = 7.7999999999999998,
                            ReleaseDate = new DateTime(2018, 11, 16, 23, 50, 5, 316, DateTimeKind.Local).AddTicks(2547)
                        },
                        new
                        {
                            Id = 3,
                            Genre = "Adventure",
                            MpaaRating = 1,
                            Name = "The Secret Life of Pets",
                            Rating = 9.0,
                            ReleaseDate = new DateTime(2017, 11, 16, 23, 50, 5, 316, DateTimeKind.Local).AddTicks(2664)
                        },
                        new
                        {
                            Id = 4,
                            Genre = "Fantasy",
                            MpaaRating = 2,
                            Name = "The Jungle Book",
                            Rating = 7.9000000000000004,
                            ReleaseDate = new DateTime(2019, 11, 16, 23, 50, 5, 316, DateTimeKind.Local).AddTicks(2687)
                        },
                        new
                        {
                            Id = 5,
                            Genre = "Horror",
                            MpaaRating = 3,
                            Name = "Split",
                            Rating = 6.5,
                            ReleaseDate = new DateTime(2015, 11, 16, 23, 50, 5, 316, DateTimeKind.Local).AddTicks(2696)
                        },
                        new
                        {
                            Id = 6,
                            Genre = "Action",
                            MpaaRating = 4,
                            Name = "The Mummy",
                            Rating = 8.9000000000000004,
                            ReleaseDate = new DateTime(2020, 11, 16, 23, 50, 5, 316, DateTimeKind.Local).AddTicks(2705)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
