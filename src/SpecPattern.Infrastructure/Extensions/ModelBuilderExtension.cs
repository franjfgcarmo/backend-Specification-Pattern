using Microsoft.EntityFrameworkCore;
using SpecPattern.Domain.Entities;
using SpecPattern.Infrastructure.Data.Configurations;
using System;

namespace SpecPattern.Infrastructure.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void ConfigurationBuilder(this ModelBuilder modelBuilder)
        {
            modelBuilder.HasCollation("my_collation", locale: "en-u-ks-primary", provider: "icu", deterministic: false);
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
        }
        public static void SeedInitial(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Director>().HasData(
                new Director { Id = 1, Name = "Marc Webb" },
                new Director { Id = 2, Name = "Bill Condon" },
                new Director { Id = 3, Name = "Chris Renaud" },
                new Director { Id = 4, Name = "Jon Favreau" },
                new Director { Id = 5, Name = "M. Night Shyamalan" },
                new Director { Id = 6, Name = "Alex Kurtzman" }
                );

            modelBuilder.Entity<Movie>().HasData(
                new Movie 
                {
                    Id = 1, 
                    Name = "The Amazing Spider-Man", 
                    ReleaseDate = DateTime.Now.AddYears(-1), 
                    Genre = "Adventure", 
                    Rating = 7, 
                    MpaaRating = MpaaRating.PG13 ,
                    DirectorId =1
                },
                new Movie 
                { 
                    Id = 2,
                    Name = "Beauty and the Beast",
                    ReleaseDate = DateTime.Now.AddYears(-2),
                    Genre = "Family", 
                    Rating = 7.8, 
                    MpaaRating = MpaaRating.PG13,
                    DirectorId = 2
                },
                new Movie 
                { 
                    Id = 3,
                    Name = "The Secret Life of Pets", 
                    ReleaseDate = DateTime.Now.AddYears(-3), 
                    Genre = "Adventure",
                    Rating = 9, 
                    MpaaRating = MpaaRating.G,
                    DirectorId = 3
                },
                new Movie 
                {
                    Id = 4,
                    Name = "The Jungle Book",
                    ReleaseDate = DateTime.Now.AddYears(-1),
                    Genre = "Fantasy",
                    Rating = 7.9,
                    MpaaRating = MpaaRating.PG,
                    DirectorId = 4
                },
                new Movie
                { 
                    Id = 5,
                    Name = "Split",
                    ReleaseDate = DateTime.Now.AddYears(-5), 
                    Genre = "Horror",
                    Rating = 6.5,
                    MpaaRating = MpaaRating.PG13,
                    DirectorId = 5
                },
                new Movie 
                {
                    Id = 6,
                    Name = "The Mummy",
                    ReleaseDate = DateTime.Now, 
                    Genre = "Action",
                    Rating = 8.9,
                    MpaaRating = MpaaRating.R,
                    DirectorId = 6
                }
                );
        }
    }
}
