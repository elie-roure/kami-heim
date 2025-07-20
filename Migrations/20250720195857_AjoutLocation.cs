using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kami_heim.Migrations
{
    /// <inheritdoc />
    public partial class AjoutLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    BienId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocataireId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateFin = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => new { x.BienId, x.LocataireId });
                    table.ForeignKey(
                        name: "FK_Location_Biens_BienId",
                        column: x => x.BienId,
                        principalTable: "Biens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Location_Locataires_LocataireId",
                        column: x => x.LocataireId,
                        principalTable: "Locataires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Location_LocataireId",
                table: "Location",
                column: "LocataireId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
