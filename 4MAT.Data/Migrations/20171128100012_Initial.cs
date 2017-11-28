using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace _4MAT.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BluePlayerId = table.Column<Guid>(nullable: true),
                    BlueScore = table.Column<int>(nullable: false),
                    KickOff = table.Column<DateTime>(nullable: false),
                    Outcome = table.Column<int>(nullable: false),
                    RedPlayerId = table.Column<Guid>(nullable: true),
                    RedScore = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Players_BluePlayerId",
                        column: x => x.BluePlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Players_RedPlayerId",
                        column: x => x.RedPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_BluePlayerId",
                table: "Games",
                column: "BluePlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_RedPlayerId",
                table: "Games",
                column: "RedPlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
