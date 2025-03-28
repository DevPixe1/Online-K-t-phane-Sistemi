using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineKutuphane.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddYearToBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublishedYear",
                table: "Books",
                newName: "Year");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Books",
                newName: "PublishedYear");
        }
    }
}
