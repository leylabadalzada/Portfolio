using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Data.Migrations
{
    /// <inheritdoc />
    public partial class specilaityseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "34015e97-b5b7-424c-89fa-dde09d9c2cf1", "066cde51-d208-4f7f-8c98-087a20948672" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34015e97-b5b7-424c-89fa-dde09d9c2cf1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "066cde51-d208-4f7f-8c98-087a20948672");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "16cc1616-c932-4d2a-b678-0bf7a078cc58", null, "Author", "AUTHOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedAt", "Description", "Discriminator", "Email", "EmailConfirmed", "FirstName", "ImageName", "Info", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName", "isFreelanceAvailable" },
                values: new object[] { "68eaa0bb-050e-4f2c-91bc-e73da839a3e7", 3, new DateOnly(1, 1, 1), "af44cc07-82d3-4f6a-9ded-c03e2b38e72e", new DateTime(2026, 7, 5, 0, 30, 50, 647, DateTimeKind.Utc).AddTicks(7623), "Sample Developer Description", "Author", "email@sample.domain", true, "FirstName", "default.png", "Sample Developer Information", "Lastname", "Location", true, null, "EMAIL@SAMLE.DOMAIN", "AUTHOR123", "AQAAAAIAAYagAAAAEDMZyrzDzMsFFjNOPuTfV9w2l+9TgEpQt4s4NDadFxZIJ4+m4P/P7LdG8j5nc3oQgA==", "+994123456789", true, "82094a2d-8ff1-46c6-9804-3ed8a9dc243e", false, null, "author123", true });

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "ID", "CreatedAt", "IsMain", "Name", "UpdatedAt" },
                values: new object[] { new Guid("c803ad47-b3dd-4f14-9d15-08b5d3211d4a"), new DateTime(2026, 7, 4, 20, 30, 50, 697, DateTimeKind.Utc).AddTicks(2718), true, "Some speciality", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "16cc1616-c932-4d2a-b678-0bf7a078cc58", "68eaa0bb-050e-4f2c-91bc-e73da839a3e7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "16cc1616-c932-4d2a-b678-0bf7a078cc58", "68eaa0bb-050e-4f2c-91bc-e73da839a3e7" });

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "ID",
                keyValue: new Guid("c803ad47-b3dd-4f14-9d15-08b5d3211d4a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16cc1616-c932-4d2a-b678-0bf7a078cc58");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "68eaa0bb-050e-4f2c-91bc-e73da839a3e7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "34015e97-b5b7-424c-89fa-dde09d9c2cf1", null, "Author", "AUTHOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedAt", "Description", "Discriminator", "Email", "EmailConfirmed", "FirstName", "ImageName", "Info", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName", "isFreelanceAvailable" },
                values: new object[] { "066cde51-d208-4f7f-8c98-087a20948672", 3, new DateOnly(1, 1, 1), "90e37a90-0216-4db1-a777-7251e1b4a229", new DateTime(2026, 7, 5, 0, 24, 7, 301, DateTimeKind.Utc).AddTicks(6258), "Sample Developer Description", "Author", "email@sample.domain", true, "FirstName", "default.png", "Sample Developer Information", "Lastname", "Location", true, null, "EMAIL@SAMLE.DOMAIN", "AUTHOR123", "AQAAAAIAAYagAAAAEHfbLbP0v7P/Ur8ePBOjbwmwtoLhW1UQAOhZGwqZyZsdx9nVvAbwm+4dIuKipzALAQ==", "+994123456789", true, "a13f14b1-43b5-465e-911c-9b9298fb4d5c", false, null, "author123", true });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "34015e97-b5b7-424c-89fa-dde09d9c2cf1", "066cde51-d208-4f7f-8c98-087a20948672" });
        }
    }
}
