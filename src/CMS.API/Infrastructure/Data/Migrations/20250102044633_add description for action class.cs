using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.API.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class adddescriptionforactionclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AuActionClasses",
                type: "character varying(250)",
                maxLength: 250,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "AuActionClasses");
        }
    }
}
