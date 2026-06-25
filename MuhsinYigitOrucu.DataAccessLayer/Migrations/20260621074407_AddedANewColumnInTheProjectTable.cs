using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuhsinYigitOrucu.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddedANewColumnInTheProjectTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShowOnHomePage",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowOnHomePage",
                table: "Projects");
        }
    }
}
