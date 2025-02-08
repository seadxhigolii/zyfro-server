using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zyfro.Pro.Server.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCurrentVersionNumberForDocumentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "public",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "public",
                table: "DocumentVersions");

            migrationBuilder.RenameColumn(
                name: "SignedAt",
                schema: "public",
                table: "SignatureRequests",
                newName: "SignedAtUtc");

            migrationBuilder.AddColumn<int>(
                name: "CurrentVersion",
                schema: "public",
                table: "Documents",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentVersion",
                schema: "public",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "SignedAtUtc",
                schema: "public",
                table: "SignatureRequests",
                newName: "SignedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "public",
                table: "Notifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "public",
                table: "DocumentVersions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
