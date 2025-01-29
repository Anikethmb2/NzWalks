using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NzWalks.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DifficultySet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifficultySet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegionsSet",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionsSet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WalksSet",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LengthInKm = table.Column<double>(type: "float", nullable: false),
                    WalkImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DifficultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalksSet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WalksSet_DifficultySet_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "DifficultySet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalksSet_RegionsSet_RegionId",
                        column: x => x.RegionId,
                        principalTable: "RegionsSet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WalksSet_DifficultyId",
                table: "WalksSet",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_WalksSet_RegionId",
                table: "WalksSet",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WalksSet");

            migrationBuilder.DropTable(
                name: "DifficultySet");

            migrationBuilder.DropTable(
                name: "RegionsSet");
        }
    }
}
