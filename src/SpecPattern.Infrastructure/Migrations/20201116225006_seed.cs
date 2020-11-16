using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpecPattern.Infrastructure.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "id", "genre", "mpaa_rating", "name", "rating", "release_date" },
                values: new object[,]
                {
                    { 1, "Adventure", 3, "The Amazing Spider-Man", 7.0, new DateTime(2019, 11, 16, 23, 50, 5, 310, DateTimeKind.Local).AddTicks(6680) },
                    { 2, "Family", 3, "Beauty and the Beast", 7.7999999999999998, new DateTime(2018, 11, 16, 23, 50, 5, 316, DateTimeKind.Local).AddTicks(2547) },
                    { 3, "Adventure", 1, "The Secret Life of Pets", 9.0, new DateTime(2017, 11, 16, 23, 50, 5, 316, DateTimeKind.Local).AddTicks(2664) },
                    { 4, "Fantasy", 2, "The Jungle Book", 7.9000000000000004, new DateTime(2019, 11, 16, 23, 50, 5, 316, DateTimeKind.Local).AddTicks(2687) },
                    { 5, "Horror", 3, "Split", 6.5, new DateTime(2015, 11, 16, 23, 50, 5, 316, DateTimeKind.Local).AddTicks(2696) },
                    { 6, "Action", 4, "The Mummy", 8.9000000000000004, new DateTime(2020, 11, 16, 23, 50, 5, 316, DateTimeKind.Local).AddTicks(2705) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "id",
                keyValue: 6);
        }
    }
}
