using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Data.Migrations
{
    /// <inheritdoc />
    public partial class socialmedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "ID",
                keyValue: new Guid("af7f4bbb-c6dc-4545-afef-8749a8ef29f3"));

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    SocialMediaName = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "BirthDate", "CreatedAt", "Description", "FirstName", "ImageName", "Info", "LastName", "Location", "UpdatedAt", "isFreelanceAvailable" },
                values: new object[] { new Guid("f8ffb0ef-57da-4cb8-8558-160fe3aebc61"), new DateOnly(2000, 4, 2), new DateTime(2026, 6, 17, 15, 12, 56, 454, DateTimeKind.Utc).AddTicks(8986), "Sample Developer Description", "FirstName", "default.png", "Sample Developer Information", "Lastname", "Location", null, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "ID",
                keyValue: new Guid("f8ffb0ef-57da-4cb8-8558-160fe3aebc61"));

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "BirthDate", "CreatedAt", "Description", "FirstName", "ImageName", "Info", "LastName", "Location", "UpdatedAt", "isFreelanceAvailable" },
                values: new object[] { new Guid("af7f4bbb-c6dc-4545-afef-8749a8ef29f3"), new DateOnly(2000, 4, 2), new DateTime(2026, 6, 15, 1, 2, 45, 91, DateTimeKind.Utc).AddTicks(3049), "Sample Developer Description", "FirstName", "default.png", "Sample Developer Information", "Lastname", "Location", null, true });
        }
    }
}
