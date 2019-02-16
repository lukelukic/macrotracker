using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MacroTracker.Users.Infrastructure.Migrations
{
    public partial class addedrequeststable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    TrainerId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingRequests_Users_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingRequests_TrainerId",
                table: "TrainingRequests",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingRequests_UserId",
                table: "TrainingRequests",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingRequests");
        }
    }
}