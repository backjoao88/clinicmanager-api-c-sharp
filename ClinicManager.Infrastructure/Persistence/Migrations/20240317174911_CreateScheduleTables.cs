using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateScheduleTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdSchedule",
                table: "tbl_Doctors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "tbl_Schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Schedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ScheduleDay",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSchedule = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ScheduleDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_ScheduleDay_tbl_Schedules_IdSchedule",
                        column: x => x.IdSchedule,
                        principalTable: "tbl_Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Slot",
                columns: table => new
                {
                    ScheduleDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateOnly>(type: "date", nullable: false),
                    IdScheduleDay = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slot", x => new { x.ScheduleDayId, x.Id });
                    table.ForeignKey(
                        name: "FK_Slot_tbl_ScheduleDay_ScheduleDayId",
                        column: x => x.ScheduleDayId,
                        principalTable: "tbl_ScheduleDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Doctors_IdSchedule",
                table: "tbl_Doctors",
                column: "IdSchedule",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ScheduleDay_IdSchedule",
                table: "tbl_ScheduleDay",
                column: "IdSchedule");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Doctors_tbl_Schedules_IdSchedule",
                table: "tbl_Doctors",
                column: "IdSchedule",
                principalTable: "tbl_Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Doctors_tbl_Schedules_IdSchedule",
                table: "tbl_Doctors");

            migrationBuilder.DropTable(
                name: "Slot");

            migrationBuilder.DropTable(
                name: "tbl_ScheduleDay");

            migrationBuilder.DropTable(
                name: "tbl_Schedules");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Doctors_IdSchedule",
                table: "tbl_Doctors");

            migrationBuilder.DropColumn(
                name: "IdSchedule",
                table: "tbl_Doctors");
        }
    }
}
