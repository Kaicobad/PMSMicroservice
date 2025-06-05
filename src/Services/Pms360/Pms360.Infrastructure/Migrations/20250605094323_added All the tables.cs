using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pms360.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedAllthetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EvaluationCriteria",
                columns: table => new
                {
                    CriteriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_EvaluationCriteria", x => x.CriteriaId);
                });

            migrationBuilder.CreateTable(
                name: "PMSDurationTypes",
                columns: table => new
                {
                    DurationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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
                    table.PrimaryKey("PK_PMSDurationTypes", x => x.DurationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "CriteriaScales",
                columns: table => new
                {
                    ScaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriteriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScoreValue = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_CriteriaScales", x => x.ScaleId);
                    table.ForeignKey(
                        name: "FK_CriteriaScales_EvaluationCriteria_CriteriaId",
                        column: x => x.CriteriaId,
                        principalTable: "EvaluationCriteria",
                        principalColumn: "CriteriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PMSCycles",
                columns: table => new
                {
                    CycleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PMSTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PMSDurationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_PMSCycles", x => x.CycleId);
                    table.ForeignKey(
                        name: "FK_PMSCycles_PMSDurationTypes_PMSDurationTypeId",
                        column: x => x.PMSDurationTypeId,
                        principalTable: "PMSDurationTypes",
                        principalColumn: "DurationTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PMSCycles_PMSTypes_PMSTypeId",
                        column: x => x.PMSTypeId,
                        principalTable: "PMSTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationSummaries",
                columns: table => new
                {
                    SummaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CycleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    AverageScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinalRatingPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinalComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalizedBy = table.Column<int>(type: "int", nullable: false),
                    FinalizedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_EvaluationSummaries", x => x.SummaryId);
                    table.ForeignKey(
                        name: "FK_EvaluationSummaries_PMSCycles_CycleId",
                        column: x => x.CycleId,
                        principalTable: "PMSCycles",
                        principalColumn: "CycleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PMSAssessors",
                columns: table => new
                {
                    AssessorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CycleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssesseeEmpId = table.Column<int>(type: "int", nullable: true),
                    AssessorEmpId = table.Column<int>(type: "int", nullable: true),
                    AssessorTypeId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_PMSAssessors", x => x.AssessorId);
                    table.ForeignKey(
                        name: "FK_PMSAssessors_PMSCycles_CycleId",
                        column: x => x.CycleId,
                        principalTable: "PMSCycles",
                        principalColumn: "CycleId");
                });

            migrationBuilder.CreateTable(
                name: "PMSCycleDetails",
                columns: table => new
                {
                    CycleDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CycleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_PMSCycleDetails", x => x.CycleDetailsId);
                    table.ForeignKey(
                        name: "FK_PMSCycleDetails_PMSCycles_CycleId",
                        column: x => x.CycleId,
                        principalTable: "PMSCycles",
                        principalColumn: "CycleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssessorTypes",
                columns: table => new
                {
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PMSAssessorAssessorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_AssessorTypes", x => x.TypeId);
                    table.ForeignKey(
                        name: "FK_AssessorTypes_PMSAssessors_PMSAssessorAssessorId",
                        column: x => x.PMSAssessorAssessorId,
                        principalTable: "PMSAssessors",
                        principalColumn: "AssessorId");
                });

            migrationBuilder.CreateTable(
                name: "EvaluationResponses",
                columns: table => new
                {
                    ResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CriteriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_EvaluationResponses", x => x.ResponseId);
                    table.ForeignKey(
                        name: "FK_EvaluationResponses_EvaluationCriteria_CriteriaId",
                        column: x => x.CriteriaId,
                        principalTable: "EvaluationCriteria",
                        principalColumn: "CriteriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvaluationResponses_PMSAssessors_AssessorId",
                        column: x => x.AssessorId,
                        principalTable: "PMSAssessors",
                        principalColumn: "AssessorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PMSCycleDetailsWithCriteriaMappings",
                columns: table => new
                {
                    CycleDetailsCriteriaMappingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CycleDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CriteriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PMSCycleDetailsWithCriteriaMappings", x => x.CycleDetailsCriteriaMappingId);
                    table.ForeignKey(
                        name: "FK_PMSCycleDetailsWithCriteriaMappings_EvaluationCriteria_CriteriaId",
                        column: x => x.CriteriaId,
                        principalTable: "EvaluationCriteria",
                        principalColumn: "CriteriaId");
                    table.ForeignKey(
                        name: "FK_PMSCycleDetailsWithCriteriaMappings_PMSCycleDetails_CycleDetailsId",
                        column: x => x.CycleDetailsId,
                        principalTable: "PMSCycleDetails",
                        principalColumn: "CycleDetailsId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssessorTypes_PMSAssessorAssessorId",
                table: "AssessorTypes",
                column: "PMSAssessorAssessorId");

            migrationBuilder.CreateIndex(
                name: "IX_CriteriaScales_CriteriaId",
                table: "CriteriaScales",
                column: "CriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationResponses_AssessorId",
                table: "EvaluationResponses",
                column: "AssessorId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationResponses_CriteriaId",
                table: "EvaluationResponses",
                column: "CriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationSummaries_CycleId",
                table: "EvaluationSummaries",
                column: "CycleId");

            migrationBuilder.CreateIndex(
                name: "IX_PMSAssessors_CycleId",
                table: "PMSAssessors",
                column: "CycleId");

            migrationBuilder.CreateIndex(
                name: "IX_PMSCycleDetails_CycleId",
                table: "PMSCycleDetails",
                column: "CycleId");

            migrationBuilder.CreateIndex(
                name: "IX_PMSCycleDetailsWithCriteriaMappings_CriteriaId",
                table: "PMSCycleDetailsWithCriteriaMappings",
                column: "CriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_PMSCycleDetailsWithCriteriaMappings_CycleDetailsId",
                table: "PMSCycleDetailsWithCriteriaMappings",
                column: "CycleDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_PMSCycles_PMSDurationTypeId",
                table: "PMSCycles",
                column: "PMSDurationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PMSCycles_PMSTypeId",
                table: "PMSCycles",
                column: "PMSTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssessorTypes");

            migrationBuilder.DropTable(
                name: "CriteriaScales");

            migrationBuilder.DropTable(
                name: "EvaluationResponses");

            migrationBuilder.DropTable(
                name: "EvaluationSummaries");

            migrationBuilder.DropTable(
                name: "PMSCycleDetailsWithCriteriaMappings");

            migrationBuilder.DropTable(
                name: "PMSAssessors");

            migrationBuilder.DropTable(
                name: "EvaluationCriteria");

            migrationBuilder.DropTable(
                name: "PMSCycleDetails");

            migrationBuilder.DropTable(
                name: "PMSCycles");

            migrationBuilder.DropTable(
                name: "PMSDurationTypes");
        }
    }
}
