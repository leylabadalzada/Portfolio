using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Data.Migrations
{
    /// <inheritdoc />
    public partial class language : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "ID",
                keyValue: new Guid("3aaed6fb-8d16-40fe-a479-725822fd0e69"));

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "BirthDate", "CreatedAt", "Description", "Email", "FirstName", "ImageName", "Info", "LastName", "Location", "UpdatedAt", "isFreelanceAvailable" },
                values: new object[] { new Guid("3a2dacdb-6a8c-4064-8d26-e3cf7deb6783"), new DateOnly(1, 1, 1), new DateTime(2026, 6, 24, 14, 38, 36, 879, DateTimeKind.Utc).AddTicks(6634), "Sample Developer Description", "email@sample.domain", "FirstName", "default.png", "Sample Developer Information", "Lastname", "Location", null, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "ID",
                keyValue: new Guid("3a2dacdb-6a8c-4064-8d26-e3cf7deb6783"));

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "BirthDate", "CreatedAt", "Description", "Email", "FirstName", "ImageName", "Info", "LastName", "Location", "UpdatedAt", "isFreelanceAvailable" },
                values: new object[] { new Guid("3aaed6fb-8d16-40fe-a479-725822fd0e69"), new DateOnly(1, 1, 1), new DateTime(2026, 6, 17, 16, 0, 17, 902, DateTimeKind.Utc).AddTicks(4845), "Sample Developer Description", "email@sample.domain", "FirstName", "default.png", "Sample Developer Information", "Lastname", "Location", null, true });
        }
    }
}
