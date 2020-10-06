using Microsoft.EntityFrameworkCore.Migrations;

namespace FishFarmData.Migrations
{
    public partial class MeasurmentUnitsModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_MeasurmentUnits_MeasurmentUnitId",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "MesuringUnitId",
                table: "InventoryItems");

            migrationBuilder.AlterColumn<long>(
                name: "MeasurmentUnitId",
                table: "InventoryItems",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_MeasurmentUnits_MeasurmentUnitId",
                table: "InventoryItems",
                column: "MeasurmentUnitId",
                principalTable: "MeasurmentUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_MeasurmentUnits_MeasurmentUnitId",
                table: "InventoryItems");

            migrationBuilder.AlterColumn<long>(
                name: "MeasurmentUnitId",
                table: "InventoryItems",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "MesuringUnitId",
                table: "InventoryItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_MeasurmentUnits_MeasurmentUnitId",
                table: "InventoryItems",
                column: "MeasurmentUnitId",
                principalTable: "MeasurmentUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
