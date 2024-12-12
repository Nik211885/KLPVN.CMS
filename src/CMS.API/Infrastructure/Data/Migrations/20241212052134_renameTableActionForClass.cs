using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.API.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class renameTableActionForClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuActionAuClasses_AuClasses_ClassId",
                table: "AuActionAuClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_AuActionAuClasses_ActionClassId",
                table: "Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuActionAuClasses",
                table: "AuActionAuClasses");

            migrationBuilder.RenameTable(
                name: "AuActionAuClasses",
                newName: "AuActionClasses");

            migrationBuilder.RenameIndex(
                name: "IX_AuActionAuClasses_ClassId",
                table: "AuActionClasses",
                newName: "IX_AuActionClasses_ClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuActionClasses",
                table: "AuActionClasses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuActionClasses_AuClasses_ClassId",
                table: "AuActionClasses",
                column: "ClassId",
                principalTable: "AuClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_AuActionClasses_ActionClassId",
                table: "Permissions",
                column: "ActionClassId",
                principalTable: "AuActionClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuActionClasses_AuClasses_ClassId",
                table: "AuActionClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_AuActionClasses_ActionClassId",
                table: "Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuActionClasses",
                table: "AuActionClasses");

            migrationBuilder.RenameTable(
                name: "AuActionClasses",
                newName: "AuActionAuClasses");

            migrationBuilder.RenameIndex(
                name: "IX_AuActionClasses_ClassId",
                table: "AuActionAuClasses",
                newName: "IX_AuActionAuClasses_ClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuActionAuClasses",
                table: "AuActionAuClasses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuActionAuClasses_AuClasses_ClassId",
                table: "AuActionAuClasses",
                column: "ClassId",
                principalTable: "AuClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_AuActionAuClasses_ActionClassId",
                table: "Permissions",
                column: "ActionClassId",
                principalTable: "AuActionAuClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
