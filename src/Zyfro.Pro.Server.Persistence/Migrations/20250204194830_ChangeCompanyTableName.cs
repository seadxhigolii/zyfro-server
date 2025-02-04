using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zyfro.Pro.Server.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCompanyTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_Company_CompanyId",
                schema: "public",
                table: "ApplicationUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                schema: "public",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Company",
                schema: "public",
                newName: "Companies",
                newSchema: "public");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                schema: "public",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsers_Companies_CompanyId",
                schema: "public",
                table: "ApplicationUsers",
                column: "CompanyId",
                principalSchema: "public",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_Companies_CompanyId",
                schema: "public",
                table: "ApplicationUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                schema: "public",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                schema: "public",
                newName: "Company",
                newSchema: "public");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                schema: "public",
                table: "Company",
                column: "Id");

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
    }
}
