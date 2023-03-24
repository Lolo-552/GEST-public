using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GEST.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocalmigration599 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatePublished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titleen = table.Column<string>(name: "Title_en", type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriptionen = table.Column<string>(name: "Description_en", type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomePage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutUsHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutUsP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JoinUsHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JoinUsP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AchievementsHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicationsHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagementHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Management",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titleen = table.Column<string>(name: "Title_en", type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriptionen = table.Column<string>(name: "Description_en", type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Management", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescriptionen = table.Column<string>(name: "ShortDescription_en", type: "nvarchar(max)", nullable: false),
                    DatePublished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titleen = table.Column<string>(name: "Title_en", type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriptionen = table.Column<string>(name: "Description_en", type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titleen = table.Column<string>(name: "Title_en", type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriptionen = table.Column<string>(name: "Description_en", type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescriptionen = table.Column<string>(name: "ShortDescription_en", type: "nvarchar(max)", nullable: false),
                    DisplayOnHomePage = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titleen = table.Column<string>(name: "Title_en", type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriptionen = table.Column<string>(name: "Description_en", type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Authors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    NewsId = table.Column<int>(type: "int", nullable: true),
                    AchievementsId = table.Column<int>(type: "int", nullable: true),
                    PagesId = table.Column<int>(type: "int", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Achievements_AchievementsId",
                        column: x => x.AchievementsId,
                        principalTable: "Achievements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Files_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Files_Pages_PagesId",
                        column: x => x.PagesId,
                        principalTable: "Pages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Files_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    NewsId = table.Column<int>(type: "int", nullable: true),
                    AchievementsId = table.Column<int>(type: "int", nullable: true),
                    PagesId = table.Column<int>(type: "int", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Achievements_AchievementsId",
                        column: x => x.AchievementsId,
                        principalTable: "Achievements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Photos_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Photos_Pages_PagesId",
                        column: x => x.PagesId,
                        principalTable: "Pages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Photos_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_AchievementsId",
                table: "Files",
                column: "AchievementsId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_NewsId",
                table: "Files",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_PagesId",
                table: "Files",
                column: "PagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_ProjectId",
                table: "Files",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AchievementsId",
                table: "Photos",
                column: "AchievementsId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_NewsId",
                table: "Photos",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PagesId",
                table: "Photos",
                column: "PagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ProjectId",
                table: "Photos",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "HomePage");

            migrationBuilder.DropTable(
                name: "Management");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
