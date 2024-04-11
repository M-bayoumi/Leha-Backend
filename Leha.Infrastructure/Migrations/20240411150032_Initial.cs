using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leha.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoardMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    PositionAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    PositionEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    Employees = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "Nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardMemberSpeeches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    ContentEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    BoardMemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardMemberSpeeches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardMemberSpeeches_BoardMembers_BoardMemberId",
                        column: x => x.BoardMemberId,
                        principalTable: "BoardMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    AddressEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyAddresses_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageBytes = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeImages_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    TitleEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    DescriptionAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    DescriptionEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    AverageSalary = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    ContentEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    DescriptionAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    DescriptionEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    DescriptionAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    DescriptionEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    AddressAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    AddressEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    SiteEngineerNameAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    SiteEngineerNameEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    ProjectProgressPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servcies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    DescriptionAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    DescriptionEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servcies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servcies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullNameAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    FullNameEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    AddressAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    AddressEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    JobTitleAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    JobTitleEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    CV = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forms_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPhases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPhases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectPhases_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhaseItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    AcumulativePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProgressPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExecutionProgressAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    ExecutionProgressEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    RFIAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    RFIEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    WIRAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    WIREn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    ScheduleAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    ScheduleEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    UnitAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    UnitEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    InitialInventoryQuantities = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ActualInventoryQuantities = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PercentageLossOrExceed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProjectPhaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhaseItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhaseItems_ProjectPhases_ProjectPhaseId",
                        column: x => x.ProjectPhaseId,
                        principalTable: "ProjectPhases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardMemberSpeeches_BoardMemberId",
                table: "BoardMemberSpeeches",
                column: "BoardMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CompanyId",
                table: "Clients",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddresses_CompanyId",
                table: "CompanyAddresses",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_JobId",
                table: "Forms",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeImages_CompanyId",
                table: "HomeImages",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CompanyId",
                table: "Jobs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PhaseItems_ProjectPhaseId",
                table: "PhaseItems",
                column: "ProjectPhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CompanyId",
                table: "Posts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId",
                table: "Products",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPhases_ProjectId",
                table: "ProjectPhases",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CompanyId",
                table: "Projects",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Servcies_CompanyId",
                table: "Servcies",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardMemberSpeeches");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "CompanyAddresses");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "HomeImages");

            migrationBuilder.DropTable(
                name: "PhaseItems");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Servcies");

            migrationBuilder.DropTable(
                name: "BoardMembers");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "ProjectPhases");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
