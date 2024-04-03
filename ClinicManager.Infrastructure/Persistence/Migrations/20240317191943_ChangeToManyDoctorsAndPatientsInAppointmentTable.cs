using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToManyDoctorsAndPatientsInAppointmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_Appointments_IdDoctor",
                table: "tbl_Appointments");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Appointments_IdPatient",
                table: "tbl_Appointments");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Appointments_IdDoctor",
                table: "tbl_Appointments",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Appointments_IdPatient",
                table: "tbl_Appointments",
                column: "IdPatient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_Appointments_IdDoctor",
                table: "tbl_Appointments");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Appointments_IdPatient",
                table: "tbl_Appointments");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Appointments_IdDoctor",
                table: "tbl_Appointments",
                column: "IdDoctor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Appointments_IdPatient",
                table: "tbl_Appointments",
                column: "IdPatient",
                unique: true);
        }
    }
}
