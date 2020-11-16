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
    [Migration("20201116221812_initial")]
    partial class initial
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
                });
#pragma warning restore 612, 618
        }
    }
}
