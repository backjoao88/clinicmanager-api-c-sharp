using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateManyToOneRelationScheduleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Doctors_tbl_Schedules_IdSchedule",
                table: "tbl_Doctors");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Doctors_IdSchedule",
                table: "tbl_Doctors");

            migrationBuilder.DropColumn(
                name: "IdSchedule",
                table: "tbl_Doctors");

            migrationBuilder.AddColumn<Guid>(
                name: "IdDoctor",
                table: "tbl_Schedules",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Schedules_IdDoctor",
                table: "tbl_Schedules",
                column: "IdDoctor");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Schedules_tbl_Doctors_IdDoctor",
                table: "tbl_Schedules",
                column: "IdDoctor",
                principalTable: "tbl_Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Schedules_tbl_Doctors_IdDoctor",
                table: "tbl_Schedules");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Schedules_IdDoctor",
                table: "tbl_Schedules");

            migrationBuilder.DropColumn(
                name: "IdDoctor",
                table: "tbl_Schedules");

            migrationBuilder.AddColumn<Guid>(
                name: "IdSchedule",
                table: "tbl_Doctors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Doctors_IdSchedule",
                table: "tbl_Doctors",
                column: "IdSchedule",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Doctors_tbl_Schedules_IdSchedule",
                table: "tbl_Doctors",
                column: "IdSchedule",
                principalTable: "tbl_Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
