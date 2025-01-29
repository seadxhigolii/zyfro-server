using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zyfro.Pro.Server.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedAtToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditLog_ApplicationUser_UserId",
                table: "AuditLog");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_ApplicationUser_OwnerId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_ApplicationUser_UserId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_SignatureRequest_ApplicationUser_RequestedById",
                table: "SignatureRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_SignatureRequest_ApplicationUser_RequestedToId",
                table: "SignatureRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowStep_ApplicationUser_AssignedToUserId",
                table: "WorkflowStep");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "WorkflowStep",
                newName: "WorkflowStep",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Workflow",
                newName: "Workflow",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                newName: "UserTokens",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "UserRoles",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                newName: "UserLogins",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                newName: "UserClaims",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "SignatureRequest",
                newName: "SignatureRequest",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Roles",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                newName: "RoleClaims",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Notification",
                newName: "Notification",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "DocumentVersion",
                newName: "DocumentVersion",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "DocumentTag",
                newName: "DocumentTag",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Document",
                newName: "Document",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "AuditLog",
                newName: "AuditLog",
                newSchema: "public");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "public",
                table: "UserTokens",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "Users",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "public",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "public",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "public",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                schema: "public",
                table: "UserRoles",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "public",
                table: "UserRoles",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "public",
                table: "UserLogins",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "public",
                table: "UserClaims",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "Roles",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                schema: "public",
                table: "RoleClaims",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditLog_Users_UserId",
                schema: "public",
                table: "AuditLog",
                column: "UserId",
                principalSchema: "public",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Users_OwnerId",
                schema: "public",
                table: "Document",
                column: "OwnerId",
                principalSchema: "public",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Users_UserId",
                schema: "public",
                table: "Notification",
                column: "UserId",
                principalSchema: "public",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SignatureRequest_Users_RequestedById",
                schema: "public",
                table: "SignatureRequest",
                column: "RequestedById",
                principalSchema: "public",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SignatureRequest_Users_RequestedToId",
                schema: "public",
                table: "SignatureRequest",
                column: "RequestedToId",
                principalSchema: "public",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowStep_Users_AssignedToUserId",
                schema: "public",
                table: "WorkflowStep",
                column: "AssignedToUserId",
                principalSchema: "public",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditLog_Users_UserId",
                schema: "public",
                table: "AuditLog");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_Users_OwnerId",
                schema: "public",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Users_UserId",
                schema: "public",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_SignatureRequest_Users_RequestedById",
                schema: "public",
                table: "SignatureRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_SignatureRequest_Users_RequestedToId",
                schema: "public",
                table: "SignatureRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowStep_Users_AssignedToUserId",
                schema: "public",
                table: "WorkflowStep");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "public",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "public",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "public",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "WorkflowStep",
                schema: "public",
                newName: "WorkflowStep");

            migrationBuilder.RenameTable(
                name: "Workflow",
                schema: "public",
                newName: "Workflow");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                schema: "public",
                newName: "UserTokens");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "public",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "public",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                schema: "public",
                newName: "UserLogins");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                schema: "public",
                newName: "UserClaims");

            migrationBuilder.RenameTable(
                name: "SignatureRequest",
                schema: "public",
                newName: "SignatureRequest");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "public",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                schema: "public",
                newName: "RoleClaims");

            migrationBuilder.RenameTable(
                name: "Notification",
                schema: "public",
                newName: "Notification");

            migrationBuilder.RenameTable(
                name: "DocumentVersion",
                schema: "public",
                newName: "DocumentVersion");

            migrationBuilder.RenameTable(
                name: "DocumentTag",
                schema: "public",
                newName: "DocumentTag");

            migrationBuilder.RenameTable(
                name: "Document",
                schema: "public",
                newName: "Document");

            migrationBuilder.RenameTable(
                name: "AuditLog",
                schema: "public",
                newName: "AuditLog");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserTokens",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "UserRoles",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserRoles",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserLogins",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserClaims",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Roles",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "RoleClaims",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AuditLog_ApplicationUser_UserId",
                table: "AuditLog",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_ApplicationUser_OwnerId",
                table: "Document",
                column: "OwnerId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_ApplicationUser_UserId",
                table: "Notification",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SignatureRequest_ApplicationUser_RequestedById",
                table: "SignatureRequest",
                column: "RequestedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SignatureRequest_ApplicationUser_RequestedToId",
                table: "SignatureRequest",
                column: "RequestedToId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowStep_ApplicationUser_AssignedToUserId",
                table: "WorkflowStep",
                column: "AssignedToUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
