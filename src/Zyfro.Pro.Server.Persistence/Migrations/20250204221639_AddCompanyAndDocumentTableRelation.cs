using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zyfro.Pro.Server.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyAndDocumentTableRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                schema: "public",
                table: "Documents",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CompanyId",
                schema: "public",
                table: "Documents",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Companies_CompanyId",
                schema: "public",
                table: "Documents",
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
                name: "FK_Documents_Companies_CompanyId",
                schema: "public",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_CompanyId",
                schema: "public",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "public",
                table: "Documents");
        }
    }
}
