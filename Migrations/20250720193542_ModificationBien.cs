using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kami_heim.Migrations
{
    /// <inheritdoc />
    public partial class ModificationBien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodePostal",
                table: "Biens",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ville",
                table: "Biens",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodePostal",
                table: "Biens");

            migrationBuilder.DropColumn(
                name: "Ville",
                table: "Biens");
        }
    }
}
