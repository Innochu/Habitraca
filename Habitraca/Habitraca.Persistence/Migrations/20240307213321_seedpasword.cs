using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habitraca.Persistence.Migrations
{
    public partial class seedpasword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15f7f226-bcae-49b3-a0b1-0b409dc3399e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DateModified", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PasswordResetToken", "PhoneNumber", "PhoneNumberConfirmed", "ResetTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fd38f6d8-b64d-4609-a010-940b8b1f0acf", 0, "e46aed18-4aea-49d3-8c8f-b017b1096520", new DateTime(2024, 3, 7, 22, 33, 20, 925, DateTimeKind.Local).AddTicks(4862), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuksinnocent1@gmail.com", false, "Innocent", null, false, "Chukwudi", false, null, null, null, "Password", null, null, "07013238817", false, null, "03bb451b-77c3-45df-938e-9a4f3db53e76", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd38f6d8-b64d-4609-a010-940b8b1f0acf");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DateModified", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PasswordResetToken", "PhoneNumber", "PhoneNumberConfirmed", "ResetTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "15f7f226-bcae-49b3-a0b1-0b409dc3399e", 0, "54390da0-95b1-4baa-a051-a4a3c7afdd3d", new DateTime(2024, 3, 7, 6, 22, 48, 192, DateTimeKind.Local).AddTicks(189), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chuksinnocent1@gmail.com", false, "Innocent", null, false, "Chukwudi", false, null, null, null, null, null, null, "07013238817", false, null, "065f9263-7155-4c10-a88c-c5c64c19be91", false, null });
        }
    }
}
