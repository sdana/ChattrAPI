using Microsoft.EntityFrameworkCore.Migrations;

namespace ChattrApi.Migrations
{
    public partial class ChatroomSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Chatroom",
                columns: new[] { "ChatroomId", "Private", "Title" },
                values: new object[] { 1, false, "General" });

            migrationBuilder.InsertData(
                table: "Chatroom",
                columns: new[] { "ChatroomId", "Private", "Title" },
                values: new object[] { 2, false, "Introductions" });

            migrationBuilder.InsertData(
                table: "Chatroom",
                columns: new[] { "ChatroomId", "Private", "Title" },
                values: new object[] { 3, false, "Chat 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Chatroom",
                keyColumn: "ChatroomId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Chatroom",
                keyColumn: "ChatroomId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Chatroom",
                keyColumn: "ChatroomId",
                keyValue: 3);
        }
    }
}
