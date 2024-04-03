using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AdjustDependantTableIdInCodeRelationshipWithAppointmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Appointments_tbl_ConfirmationCode_IdConfirmationCode",
                table: "tbl_Appointments");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Appointments_IdConfirmationCode",
                table: "tbl_Appointments");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ConfirmationCode_tbl_Appointments_Id",
                table: "tbl_ConfirmationCode",
                column: "Id",
                principalTable: "tbl_Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ConfirmationCode_tbl_Appointments_Id",
                table: "tbl_ConfirmationCode");

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
        }
    }
}
