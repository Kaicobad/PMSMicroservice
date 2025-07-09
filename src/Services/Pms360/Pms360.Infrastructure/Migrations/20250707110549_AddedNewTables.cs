using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pms360.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessorMasters",
                columns: table => new
                {
                    AssessorMasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsForUser = table.Column<bool>(type: "bit", nullable: false),
                    IsForUnit = table.Column<bool>(type: "bit", nullable: false),
                    IsForDepartment = table.Column<bool>(type: "bit", nullable: false),
                    IsForSection = table.Column<bool>(type: "bit", nullable: false),
                    IsForWing = table.Column<bool>(type: "bit", nullable: false),
                    IsForTeam = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessorMasters", x => x.AssessorMasterId);
                });

            migrationBuilder.CreateTable(
                name: "AssessorTypeMaps",
                columns: table => new
                {
                    AssessorTypeMapId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssessorMasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssessorTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessorTypeMaps", x => x.AssessorTypeMapId);
                    table.ForeignKey(
                        name: "FK_AssessorTypeMaps_AccessorMasters_AssessorMasterId",
                        column: x => x.AssessorMasterId,
                        principalTable: "AccessorMasters",
                        principalColumn: "AssessorMasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessorTypeMaps_AssessorTypes_AssessorTypeId",
                        column: x => x.AssessorTypeId,
                        principalTable: "AssessorTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssessorUserMaps",
                columns: table => new
                {
                    AssessorUserMapId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssessorTypeMapId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssessorMasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessorUserMaps", x => x.AssessorUserMapId);
                    table.ForeignKey(
                        name: "FK_AssessorUserMaps_AccessorMasters_AssessorMasterId",
                        column: x => x.AssessorMasterId,
                        principalTable: "AccessorMasters",
                        principalColumn: "AssessorMasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessorUserMaps_AssessorTypeMaps_AssessorTypeMapId",
                        column: x => x.AssessorTypeMapId,
                        principalTable: "AssessorTypeMaps",
                        principalColumn: "AssessorTypeMapId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssessorTypeMaps_AssessorMasterId",
                table: "AssessorTypeMaps",
                column: "AssessorMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessorTypeMaps_AssessorTypeId",
                table: "AssessorTypeMaps",
                column: "AssessorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessorUserMaps_AssessorMasterId",
                table: "AssessorUserMaps",
                column: "AssessorMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessorUserMaps_AssessorTypeMapId",
                table: "AssessorUserMaps",
                column: "AssessorTypeMapId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssessorUserMaps");

            migrationBuilder.DropTable(
                name: "AssessorTypeMaps");

            migrationBuilder.DropTable(
                name: "AccessorMasters");
        }
    }
}
