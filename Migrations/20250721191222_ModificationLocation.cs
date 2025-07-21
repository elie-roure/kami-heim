using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kami_heim.Migrations
{
    /// <inheritdoc />
    public partial class ModificationLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Biens_BienId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_Locataires_LocataireId",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.RenameIndex(
                name: "IX_Location_LocataireId",
                table: "Locations",
                newName: "IX_Locations_LocataireId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                columns: new[] { "BienId", "LocataireId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Biens_BienId",
                table: "Locations",
                column: "BienId",
                principalTable: "Biens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Locataires_LocataireId",
                table: "Locations",
                column: "LocataireId",
                principalTable: "Locataires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Biens_BienId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Locataires_LocataireId",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_LocataireId",
                table: "Location",
                newName: "IX_Location_LocataireId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                columns: new[] { "BienId", "LocataireId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Biens_BienId",
                table: "Location",
                column: "BienId",
                principalTable: "Biens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Locataires_LocataireId",
                table: "Location",
                column: "LocataireId",
                principalTable: "Locataires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
