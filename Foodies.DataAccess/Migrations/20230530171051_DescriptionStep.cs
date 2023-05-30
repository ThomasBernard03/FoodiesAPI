using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foodies.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DescriptionStep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Step",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Step");
        }
    }
}
