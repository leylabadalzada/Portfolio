using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Data.Migrations
{
    /// <inheritdoc />
    public partial class email : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "ID",
                keyValue: new Guid("f8ffb0ef-57da-4cb8-8558-160fe3aebc61"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Authors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "BirthDate", "CreatedAt", "Description", "Email", "FirstName", "ImageName", "Info", "LastName", "Location", "UpdatedAt", "isFreelanceAvailable" },
                values: new object[] { new Guid("3aaed6fb-8d16-40fe-a479-725822fd0e69"), new DateOnly(1, 1, 1), new DateTime(2026, 6, 17, 16, 0, 17, 902, DateTimeKind.Utc).AddTicks(4845), "Sample Developer Description", "email@sample.domain", "FirstName", "default.png", "Sample Developer Information", "Lastname", "Location", null, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "ID",
                keyValue: new Guid("3aaed6fb-8d16-40fe-a479-725822fd0e69"));

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Authors");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "BirthDate", "CreatedAt", "Description", "FirstName", "ImageName", "Info", "LastName", "Location", "UpdatedAt", "isFreelanceAvailable" },
                values: new object[] { new Guid("f8ffb0ef-57da-4cb8-8558-160fe3aebc61"), new DateOnly(2000, 4, 2), new DateTime(2026, 6, 17, 15, 12, 56, 454, DateTimeKind.Utc).AddTicks(8986), "Sample Developer Description", "FirstName", "default.png", "Sample Developer Information", "Lastname", "Location", null, true });
        }
    }
}
