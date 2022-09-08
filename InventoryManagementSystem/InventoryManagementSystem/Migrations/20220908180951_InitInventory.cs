using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementSystem.Migrations
{
    public partial class InitInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Room",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "100, 1"),
            //        RoomNumber = table.Column<int>(type: "int", nullable: false),
            //        RoomFloor = table.Column<int>(type: "int", nullable: false),
            //        RoomType = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        MaxPersonAllowed = table.Column<int>(type: "int", nullable: false),
            //        Price = table.Column<double>(type: "float", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Room", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryCode = table.Column<int>(type: "int", nullable: false),
                    InventoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_InventoryCode",
                table: "Inventory",
                column: "InventoryCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_RoomId",
                table: "Inventory",
                column: "RoomId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Room_RoomNumber",
            //    table: "Room",
            //    column: "RoomNumber",
            //    unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            //migrationBuilder.DropTable(
            //    name: "Room");
        }
    }
}
