using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habitraca.Persistence.Migrations
{
    public partial class pgdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd38f6d8-b64d-4609-a010-940b8b1f0acf");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DateModified", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PasswordResetToken", "PhoneNumber", "PhoneNumberConfirmed", "ResetTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "81cec254-7a8e-4fdd-a0b0-dac5422a67c5", 0, "197cf70c-eaa4-47eb-8313-7a2d743a5b1f", new DateTime(2024, 4, 8, 0, 18, 20, 791, DateTimeKind.Local).AddTicks(2169), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuksinnocent1@gmail.com", false, "Innocent", null, false, "Chukwudi", false, null, null, null, "Password", null, null, "07013238817", false, null, "e68ca1fa-66d5-4d3d-9087-766c727cd6e1", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81cec254-7a8e-4fdd-a0b0-dac5422a67c5");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DateModified", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PasswordResetToken", "PhoneNumber", "PhoneNumberConfirmed", "ResetTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fd38f6d8-b64d-4609-a010-940b8b1f0acf", 0, "e46aed18-4aea-49d3-8c8f-b017b1096520", new DateTime(2024, 3, 7, 22, 33, 20, 925, DateTimeKind.Local).AddTicks(4862), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuksinnocent1@gmail.com", false, "Innocent", null, false, "Chukwudi", false, null, null, null, "Password", null, null, "07013238817", false, null, "03bb451b-77c3-45df-938e-9a4f3db53e76", false, null });
        }
    }
}
