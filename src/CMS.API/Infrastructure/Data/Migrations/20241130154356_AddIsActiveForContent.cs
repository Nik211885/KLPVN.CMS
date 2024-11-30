using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.API.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveForContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Contents",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Contents");
        }
    }
}
