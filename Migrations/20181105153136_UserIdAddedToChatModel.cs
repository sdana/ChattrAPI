using Microsoft.EntityFrameworkCore.Migrations;

namespace ChattrApi.Migrations
{
    public partial class UserIdAddedToChatModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Chatroom",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Chatroom");
        }
    }
}
