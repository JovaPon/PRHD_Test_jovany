using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRHD_FULL.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    CaseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PatientId = table.Column<string>(type: "TEXT", nullable: false),
                    EarliestPosiƟveOrderTestSampleCollectedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EarliestPosiƟveOrderTestType = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrderTestCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.CaseId);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryTests",
                columns: table => new
                {
                    OrderTestId = table.Column<string>(type: "TEXT", nullable: false),
                    PatientId = table.Column<string>(type: "TEXT", nullable: false),
                    OrderTestType = table.Column<string>(type: "TEXT", nullable: false),
                    SampleCollectedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrderTestResult = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryTests", x => x.OrderTestId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "LaboratoryTests");
        }
    }
}
