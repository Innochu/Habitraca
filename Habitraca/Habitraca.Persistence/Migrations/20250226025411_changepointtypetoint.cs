using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habitraca.Persistence.Migrations
{
    public partial class changepointtypetoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ecb3225c-b8a3-41c4-b426-fd03daff97e3");

            migrationBuilder.AlterColumn<int>(
                name: "Point",
                table: "Rewards",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DateModified", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PasswordResetToken", "PhoneNumber", "PhoneNumberConfirmed", "ResetTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0aa7d75c-0a51-40c6-987e-e359c50533c2", 0, "3e32363d-cbfa-4b14-a927-7868fc676106", new DateTime(2025, 2, 26, 2, 54, 10, 844, DateTimeKind.Utc).AddTicks(7053), new DateTime(2025, 2, 26, 2, 54, 10, 844, DateTimeKind.Utc).AddTicks(7055), "Chuksinnocent1@gmail.com", false, "Innocent", "", true, "Chukwudi", false, null, null, null, "Password", null, "", "07013238817", false, new DateTime(2025, 2, 26, 2, 54, 10, 844, DateTimeKind.Utc).AddTicks(7054), "fa0d4566-03cb-463d-a1c1-049f480a134c", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0aa7d75c-0a51-40c6-987e-e359c50533c2");

            migrationBuilder.AlterColumn<string>(
                name: "Point",
                table: "Rewards",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DateModified", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PasswordResetToken", "PhoneNumber", "PhoneNumberConfirmed", "ResetTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ecb3225c-b8a3-41c4-b426-fd03daff97e3", 0, "0569b432-fecd-4402-ac57-4d1d036e270c", new DateTime(2025, 2, 25, 21, 0, 26, 832, DateTimeKind.Utc).AddTicks(7769), new DateTime(2025, 2, 25, 21, 0, 26, 832, DateTimeKind.Utc).AddTicks(7776), "Chuksinnocent1@gmail.com", false, "Innocent", "", true, "Chukwudi", false, null, null, null, "Password", null, "", "07013238817", false, new DateTime(2025, 2, 25, 21, 0, 26, 832, DateTimeKind.Utc).AddTicks(7775), "6efbc755-8a93-4444-80c0-cb891143aba6", false, null });
        }
    }
}
