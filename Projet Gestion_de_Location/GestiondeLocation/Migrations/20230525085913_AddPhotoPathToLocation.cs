using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestiondeLocation.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoPathToLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Voitures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Voitures");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Locations");
        }
    }
}
