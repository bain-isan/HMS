using Microsoft.EntityFrameworkCore.Migrations;

namespace GuestManagementSystem.Migrations
{
    public partial class InitGuest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MemberCode = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guest_Email",
                table: "Guest",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guest_MemberCode",
                table: "Guest",
                column: "MemberCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guest_PhoneNumber",
                table: "Guest",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guest");
        }
    }
}
