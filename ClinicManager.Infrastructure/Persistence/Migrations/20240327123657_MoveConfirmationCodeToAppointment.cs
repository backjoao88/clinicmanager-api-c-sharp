using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MoveConfirmationCodeToAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ConfirmationCode_tbl_Patients_IdPatient",
                table: "tbl_ConfirmationCode");

            migrationBuilder.DropIndex(
                name: "IX_tbl_ConfirmationCode_IdPatient",
                table: "tbl_ConfirmationCode");

            migrationBuilder.AddColumn<Guid>(
                name: "PatientId",
                table: "tbl_ConfirmationCode",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdConfirmationCode",
                table: "tbl_Appointments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ConfirmationCode_PatientId",
                table: "tbl_ConfirmationCode",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Appointments_IdConfirmationCode",
                table: "tbl_Appointments",
                column: "IdConfirmationCode",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Appointments_tbl_ConfirmationCode_IdConfirmationCode",
                table: "tbl_Appointments",
                column: "IdConfirmationCode",
                principalTable: "tbl_ConfirmationCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ConfirmationCode_tbl_Patients_PatientId",
                table: "tbl_ConfirmationCode",
                column: "PatientId",
                principalTable: "tbl_Patients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Appointments_tbl_ConfirmationCode_IdConfirmationCode",
                table: "tbl_Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ConfirmationCode_tbl_Patients_PatientId",
                table: "tbl_ConfirmationCode");

            migrationBuilder.DropIndex(
                name: "IX_tbl_ConfirmationCode_PatientId",
                table: "tbl_ConfirmationCode");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Appointments_IdConfirmationCode",
                table: "tbl_Appointments");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "tbl_ConfirmationCode");

            migrationBuilder.DropColumn(
                name: "IdConfirmationCode",
                table: "tbl_Appointments");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ConfirmationCode_IdPatient",
                table: "tbl_ConfirmationCode",
                column: "IdPatient");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ConfirmationCode_tbl_Patients_IdPatient",
                table: "tbl_ConfirmationCode",
                column: "IdPatient",
                principalTable: "tbl_Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
