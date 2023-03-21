using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddMigrationVillaAndVillaBookingToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaBookings",
                columns: table => new
                {
                    BookingNum = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaBookings", x => x.BookingNum);
                });

            migrationBuilder.CreateTable(
                name: "Villas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Superficie = table.Column<int>(type: "int", nullable: false),
                    NbRoom = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Created_date", "Description", "ImageUrl", "Name", "NbRoom", "Rate", "Superficie", "Updated_date" },
                values: new object[,]
                {
                    { 12340, new DateTime(2023, 3, 21, 10, 8, 10, 746, DateTimeKind.Local).AddTicks(5109), "Description villa Monastir", "https://cdn.pixabay.com/photo/2017/04/10/22/28/residence-2219972_960_720.jpg", "Villa Monastir", 3, 10.0, 800, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12344, new DateTime(2023, 3, 21, 10, 8, 10, 746, DateTimeKind.Local).AddTicks(5105), "Description villa Tunis", "https://cdn.pixabay.com/photo/2018/03/18/15/26/villa-3237114_960_720.jpg", "Villa Tunis", 3, 6.2000000000000002, 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12345, new DateTime(2023, 3, 21, 10, 8, 10, 746, DateTimeKind.Local).AddTicks(4953), "Description villa Sousse", "https://cdn.pixabay.com/photo/2017/09/17/18/15/lost-places-2759275_960_720.jpg", "Villa Sousse", 3, 5.2999999999999998, 300, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaBookings");

            migrationBuilder.DropTable(
                name: "Villas");
        }
    }
}
