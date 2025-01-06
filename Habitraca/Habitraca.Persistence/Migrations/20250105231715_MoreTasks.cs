using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habitraca.Persistence.Migrations
{
    public partial class MoreTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7668b156-8587-4941-893c-183349600f87");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TertiaryAcademicTasks",
                newName: "Task");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SecondaryAcademicTasks",
                newName: "Task");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PrimaryAcademicTasks",
                newName: "Task");

            migrationBuilder.CreateTable(
                name: "CareerGrowths",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Task = table.Column<string>(type: "text", nullable: false),
                    Points = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerGrowths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComputerLiteracys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Task = table.Column<string>(type: "text", nullable: false),
                    Points = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerLiteracys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinanacialManagements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Task = table.Column<string>(type: "text", nullable: false),
                    Points = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanacialManagements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthyEatings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Task = table.Column<string>(type: "text", nullable: false),
                    Points = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthyEatings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leaderships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Task = table.Column<string>(type: "text", nullable: false),
                    Points = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaderships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MentalWellnesss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Task = table.Column<string>(type: "text", nullable: false),
                    Points = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentalWellnesss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalGrowths",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Task = table.Column<string>(type: "text", nullable: false),
                    Points = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalGrowths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalFitnesss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Task = table.Column<string>(type: "text", nullable: false),
                    Points = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalFitnesss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialDevelopments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Task = table.Column<string>(type: "text", nullable: false),
                    Points = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialDevelopments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpiritualGrowths",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Task = table.Column<string>(type: "text", nullable: false),
                    Points = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpiritualGrowths", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DailyTaskAssigned", "DailyTaskDone", "DateModified", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "MonthlyTaskAssigned", "MonthlyTaskDone", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PasswordResetToken", "PhoneNumber", "PhoneNumberConfirmed", "ResetTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UserName", "WeeklyTaskAssigned", "WeeklyTaskDone" },
                values: new object[] { "a88a62b1-cbdd-4d9f-a874-8b58e26ac1e9", 0, "f7bdb1e4-d934-497b-8991-cfe51659587d", new DateTime(2025, 1, 5, 23, 17, 15, 535, DateTimeKind.Utc).AddTicks(9110), "", "", new DateTime(2025, 1, 5, 23, 17, 15, 535, DateTimeKind.Utc).AddTicks(9110), "Chuksinnocent1@gmail.com", false, "Innocent", "", true, "Chukwudi", false, null, "", "", null, null, "Password", null, "", "07013238817", false, new DateTime(2025, 1, 5, 23, 17, 15, 535, DateTimeKind.Utc).AddTicks(9110), "62a18004-6a02-4504-a7fa-47f83aed7d8f", false, null, "", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CareerGrowths");

            migrationBuilder.DropTable(
                name: "ComputerLiteracys");

            migrationBuilder.DropTable(
                name: "FinanacialManagements");

            migrationBuilder.DropTable(
                name: "HealthyEatings");

            migrationBuilder.DropTable(
                name: "Leaderships");

            migrationBuilder.DropTable(
                name: "MentalWellnesss");

            migrationBuilder.DropTable(
                name: "PersonalGrowths");

            migrationBuilder.DropTable(
                name: "PhysicalFitnesss");

            migrationBuilder.DropTable(
                name: "SocialDevelopments");

            migrationBuilder.DropTable(
                name: "SpiritualGrowths");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a88a62b1-cbdd-4d9f-a874-8b58e26ac1e9");

            migrationBuilder.RenameColumn(
                name: "Task",
                table: "TertiaryAcademicTasks",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Task",
                table: "SecondaryAcademicTasks",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Task",
                table: "PrimaryAcademicTasks",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DailyTaskAssigned", "DailyTaskDone", "DateModified", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "MonthlyTaskAssigned", "MonthlyTaskDone", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PasswordResetToken", "PhoneNumber", "PhoneNumberConfirmed", "ResetTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UserName", "WeeklyTaskAssigned", "WeeklyTaskDone" },
                values: new object[] { "7668b156-8587-4941-893c-183349600f87", 0, "4ca63c97-60b7-4ec1-8d1d-0b04273b53fa", new DateTime(2025, 1, 5, 20, 35, 30, 330, DateTimeKind.Utc).AddTicks(1810), "", "", new DateTime(2025, 1, 5, 20, 35, 30, 330, DateTimeKind.Utc).AddTicks(1810), "Chuksinnocent1@gmail.com", false, "Innocent", "", true, "Chukwudi", false, null, "", "", null, null, "Password", null, "", "07013238817", false, new DateTime(2025, 1, 5, 20, 35, 30, 330, DateTimeKind.Utc).AddTicks(1810), "0847caf6-9d3f-4fc0-bc9f-ab28d571fed9", false, null, "", "" });
        }
    }
}
