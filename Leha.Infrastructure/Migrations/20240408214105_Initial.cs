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
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardMemberName = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    BoardMemberImage = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    BoardMemberPosition = table.Column<string>(type: "Nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardMembers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    CompanyEmployees = table.Column<int>(type: "int", nullable: false),
                    CompanyImage = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    CompanyEmail = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    CompanyPhone = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    CompanyLink = table.Column<string>(type: "Nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BoardMemberSpeeches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardMemberSpeechContent = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    BoardMemberID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardMemberSpeeches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BoardMemberSpeeches_BoardMembers_BoardMemberID",
                        column: x => x.BoardMemberID,
                        principalTable: "BoardMembers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientNameAr = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    ClientNameEn = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    ClientImage = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Clients_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyAddresses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAddresses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CompanyAddresses_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeImages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeImageBytes = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HomeImages_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitle = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    JobDescription = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    JobAverageSalary = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    JobDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Jobs_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostContent = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    PostImage = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    PostDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Posts_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    ProductImage = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    ProjectDescription = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    ProjectAddress = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    ProjectImage = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    SiteEngineerName = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    ProjectProgressPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projects_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servcies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    ServiceDescription = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    ServiceImage = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servcies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Servcies_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormFullName = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    FormAddress = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    FormJobTitle = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    FormCV = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    FormDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    JobID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Forms_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPhases",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectPhaseName = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPhases", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectPhases_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhaseItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhaseItemNumber = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    PhaseItemName = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    AcumulativePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProgressPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExecutionProgress = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    RFI = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    WIR = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    Schedule = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "Nvarchar(max)", nullable: false),
                    InitialInventoryQuantities = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ActualInventoryQuantities = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PercentageLossOrExceed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProjectPhaseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhaseItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PhaseItems_ProjectPhases_ProjectPhaseID",
                        column: x => x.ProjectPhaseID,
                        principalTable: "ProjectPhases",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardMemberSpeeches_BoardMemberID",
                table: "BoardMemberSpeeches",
                column: "BoardMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CompanyID",
                table: "Clients",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddresses_CompanyID",
                table: "CompanyAddresses",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_JobID",
                table: "Forms",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_HomeImages_CompanyID",
                table: "HomeImages",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CompanyID",
                table: "Jobs",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_PhaseItems_ProjectPhaseID",
                table: "PhaseItems",
                column: "ProjectPhaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CompanyID",
                table: "Posts",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyID",
                table: "Products",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPhases_ProjectID",
                table: "ProjectPhases",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CompanyID",
                table: "Projects",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Servcies_CompanyID",
                table: "Servcies",
                column: "CompanyID");
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
