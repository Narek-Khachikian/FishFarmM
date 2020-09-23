﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FishFarmData.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InOuts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    LastModifiedByName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    InOutType = table.Column<int>(nullable: false),
                    BatchId = table.Column<long>(nullable: false),
                    Quantity = table.Column<long>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    AverageWight = table.Column<double>(nullable: false),
                    AverageLenght = table.Column<double>(nullable: false),
                    InId = table.Column<long>(nullable: true),
                    OutId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InOuts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MesurmentUnits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    LastModifiedByName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MesurmentUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    LastModifiedByName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    LastModifiedByName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TINCode = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tanks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    LastModifiedByName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Lenght = table.Column<double>(nullable: false),
                    Width = table.Column<double>(nullable: false),
                    Depth = table.Column<double>(nullable: false),
                    Volume = table.Column<double>(nullable: false),
                    SurfaceArea = table.Column<double>(nullable: false),
                    Shape = table.Column<int>(nullable: false),
                    SectionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tanks_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    LastModifiedByName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FishType = table.Column<string>(nullable: true),
                    Quantity = table.Column<long>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    AverageWeight = table.Column<double>(nullable: false),
                    AverageLenght = table.Column<double>(nullable: false),
                    AlocatedQuantity = table.Column<long>(nullable: false),
                    BatchSupplierId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Batches_Suppliers_BatchSupplierId",
                        column: x => x.BatchSupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    LastModifiedByName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    IsLegalEntity = table.Column<bool>(nullable: false),
                    SupplierId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    LastModifiedByName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<double>(nullable: false),
                    SupplierId = table.Column<long>(nullable: false),
                    MesuringUnitId = table.Column<long>(nullable: false),
                    MesurmentUnitId = table.Column<long>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryItems_MesurmentUnits_MesurmentUnitId",
                        column: x => x.MesurmentUnitId,
                        principalTable: "MesurmentUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryItems_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ins",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    LastModifiedByName = table.Column<string>(nullable: true),
                    InOutId = table.Column<long>(nullable: false),
                    InOutId1 = table.Column<long>(nullable: true),
                    TankId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ins_InOuts_InOutId1",
                        column: x => x.InOutId1,
                        principalTable: "InOuts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ins_Tanks_TankId",
                        column: x => x.TankId,
                        principalTable: "Tanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Outs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    LastModifiedByName = table.Column<string>(nullable: true),
                    IsTankEmpty = table.Column<bool>(nullable: false),
                    InOutId = table.Column<long>(nullable: false),
                    InOutId1 = table.Column<long>(nullable: true),
                    TankId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Outs_InOuts_InOutId1",
                        column: x => x.InOutId1,
                        principalTable: "InOuts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Outs_Tanks_TankId",
                        column: x => x.TankId,
                        principalTable: "Tanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyReports",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    LastModifiedByName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    DeadFish = table.Column<long>(nullable: false),
                    DeadFishWeight = table.Column<double>(nullable: false),
                    AverageWight = table.Column<double>(nullable: true),
                    FeedAmount = table.Column<double>(nullable: false),
                    FeedId = table.Column<long>(nullable: false),
                    TankId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyReports_InventoryItems_FeedId",
                        column: x => x.FeedId,
                        principalTable: "InventoryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyReports_Tanks_TankId",
                        column: x => x.TankId,
                        principalTable: "Tanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryIns",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: false),
                    LastModifiedByName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    InQuantity = table.Column<double>(nullable: false),
                    InventoryItemId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryIns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryIns_InventoryItems_InventoryItemId",
                        column: x => x.InventoryItemId,
                        principalTable: "InventoryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batches_BatchSupplierId",
                table: "Batches",
                column: "BatchSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_SupplierId",
                table: "Contact",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReports_FeedId",
                table: "DailyReports",
                column: "FeedId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReports_TankId",
                table: "DailyReports",
                column: "TankId");

            migrationBuilder.CreateIndex(
                name: "IX_Ins_InOutId1",
                table: "Ins",
                column: "InOutId1");

            migrationBuilder.CreateIndex(
                name: "IX_Ins_TankId",
                table: "Ins",
                column: "TankId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryIns_InventoryItemId",
                table: "InventoryIns",
                column: "InventoryItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_MesurmentUnitId",
                table: "InventoryItems",
                column: "MesurmentUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_SupplierId",
                table: "InventoryItems",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Outs_InOutId1",
                table: "Outs",
                column: "InOutId1");

            migrationBuilder.CreateIndex(
                name: "IX_Outs_TankId",
                table: "Outs",
                column: "TankId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_Name",
                table: "Sections",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_SectionId",
                table: "Tanks",
                column: "SectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Batches");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "DailyReports");

            migrationBuilder.DropTable(
                name: "Ins");

            migrationBuilder.DropTable(
                name: "InventoryIns");

            migrationBuilder.DropTable(
                name: "Outs");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "InOuts");

            migrationBuilder.DropTable(
                name: "Tanks");

            migrationBuilder.DropTable(
                name: "MesurmentUnits");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Sections");
        }
    }
}
