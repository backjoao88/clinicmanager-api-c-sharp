using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateSpecialityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "tbl_Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "IdSpeciality",
                table: "tbl_Doctors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "tbl_Specialities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecialityArea = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Specialities", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "tbl_Specialities",
                columns: new[] { "Id", "SpecialityArea" },
                values: new object[,]
                {
                    { new Guid("7af055b5-d9a6-4f36-9262-47e3e751fdd1"), 1 },
                    { new Guid("d5ac1811-0940-4714-a7a4-f3daca4f97ed"), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Doctors_IdSpeciality",
                table: "tbl_Doctors",
                column: "IdSpeciality");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Doctors_tbl_Specialities_IdSpeciality",
                table: "tbl_Doctors",
                column: "IdSpeciality",
                principalTable: "tbl_Specialities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Doctors_tbl_Specialities_IdSpeciality",
                table: "tbl_Doctors");

            migrationBuilder.DropTable(
                name: "tbl_Specialities");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Doctors_IdSpeciality",
                table: "tbl_Doctors");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "tbl_Doctors");

            migrationBuilder.DropColumn(
                name: "IdSpeciality",
                table: "tbl_Doctors");
        }
    }
}
