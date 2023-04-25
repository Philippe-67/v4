using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace v4.Data.Migrations
{
    public partial class migrationcorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reparations_Voitures_VoitureId",
                table: "Reparations");

            migrationBuilder.DropTable(
                name: "Interventions");

            migrationBuilder.DropIndex(
                name: "IX_Reparations_VoitureId",
                table: "Reparations");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAchat",
                table: "Voitures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Finition",
                table: "Voitures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PrixVente",
                table: "Voitures",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatededisponibiliteALaVente",
                table: "Reparations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAchat",
                table: "Voitures");

            migrationBuilder.DropColumn(
                name: "Finition",
                table: "Voitures");

            migrationBuilder.DropColumn(
                name: "PrixVente",
                table: "Voitures");

            migrationBuilder.DropColumn(
                name: "DatededisponibiliteALaVente",
                table: "Reparations");

            migrationBuilder.CreateTable(
                name: "Interventions",
                columns: table => new
                {
                    InterventionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReparationId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interventions", x => x.InterventionID);
                    table.ForeignKey(
                        name: "FK_Interventions_Reparations_ReparationId",
                        column: x => x.ReparationId,
                        principalTable: "Reparations",
                        principalColumn: "ReparationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reparations_VoitureId",
                table: "Reparations",
                column: "VoitureId");

            migrationBuilder.CreateIndex(
                name: "IX_Interventions_ReparationId",
                table: "Interventions",
                column: "ReparationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reparations_Voitures_VoitureId",
                table: "Reparations",
                column: "VoitureId",
                principalTable: "Voitures",
                principalColumn: "VoituresId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
