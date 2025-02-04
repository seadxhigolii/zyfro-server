using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zyfro.Pro.Server.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                schema: "public",
                table: "ApplicationUsers",
                type: "uuid",
                nullable: true);            

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_CompanyId",
                schema: "public",
                table: "ApplicationUsers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsers_Company_CompanyId",
                schema: "public",
                table: "ApplicationUsers",
                column: "CompanyId",
                principalSchema: "public",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_Company_CompanyId",
                schema: "public",
                table: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUsers_CompanyId",
                schema: "public",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "public",
                table: "ApplicationUsers");
        }
    }
}
