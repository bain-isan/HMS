using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationManagementSystem.Migrations
{
    public partial class InitReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Guest",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "10000, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        MemberCode = table.Column<int>(type: "int", nullable: false),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Guest", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Room",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    NumberOfChild = table.Column<int>(type: "int", nullable: false),
                    NumberOfAdults = table.Column<int>(type: "int", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfNight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Guest_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Guest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Room_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Reservations_GuestId",
            //    table: "Reservations",
            //    column: "GuestId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Reservations_RoomId",
            //    table: "Reservations",
            //    column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            //migrationBuilder.DropTable(
            //    name: "Guest");

            //migrationBuilder.DropTable(
            //    name: "Room");
        }
    }
}
