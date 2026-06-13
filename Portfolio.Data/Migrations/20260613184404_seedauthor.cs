using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedauthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Authors");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "BirthDate", "CreatedAt", "DeletedAt", "Description", "FirstName", "ImageName", "Info", "LastName", "Location", "UpdatedAt", "isDeleted", "isFreelanceAvailable" },
                values: new object[] { new Guid("3912d27d-08e7-41aa-a7db-c0296f92212d"), new DateOnly(2000, 4, 2), new DateTime(2026, 6, 13, 22, 44, 1, 513, DateTimeKind.Utc).AddTicks(3563), null, "Sample Developer Description", "FirstName", "default.png", "Sample Developer Information", "Lastname", "Location", null, false, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "ID",
                keyValue: new Guid("3912d27d-08e7-41aa-a7db-c0296f92212d"));

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Authors",
                type: "text",
                nullable: true);
        }
    }
}
