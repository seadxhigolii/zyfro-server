using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zyfro.Pro.Server.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCurrentUserToBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "public",
                table: "WorkflowSteps",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrentStateUser",
                schema: "public",
                table: "WorkflowSteps",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "public",
                table: "Workflows",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrentStateUser",
                schema: "public",
                table: "Workflows",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "public",
                table: "SignatureRequests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrentStateUser",
                schema: "public",
                table: "SignatureRequests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "public",
                table: "Notifications",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrentStateUser",
                schema: "public",
                table: "Notifications",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "public",
                table: "DocumentVersions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrentStateUser",
                schema: "public",
                table: "DocumentVersions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "public",
                table: "DocumentTags",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrentStateUser",
                schema: "public",
                table: "DocumentTags",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "public",
                table: "Documents",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrentStateUser",
                schema: "public",
                table: "Documents",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "public",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrentStateUser",
                schema: "public",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "public",
                table: "AuditLogs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrentStateUser",
                schema: "public",
                table: "AuditLogs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "public",
                table: "ApplicationUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrentStateUser",
                schema: "public",
                table: "ApplicationUsers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "WorkflowSteps");

            migrationBuilder.DropColumn(
                name: "CurrentStateUser",
                schema: "public",
                table: "WorkflowSteps");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "Workflows");

            migrationBuilder.DropColumn(
                name: "CurrentStateUser",
                schema: "public",
                table: "Workflows");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "SignatureRequests");

            migrationBuilder.DropColumn(
                name: "CurrentStateUser",
                schema: "public",
                table: "SignatureRequests");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "CurrentStateUser",
                schema: "public",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "DocumentVersions");

            migrationBuilder.DropColumn(
                name: "CurrentStateUser",
                schema: "public",
                table: "DocumentVersions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "DocumentTags");

            migrationBuilder.DropColumn(
                name: "CurrentStateUser",
                schema: "public",
                table: "DocumentTags");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "CurrentStateUser",
                schema: "public",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CurrentStateUser",
                schema: "public",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "CurrentStateUser",
                schema: "public",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "CurrentStateUser",
                schema: "public",
                table: "ApplicationUsers");
        }
    }
}
