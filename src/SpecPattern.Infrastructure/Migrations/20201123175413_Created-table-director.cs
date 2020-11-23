using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SpecPattern.Infrastructure.Migrations
{
    public partial class Createdtabledirector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "director_id",
                table: "movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "director",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_director", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "director",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Marc Webb" },
                    { 2, "Bill Condon" },
                    { 3, "Chris Renaud" },
                    { 4, "Jon Favreau" },
                    { 5, "M. Night Shyamalan" },
                    { 6, "Alex Kurtzman" }
                });

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "director_id", "release_date" },
                values: new object[] { 1, new DateTime(2019, 11, 23, 18, 54, 12, 435, DateTimeKind.Local).AddTicks(967) });

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "director_id", "release_date" },
                values: new object[] { 2, new DateTime(2018, 11, 23, 18, 54, 12, 443, DateTimeKind.Local).AddTicks(9464) });

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "director_id", "release_date" },
                values: new object[] { 3, new DateTime(2017, 11, 23, 18, 54, 12, 443, DateTimeKind.Local).AddTicks(9572) });

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "director_id", "release_date" },
                values: new object[] { 4, new DateTime(2019, 11, 23, 18, 54, 12, 443, DateTimeKind.Local).AddTicks(9591) });

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "director_id", "release_date" },
                values: new object[] { 5, new DateTime(2015, 11, 23, 18, 54, 12, 443, DateTimeKind.Local).AddTicks(9604) });

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "director_id", "release_date" },
                values: new object[] { 6, new DateTime(2020, 11, 23, 18, 54, 12, 443, DateTimeKind.Local).AddTicks(9614) });

            migrationBuilder.CreateIndex(
                name: "ix_movies_director_id",
                table: "movies",
                column: "director_id");

            migrationBuilder.AddForeignKey(
                name: "fk_movies_director_director_id",
                table: "movies",
                column: "director_id",
                principalTable: "director",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_movies_director_director_id",
                table: "movies");

            migrationBuilder.DropTable(
                name: "director");

            migrationBuilder.DropIndex(
                name: "ix_movies_director_id",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "director_id",
                table: "movies");

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "id",
                keyValue: 1,
                column: "release_date",
                value: new DateTime(2019, 11, 16, 23, 50, 5, 310, DateTimeKind.Local).AddTicks(6680));

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "id",
                keyValue: 2,
                column: "release_date",
                value: new DateTime(2018, 11, 16, 23, 50, 5, 316, DateTimeKind.Local).AddTicks(2547));

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "id",
                keyValue: 3,
                column: "release_date",
                value: new DateTime(2017, 11, 16, 23, 50, 5, 316, DateTimeKind.Local).AddTicks(2664));

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "id",
                keyValue: 4,
                column: "release_date",
                value: new DateTime(2019, 11, 16, 23, 50, 5, 316, DateTimeKind.Local).AddTicks(2687));

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "id",
                keyValue: 5,
                column: "release_date",
                value: new DateTime(2015, 11, 16, 23, 50, 5, 316, DateTimeKind.Local).AddTicks(2696));

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "id",
                keyValue: 6,
                column: "release_date",
                value: new DateTime(2020, 11, 16, 23, 50, 5, 316, DateTimeKind.Local).AddTicks(2705));
        }
    }
}
