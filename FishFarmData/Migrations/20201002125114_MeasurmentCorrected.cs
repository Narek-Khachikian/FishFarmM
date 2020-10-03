using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FishFarmData.Migrations
{
    public partial class MeasurmentCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_MesurmentUnits_MesurmentUnitId",
                table: "InventoryItems");

            migrationBuilder.DropTable(
                name: "MesurmentUnits");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_MesurmentUnitId",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "MesurmentUnitId",
                table: "InventoryItems");

            migrationBuilder.AddColumn<long>(
                name: "MeasurmentUnitId",
                table: "InventoryItems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MeasurmentUnits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    LastModifiedByName = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false, defaultValue: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurmentUnits", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_MeasurmentUnitId",
                table: "InventoryItems",
                column: "MeasurmentUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_MeasurmentUnits_MeasurmentUnitId",
                table: "InventoryItems",
                column: "MeasurmentUnitId",
                principalTable: "MeasurmentUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_MeasurmentUnits_MeasurmentUnitId",
                table: "InventoryItems");

            migrationBuilder.DropTable(
                name: "MeasurmentUnits");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_MeasurmentUnitId",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "MeasurmentUnitId",
                table: "InventoryItems");

            migrationBuilder.AddColumn<long>(
                name: "MesurmentUnitId",
                table: "InventoryItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MesurmentUnits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MesurmentUnits", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_MesurmentUnitId",
                table: "InventoryItems",
                column: "MesurmentUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_MesurmentUnits_MesurmentUnitId",
                table: "InventoryItems",
                column: "MesurmentUnitId",
                principalTable: "MesurmentUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
