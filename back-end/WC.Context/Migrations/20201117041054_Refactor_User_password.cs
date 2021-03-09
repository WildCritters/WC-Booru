using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WC.Context.Migrations
{
    public partial class Refactor_User_password : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pass",
                table: "User");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Pass",
                table: "User",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
