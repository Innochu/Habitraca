using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habitraca.Persistence.Migrations
{
    public partial class graph : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskCompletions_AspNetUsers_UserId",
                table: "TaskCompletions");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskCompletions_Tasks_TaskId",
                table: "TaskCompletions");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6e16038-c616-4037-be00-31f0d74c3bdd");

            migrationBuilder.CreateTable(
                name: "Graphs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskCount = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Graphs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DateModified", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PasswordResetToken", "PhoneNumber", "PhoneNumberConfirmed", "ResetTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "53ee9d4b-87ab-4d15-9dbb-9395879e961d", 0, "73f4e71c-3776-424f-9b58-b0912ec3e60a", new DateTime(2025, 1, 13, 19, 47, 13, 309, DateTimeKind.Utc).AddTicks(6237), new DateTime(2025, 1, 13, 19, 47, 13, 309, DateTimeKind.Utc).AddTicks(6240), "Chuksinnocent1@gmail.com", false, "Innocent", "", true, "Chukwudi", false, null, null, null, "Password", null, "", "07013238817", false, new DateTime(2025, 1, 13, 19, 47, 13, 309, DateTimeKind.Utc).AddTicks(6239), "2720ab9a-8153-483b-8cf3-673f85066df8", false, null });

            migrationBuilder.AddForeignKey(
                name: "FK_TaskCompletions_AspNetUsers_UserId",
                table: "TaskCompletions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskCompletions_Tasks_TaskId",
                table: "TaskCompletions",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskCompletions_AspNetUsers_UserId",
                table: "TaskCompletions");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskCompletions_Tasks_TaskId",
                table: "TaskCompletions");

            migrationBuilder.DropTable(
                name: "Graphs");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "53ee9d4b-87ab-4d15-9dbb-9395879e961d");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DateModified", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PasswordResetToken", "PhoneNumber", "PhoneNumberConfirmed", "ResetTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c6e16038-c616-4037-be00-31f0d74c3bdd", 0, "51cf4fcb-d431-480b-a346-b20ab9596382", new DateTime(2025, 1, 11, 0, 15, 37, 139, DateTimeKind.Utc).AddTicks(1304), new DateTime(2025, 1, 11, 0, 15, 37, 139, DateTimeKind.Utc).AddTicks(1307), "Chuksinnocent1@gmail.com", false, "Innocent", "", true, "Chukwudi", false, null, null, null, "Password", null, "", "07013238817", false, new DateTime(2025, 1, 11, 0, 15, 37, 139, DateTimeKind.Utc).AddTicks(1307), "739295aa-074c-4b81-a4f0-cb8e09c39c22", false, null });

            migrationBuilder.AddForeignKey(
                name: "FK_TaskCompletions_AspNetUsers_UserId",
                table: "TaskCompletions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskCompletions_Tasks_TaskId",
                table: "TaskCompletions",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
