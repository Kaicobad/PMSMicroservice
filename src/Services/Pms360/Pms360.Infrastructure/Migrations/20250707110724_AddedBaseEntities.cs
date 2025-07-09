using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pms360.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedBaseEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "AssessorUserMaps",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AssessorUserMaps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedById",
                table: "AssessorUserMaps",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "AssessorUserMaps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AssessorUserMaps",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "AssessorUserMaps",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "AssessorUserMaps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "AssessorTypeMaps",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AssessorTypeMaps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedById",
                table: "AssessorTypeMaps",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "AssessorTypeMaps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AssessorTypeMaps",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "AssessorTypeMaps",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "AssessorTypeMaps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "AccessorMasters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AccessorMasters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedById",
                table: "AccessorMasters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "AccessorMasters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AccessorMasters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "AccessorMasters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "AccessorMasters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AssessorUserMaps");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AssessorUserMaps");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "AssessorUserMaps");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "AssessorUserMaps");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AssessorUserMaps");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "AssessorUserMaps");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "AssessorUserMaps");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AssessorTypeMaps");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AssessorTypeMaps");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "AssessorTypeMaps");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "AssessorTypeMaps");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AssessorTypeMaps");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "AssessorTypeMaps");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "AssessorTypeMaps");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AccessorMasters");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AccessorMasters");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "AccessorMasters");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "AccessorMasters");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AccessorMasters");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "AccessorMasters");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "AccessorMasters");
        }
    }
}
