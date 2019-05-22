using Microsoft.EntityFrameworkCore.Migrations;

namespace Coffee.Data.Migrations
{
    public partial class aangepaste_organizer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Organizor",
                table: "Event");

            migrationBuilder.AddColumn<int>(
                name: "OrganizorUserId",
                table: "Event",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_OrganizorUserId",
                table: "Event",
                column: "OrganizorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_User_OrganizorUserId",
                table: "Event",
                column: "OrganizorUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_User_OrganizorUserId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_OrganizorUserId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "OrganizorUserId",
                table: "Event");

            migrationBuilder.AddColumn<int>(
                name: "Organizor",
                table: "Event",
                nullable: false,
                defaultValue: 0);
        }
    }
}
