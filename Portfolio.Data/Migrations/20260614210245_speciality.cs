using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Data.Migrations
{
    /// <inheritdoc />
    public partial class speciality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "ID",
                keyValue: new Guid("0585141e-87f2-4832-b591-56a7880a463a"));

            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsMain = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "BirthDate", "CreatedAt", "Description", "FirstName", "ImageName", "Info", "LastName", "Location", "UpdatedAt", "isFreelanceAvailable" },
                values: new object[] { new Guid("af7f4bbb-c6dc-4545-afef-8749a8ef29f3"), new DateOnly(2000, 4, 2), new DateTime(2026, 6, 15, 1, 2, 45, 91, DateTimeKind.Utc).AddTicks(3049), "Sample Developer Description", "FirstName", "default.png", "Sample Developer Information", "Lastname", "Location", null, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Specialities");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "ID",
                keyValue: new Guid("af7f4bbb-c6dc-4545-afef-8749a8ef29f3"));

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "BirthDate", "CreatedAt", "Description", "FirstName", "ImageName", "Info", "LastName", "Location", "UpdatedAt", "isFreelanceAvailable" },
                values: new object[] { new Guid("0585141e-87f2-4832-b591-56a7880a463a"), new DateOnly(2000, 4, 2), new DateTime(2026, 6, 15, 0, 28, 12, 559, DateTimeKind.Utc).AddTicks(7480), "Sample Developer Description", "FirstName", "default.png", "Sample Developer Information", "Lastname", "Location", null, true });
        }
    }
}
