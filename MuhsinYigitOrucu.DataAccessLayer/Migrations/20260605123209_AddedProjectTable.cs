using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuhsinYigitOrucu.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddedProjectTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    Title = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    MiniDescription = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true),
                    UseTechnologyJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GithubLink = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
