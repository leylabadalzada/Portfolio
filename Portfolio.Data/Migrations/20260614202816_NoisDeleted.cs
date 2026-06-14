using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Data.Migrations
{
    /// <inheritdoc />
    public partial class NoisDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "ID",
                keyValue: new Guid("eb0a348b-b3ac-46aa-9931-623a6b70c5fc"));

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Authors");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "BirthDate", "CreatedAt", "Description", "FirstName", "ImageName", "Info", "LastName", "Location", "UpdatedAt", "isFreelanceAvailable" },
                values: new object[] { new Guid("0585141e-87f2-4832-b591-56a7880a463a"), new DateOnly(2000, 4, 2), new DateTime(2026, 6, 15, 0, 28, 12, 559, DateTimeKind.Utc).AddTicks(7480), "Sample Developer Description", "FirstName", "default.png", "Sample Developer Information", "Lastname", "Location", null, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "ID",
                keyValue: new Guid("0585141e-87f2-4832-b591-56a7880a463a"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Resumes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Resumes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Authors",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Authors",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "BirthDate", "CreatedAt", "DeletedAt", "Description", "FirstName", "ImageName", "Info", "LastName", "Location", "UpdatedAt", "isDeleted", "isFreelanceAvailable" },
                values: new object[] { new Guid("eb0a348b-b3ac-46aa-9931-623a6b70c5fc"), new DateOnly(2000, 4, 2), new DateTime(2026, 6, 14, 1, 46, 28, 709, DateTimeKind.Utc).AddTicks(6223), null, "Sample Developer Description", "FirstName", "default.png", "Sample Developer Information", "Lastname", "Location", null, false, true });
        }
    }
}
