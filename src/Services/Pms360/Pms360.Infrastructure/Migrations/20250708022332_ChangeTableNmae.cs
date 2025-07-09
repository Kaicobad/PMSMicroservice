using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pms360.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableNmae : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssessorTypeMaps_AccessorMasters_AssessorMasterId",
                table: "AssessorTypeMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_AssessorUserMaps_AccessorMasters_AssessorMasterId",
                table: "AssessorUserMaps");

            migrationBuilder.DropTable(
                name: "AccessorMasters");

            migrationBuilder.CreateTable(
                name: "AssessorMasters",
                columns: table => new
                {
                    AssessorMasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsForUser = table.Column<bool>(type: "bit", nullable: false),
                    IsForUnit = table.Column<bool>(type: "bit", nullable: false),
                    IsForDepartment = table.Column<bool>(type: "bit", nullable: false),
                    IsForSection = table.Column<bool>(type: "bit", nullable: false),
                    IsForWing = table.Column<bool>(type: "bit", nullable: false),
                    IsForTeam = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessorMasters", x => x.AssessorMasterId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AssessorTypeMaps_AssessorMasters_AssessorMasterId",
                table: "AssessorTypeMaps",
                column: "AssessorMasterId",
                principalTable: "AssessorMasters",
                principalColumn: "AssessorMasterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssessorUserMaps_AssessorMasters_AssessorMasterId",
                table: "AssessorUserMaps",
                column: "AssessorMasterId",
                principalTable: "AssessorMasters",
                principalColumn: "AssessorMasterId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssessorTypeMaps_AssessorMasters_AssessorMasterId",
                table: "AssessorTypeMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_AssessorUserMaps_AssessorMasters_AssessorMasterId",
                table: "AssessorUserMaps");

            migrationBuilder.DropTable(
                name: "AssessorMasters");

            migrationBuilder.CreateTable(
                name: "AccessorMasters",
                columns: table => new
                {
                    AssessorMasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsForDepartment = table.Column<bool>(type: "bit", nullable: false),
                    IsForSection = table.Column<bool>(type: "bit", nullable: false),
                    IsForTeam = table.Column<bool>(type: "bit", nullable: false),
                    IsForUnit = table.Column<bool>(type: "bit", nullable: false),
                    IsForUser = table.Column<bool>(type: "bit", nullable: false),
                    IsForWing = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessorMasters", x => x.AssessorMasterId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AssessorTypeMaps_AccessorMasters_AssessorMasterId",
                table: "AssessorTypeMaps",
                column: "AssessorMasterId",
                principalTable: "AccessorMasters",
                principalColumn: "AssessorMasterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssessorUserMaps_AccessorMasters_AssessorMasterId",
                table: "AssessorUserMaps",
                column: "AssessorMasterId",
                principalTable: "AccessorMasters",
                principalColumn: "AssessorMasterId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
