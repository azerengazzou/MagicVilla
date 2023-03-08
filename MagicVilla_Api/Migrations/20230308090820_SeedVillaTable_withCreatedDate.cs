using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillaTable_withCreatedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Created_date", "Description", "ImageUrl", "Name", "NbRoom", "Rate", "Superficie", "Updated_date" },
                values: new object[,]
                {
                    { 12340, new DateTime(2023, 3, 8, 10, 8, 20, 226, DateTimeKind.Local).AddTicks(7425), "Description villa Monastir", "https://cdn.pixabay.com/photo/2017/04/10/22/28/residence-2219972_960_720.jpg", "Villa Monastir", 3, 10.0, 800, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12344, new DateTime(2023, 3, 8, 10, 8, 20, 226, DateTimeKind.Local).AddTicks(7422), "Description villa Tunis", "https://cdn.pixabay.com/photo/2018/03/18/15/26/villa-3237114_960_720.jpg", "Villa Tunis", 3, 6.2000000000000002, 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12345, new DateTime(2023, 3, 8, 10, 8, 20, 226, DateTimeKind.Local).AddTicks(7402), "Description villa Sousse", "https://cdn.pixabay.com/photo/2017/09/17/18/15/lost-places-2759275_960_720.jpg", "Villa Sousse", 3, 5.2999999999999998, 300, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 12340);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 12344);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 12345);
        }
    }
}
