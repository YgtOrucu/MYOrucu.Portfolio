using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuhsinYigitOrucu.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddAboutTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    AboutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: true),
                    BrandInitials = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    ShortBio = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    AvatarUrl = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    Location = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    EmailAddress = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    GithubUrl = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    LinkedinUrl = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    TwitterUrl = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    TypewriterTitlesJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BioParagraphsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuickInfoJson = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.AboutId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");
        }
    }
}
