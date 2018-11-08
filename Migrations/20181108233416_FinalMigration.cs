using Microsoft.EntityFrameworkCore.Migrations;

namespace ChattrApi.Migrations
{
    public partial class FinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Chatroom",
                keyColumn: "ChatroomId",
                keyValue: 3,
                column: "Title",
                value: "NSS Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Chatroom",
                keyColumn: "ChatroomId",
                keyValue: 3,
                column: "Title",
                value: "Chat 3");
        }
    }
}
