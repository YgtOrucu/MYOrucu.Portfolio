using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuhsinYigitOrucu.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddedProjectDetailTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectDetail",
                columns: table => new
                {
                    ProjectDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FullDescription = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GalleryImagesJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Year = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TeamSize = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GithubLink = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LiveDemoUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UseTechnologyJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeaturesJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChallengesJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDetail", x => x.ProjectDetailId);
                    table.ForeignKey(
                        name: "FK_ProjectDetail_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDetail_ProjectId",
                table: "ProjectDetail",
                column: "ProjectId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectDetail");
        }
    }
}
