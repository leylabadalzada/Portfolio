using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Data.Migrations
{
    /// <inheritdoc />
    public partial class time : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Updatedat",
                table: "Authors",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deletedat",
                table: "Authors",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Createdat",
                table: "Authors",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Authors",
                newName: "Updatedat");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Authors",
                newName: "Deletedat");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Authors",
                newName: "Createdat");
        }
    }
}
