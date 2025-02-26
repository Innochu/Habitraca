using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habitraca.Persistence.Migrations
{
    public partial class User_2table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3cac182-ae27-4f45-82c8-40af5733656c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DateModified", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PasswordResetToken", "PhoneNumber", "PhoneNumberConfirmed", "ResetTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d94169f3-97f9-4809-a35b-42e6dbd11d13", 0, "b5fd37fa-e4a3-4a27-81de-2cd1c866d9ee", new DateTime(2025, 2, 19, 14, 50, 49, 161, DateTimeKind.Utc).AddTicks(4599), new DateTime(2025, 2, 19, 14, 50, 49, 161, DateTimeKind.Utc).AddTicks(4601), "Chuksinnocent1@gmail.com", false, "Innocent", "", true, "Chukwudi", false, null, null, null, "Password", null, "", "07013238817", false, new DateTime(2025, 2, 19, 14, 50, 49, 161, DateTimeKind.Utc).AddTicks(4600), "7e4adbbc-e7a8-46a2-b4f3-18541f51580d", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d94169f3-97f9-4809-a35b-42e6dbd11d13");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DateModified", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PasswordResetToken", "PhoneNumber", "PhoneNumberConfirmed", "ResetTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b3cac182-ae27-4f45-82c8-40af5733656c", 0, "7da62ca4-efce-4815-86ce-18d0fab017c9", new DateTime(2025, 2, 3, 0, 22, 46, 646, DateTimeKind.Utc).AddTicks(4732), new DateTime(2025, 2, 3, 0, 22, 46, 646, DateTimeKind.Utc).AddTicks(4737), "Chuksinnocent1@gmail.com", false, "Innocent", "", true, "Chukwudi", false, null, null, null, "Password", null, "", "07013238817", false, new DateTime(2025, 2, 3, 0, 22, 46, 646, DateTimeKind.Utc).AddTicks(4736), "b59bdf2f-87de-481c-8387-19af926ba267", false, null });
        }
    }
}
