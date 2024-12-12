using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.API.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class deleteTableAuActionForClassese : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuActionAuClasses_AuActions_ActionId",
                table: "AuActionAuClasses");

            migrationBuilder.DropTable(
                name: "AuActions");

            migrationBuilder.DropIndex(
                name: "IX_AuActionAuClasses_ActionId",
                table: "AuActionAuClasses");

            migrationBuilder.DropColumn(
                name: "ActionId",
                table: "AuActionAuClasses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ActionId",
                table: "AuActionAuClasses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AuActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuActions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuActionAuClasses_ActionId",
                table: "AuActionAuClasses",
                column: "ActionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuActionAuClasses_AuActions_ActionId",
                table: "AuActionAuClasses",
                column: "ActionId",
                principalTable: "AuActions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
