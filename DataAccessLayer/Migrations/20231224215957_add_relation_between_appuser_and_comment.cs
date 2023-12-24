using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class add_relation_between_appuser_and_comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AppUserID",
                table: "Comments",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserID",
                table: "Comments",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AppUserID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Comments");
        }
    }
}
