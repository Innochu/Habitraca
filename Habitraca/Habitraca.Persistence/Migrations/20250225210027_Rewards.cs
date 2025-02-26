//using System;
//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace Habitraca.Persistence.Migrations
//{
//    public partial class Rewards : Migration
//    {
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DeleteData(
//                table: "AspNetUsers",
//                keyColumn: "Id",
//                keyValue: "d94169f3-97f9-4809-a35b-42e6dbd11d13");

//            migrationBuilder.CreateTable(
//                name: "Rewards",
//                columns: table => new
//                {
//                    Id = table.Column<Guid>(type: "uuid", nullable: false),
//                    Description = table.Column<string>(type: "text", nullable: false),
//                    Point = table.Column<int>(type: "integer", nullable: false),
//                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
//                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
//                    CreatedBy = table.Column<string>(type: "text", nullable: false),
//                    UpdatedBy = table.Column<string>(type: "text", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Rewards", x => x.Id);
//                });

//            migrationBuilder.InsertData(
//                table: "AspNetUsers",
//                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DateModified", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PasswordResetToken", "PhoneNumber", "PhoneNumberConfirmed", "ResetTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UserName" },
//                values: new object[] { "ecb3225c-b8a3-41c4-b426-fd03daff97e3", 0, "0569b432-fecd-4402-ac57-4d1d036e270c", new DateTime(2025, 2, 25, 21, 0, 26, 832, DateTimeKind.Utc).AddTicks(7769), new DateTime(2025, 2, 25, 21, 0, 26, 832, DateTimeKind.Utc).AddTicks(7776), "Chuksinnocent1@gmail.com", false, "Innocent", "", true, "Chukwudi", false, null, null, null, "Password", null, "", "07013238817", false, new DateTime(2025, 2, 25, 21, 0, 26, 832, DateTimeKind.Utc).AddTicks(7775), "6efbc755-8a93-4444-80c0-cb891143aba6", false, null });
//        }

//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "Rewards");

//            migrationBuilder.DeleteData(
//                table: "AspNetUsers",
//                keyColumn: "Id",
//                keyValue: "ecb3225c-b8a3-41c4-b426-fd03daff97e3");

//            migrationBuilder.InsertData(
//                table: "AspNetUsers",
//                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DateModified", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PasswordResetToken", "PhoneNumber", "PhoneNumberConfirmed", "ResetTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UserName" },
//                values: new object[] { "d94169f3-97f9-4809-a35b-42e6dbd11d13", 0, "b5fd37fa-e4a3-4a27-81de-2cd1c866d9ee", new DateTime(2025, 2, 19, 14, 50, 49, 161, DateTimeKind.Utc).AddTicks(4599), new DateTime(2025, 2, 19, 14, 50, 49, 161, DateTimeKind.Utc).AddTicks(4601), "Chuksinnocent1@gmail.com", false, "Innocent", "", true, "Chukwudi", false, null, null, null, "Password", null, "", "07013238817", false, new DateTime(2025, 2, 19, 14, 50, 49, 161, DateTimeKind.Utc).AddTicks(4600), "7e4adbbc-e7a8-46a2-b4f3-18541f51580d", false, null });
//        }
//    }
//}
