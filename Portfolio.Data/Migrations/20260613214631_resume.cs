using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Data.Migrations
{
    /// <inheritdoc />
    public partial class resume : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "ID",
                keyValue: new Guid("3912d27d-08e7-41aa-a7db-c0296f92212d"));

            migrationBuilder.CreateTable(
                name: "Resumes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Filename = table.Column<string>(type: "text", nullable: false),
                    IsLast = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "BirthDate", "CreatedAt", "DeletedAt", "Description", "FirstName", "ImageName", "Info", "LastName", "Location", "UpdatedAt", "isDeleted", "isFreelanceAvailable" },
                values: new object[] { new Guid("eb0a348b-b3ac-46aa-9931-623a6b70c5fc"), new DateOnly(2000, 4, 2), new DateTime(2026, 6, 14, 1, 46, 28, 709, DateTimeKind.Utc).AddTicks(6223), null, "Sample Developer Description", "FirstName", "default.png", "Sample Developer Information", "Lastname", "Location", null, false, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resumes");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "ID",
                keyValue: new Guid("eb0a348b-b3ac-46aa-9931-623a6b70c5fc"));

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "BirthDate", "CreatedAt", "DeletedAt", "Description", "FirstName", "ImageName", "Info", "LastName", "Location", "UpdatedAt", "isDeleted", "isFreelanceAvailable" },
                values: new object[] { new Guid("3912d27d-08e7-41aa-a7db-c0296f92212d"), new DateOnly(2000, 4, 2), new DateTime(2026, 6, 13, 22, 44, 1, 513, DateTimeKind.Utc).AddTicks(3563), null, "Sample Developer Description", "FirstName", "default.png", "Sample Developer Information", "Lastname", "Location", null, false, true });
        }
    }
}
