using Microsoft.EntityFrameworkCore.Migrations;

namespace WC.Context.Migrations
{
    public partial class Refactor_user_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivationCode",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActivationCode",
                table: "User",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "User",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
