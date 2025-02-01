using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zyfro.Pro.Server.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDeletedColumnForBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "public",
                table: "WorkflowSteps",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "public",
                table: "Workflows",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "public",
                table: "SignatureRequests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "public",
                table: "Notifications",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "public",
                table: "DocumentVersions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "public",
                table: "DocumentTags",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "public",
                table: "Documents",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "public",
                table: "AuditLogs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "public",
                table: "ApplicationUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "public",
                table: "WorkflowSteps");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "public",
                table: "Workflows");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "public",
                table: "SignatureRequests");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "public",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "public",
                table: "DocumentVersions");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "public",
                table: "DocumentTags");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "public",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "public",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "public",
                table: "ApplicationUsers");
        }
    }
}
