using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zyfro.Pro.Server.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BaseEntityChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "public",
                table: "WorkflowSteps");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "public",
                table: "WorkflowSteps");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAtUtc",
                schema: "public",
                table: "WorkflowSteps");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "public",
                table: "Workflows");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAtUtc",
                schema: "public",
                table: "Workflows");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "public",
                table: "SignatureRequests");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "public",
                table: "SignatureRequests");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAtUtc",
                schema: "public",
                table: "SignatureRequests");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "public",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAtUtc",
                schema: "public",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "public",
                table: "DocumentVersions");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAtUtc",
                schema: "public",
                table: "DocumentVersions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "public",
                table: "DocumentTags");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "public",
                table: "DocumentTags");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAtUtc",
                schema: "public",
                table: "DocumentTags");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "public",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "public",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAtUtc",
                schema: "public",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "public",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "public",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAtUtc",
                schema: "public",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "public",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "public",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAtUtc",
                schema: "public",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "public",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAtUtc",
                schema: "public",
                table: "ApplicationUsers");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "WorkflowSteps",
                newName: "UpdatedAtUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "Workflows",
                newName: "UpdatedAtUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "SignatureRequests",
                newName: "UpdatedAtUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "Notifications",
                newName: "UpdatedAtUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "DocumentVersions",
                newName: "UpdatedAtUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "DocumentTags",
                newName: "UpdatedAtUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "Documents",
                newName: "UpdatedAtUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "Companies",
                newName: "UpdatedAtUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "AuditLogs",
                newName: "UpdatedAtUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "ApplicationUsers",
                newName: "UpdatedAtUtc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAtUtc",
                schema: "public",
                table: "WorkflowSteps",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAtUtc",
                schema: "public",
                table: "Workflows",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAtUtc",
                schema: "public",
                table: "SignatureRequests",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAtUtc",
                schema: "public",
                table: "Notifications",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAtUtc",
                schema: "public",
                table: "DocumentVersions",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAtUtc",
                schema: "public",
                table: "DocumentTags",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAtUtc",
                schema: "public",
                table: "Documents",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAtUtc",
                schema: "public",
                table: "Companies",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAtUtc",
                schema: "public",
                table: "AuditLogs",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAtUtc",
                schema: "public",
                table: "ApplicationUsers",
                newName: "UpdatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "public",
                table: "WorkflowSteps",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "public",
                table: "WorkflowSteps",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAtUtc",
                schema: "public",
                table: "WorkflowSteps",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "public",
                table: "Workflows",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAtUtc",
                schema: "public",
                table: "Workflows",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "public",
                table: "SignatureRequests",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "public",
                table: "SignatureRequests",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAtUtc",
                schema: "public",
                table: "SignatureRequests",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "public",
                table: "Notifications",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAtUtc",
                schema: "public",
                table: "Notifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "public",
                table: "DocumentVersions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAtUtc",
                schema: "public",
                table: "DocumentVersions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "public",
                table: "DocumentTags",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "public",
                table: "DocumentTags",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAtUtc",
                schema: "public",
                table: "DocumentTags",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "public",
                table: "Documents",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "public",
                table: "Documents",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAtUtc",
                schema: "public",
                table: "Documents",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "public",
                table: "Companies",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "public",
                table: "Companies",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAtUtc",
                schema: "public",
                table: "Companies",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "public",
                table: "AuditLogs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "public",
                table: "AuditLogs",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAtUtc",
                schema: "public",
                table: "AuditLogs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "public",
                table: "ApplicationUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAtUtc",
                schema: "public",
                table: "ApplicationUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
