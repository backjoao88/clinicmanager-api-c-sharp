using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangePropertiesRequirementsAtSlotsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slots");

            migrationBuilder.CreateTable(
                name: "tbl_Slots",
                columns: table => new
                {
                    ScheduleDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdScheduleDay = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Start = table.Column<TimeOnly>(type: "time", nullable: false),
                    End = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Slots", x => new { x.ScheduleDayId, x.Id });
                    table.ForeignKey(
                        name: "FK_tbl_Slots_tbl_ScheduleDay_ScheduleDayId",
                        column: x => x.ScheduleDayId,
                        principalTable: "tbl_ScheduleDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Slots");

            migrationBuilder.CreateTable(
                name: "Slots",
                columns: table => new
                {
                    ScheduleDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    End = table.Column<TimeOnly>(type: "time", nullable: false),
                    IdScheduleDay = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Start = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slots", x => new { x.ScheduleDayId, x.Id });
                    table.ForeignKey(
                        name: "FK_Slots_tbl_ScheduleDay_ScheduleDayId",
                        column: x => x.ScheduleDayId,
                        principalTable: "tbl_ScheduleDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
