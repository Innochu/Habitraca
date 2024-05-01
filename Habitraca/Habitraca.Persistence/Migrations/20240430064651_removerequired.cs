using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habitraca.Persistence.Migrations
{
    public partial class removerequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85cf5e35-d610-4442-8120-0ee97f8422f0");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DateModified", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PasswordResetToken", "PhoneNumber", "PhoneNumberConfirmed", "ResetTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bd6e8921-3c3b-4bbd-82da-5875087d6692", 0, "ee2d745b-1a83-4268-aa2f-5e532ddb1f5a", new DateTime(2024, 4, 30, 6, 46, 50, 390, DateTimeKind.Utc).AddTicks(5057), new DateTime(2024, 4, 30, 6, 46, 50, 390, DateTimeKind.Utc).AddTicks(5063), "Chuksinnocent1@gmail.com", false, "Innocent", "", true, "Chukwudi", false, null, null, null, "Password", null, "", "07013238817", false, new DateTime(2024, 4, 30, 6, 46, 50, 390, DateTimeKind.Utc).AddTicks(5062), "7ba0e7cd-cad1-48fa-b6fb-c1d6ffc0754d", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bd6e8921-3c3b-4bbd-82da-5875087d6692");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DateModified", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PasswordResetToken", "PhoneNumber", "PhoneNumberConfirmed", "ResetTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "85cf5e35-d610-4442-8120-0ee97f8422f0", 0, "b4b0af15-3334-4dbf-a8b4-aa5c0667008d", new DateTime(2024, 4, 20, 0, 59, 50, 756, DateTimeKind.Utc).AddTicks(975), new DateTime(2024, 4, 20, 0, 59, 50, 756, DateTimeKind.Utc).AddTicks(980), "Chuksinnocent1@gmail.com", false, "Innocent", "", true, "Chukwudi", false, null, null, null, "Password", null, "", "07013238817", false, new DateTime(2024, 4, 20, 0, 59, 50, 756, DateTimeKind.Utc).AddTicks(980), "466504b1-2149-455b-8f19-d263f7bead87", false, null });
        }
    }
}
