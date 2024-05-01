using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habitraca.Persistence.Migrations
{
    public partial class isactive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "644f893a-9cfc-4d22-aecb-f91974c3d0f4");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "AspNetUsers",
                newName: "IsActive");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DateModified", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PasswordResetToken", "PhoneNumber", "PhoneNumberConfirmed", "ResetTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "57d047ac-f2eb-48cd-87fe-5f840993b1d1", 0, "d4e9f64a-97b8-4769-a3cf-19608017edb0", new DateTime(2024, 4, 20, 0, 49, 4, 574, DateTimeKind.Utc).AddTicks(5697), new DateTime(2024, 4, 20, 0, 49, 4, 574, DateTimeKind.Utc).AddTicks(5700), "Chuksinnocent1@gmail.com", false, "Innocent", "", true, "Chukwudi", false, null, null, null, "Password", null, "", "07013238817", false, new DateTime(2024, 4, 20, 0, 49, 4, 574, DateTimeKind.Utc).AddTicks(5700), "54cbf247-5efe-4e35-82a9-519c7a4ad260", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "57d047ac-f2eb-48cd-87fe-5f840993b1d1");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "AspNetUsers",
                newName: "IsDeleted");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DateModified", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PasswordResetToken", "PhoneNumber", "PhoneNumberConfirmed", "ResetTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "644f893a-9cfc-4d22-aecb-f91974c3d0f4", 0, "e029db09-7848-425c-b222-148074cfdf68", new DateTime(2024, 4, 11, 15, 53, 37, 245, DateTimeKind.Utc).AddTicks(908), new DateTime(2024, 4, 11, 15, 53, 37, 245, DateTimeKind.Utc).AddTicks(915), "Chuksinnocent1@gmail.com", false, "Innocent", "", false, "Chukwudi", false, null, null, null, "Password", null, "", "07013238817", false, new DateTime(2024, 4, 11, 15, 53, 37, 245, DateTimeKind.Utc).AddTicks(914), "2597b69b-159b-4f42-b427-b715b5c843df", false, null });
        }
    }
}
