using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pms360.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fixacycledetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PMSCycleDetails_PMSAssessors_PMSAssessorAssessorId",
                table: "PMSCycleDetails");

            migrationBuilder.DropIndex(
                name: "IX_PMSCycleDetails_PMSAssessorAssessorId",
                table: "PMSCycleDetails");

            migrationBuilder.DropColumn(
                name: "PMSAssessorAssessorId",
                table: "PMSCycleDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PMSAssessorAssessorId",
                table: "PMSCycleDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PMSCycleDetails_PMSAssessorAssessorId",
                table: "PMSCycleDetails",
                column: "PMSAssessorAssessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PMSCycleDetails_PMSAssessors_PMSAssessorAssessorId",
                table: "PMSCycleDetails",
                column: "PMSAssessorAssessorId",
                principalTable: "PMSAssessors",
                principalColumn: "AssessorId");
        }
    }
}
