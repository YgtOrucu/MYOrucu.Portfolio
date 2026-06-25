using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuhsinYigitOrucu.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddedExperienceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    ExperienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    Title = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    Date = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    WorkMethod = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    DescriptionJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseTechnologyJson = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.ExperienceId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Experience");
        }
    }
}
