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
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
        }
        public static void SeedInitial(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie 
                {
                    Id = 1, 
                    Name = "The Amazing Spider-Man", 
                    ReleaseDate = DateTime.Now.AddYears(-1), 
                    Genre = "Adventure", 
                    Rating = 7, 
                    MpaaRating = MpaaRating.PG13 
                },
                new Movie 
                { 
                    Id = 2,
                    Name = "Beauty and the Beast",
                    ReleaseDate = DateTime.Now.AddYears(-2),
                    Genre = "Family", 
                    Rating = 7.8, 
                    MpaaRating = MpaaRating.PG13 },
                new Movie 
                { 
                    Id = 3,
                    Name = "The Secret Life of Pets", 
                    ReleaseDate = DateTime.Now.AddYears(-3), 
                    Genre = "Adventure",
                    Rating = 9, 
                    MpaaRating = MpaaRating.G },
                new Movie 
                {
                    Id = 4,
                    Name = "The Jungle Book",
                    ReleaseDate = DateTime.Now.AddYears(-1),
                    Genre = "Fantasy",
                    Rating = 7.9,
                    MpaaRating = MpaaRating.PG },
                new Movie
                { 
                    Id = 5,
                    Name = "Split",
                    ReleaseDate = DateTime.Now.AddYears(-5), 
                    Genre = "Horror",
                    Rating = 6.5,
                    MpaaRating = MpaaRating.PG13 },
                new Movie 
                {
                    Id = 5,
                    Name = "The Mummy",
                    ReleaseDate = DateTime.Now, 
                    Genre = "Action",
                    Rating = 8.9,
                    MpaaRating = MpaaRating.R }
                );
        }
    }
}
