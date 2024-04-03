﻿// <auto-generated />
using System;
using ClinicManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240327125545_AdjustDependantTableIdInCodeRelationshipWithAppointmentTable")]
    partial class AdjustDependantTableIdInCodeRelationshipWithAppointmentTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.1.24081.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClinicManager.Domain.Core.Appointments.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdConfirmationCode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdDoctor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPatient")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.ToTable("tbl_Appointments", (string)null);
                });

            modelBuilder.Entity("ClinicManager.Domain.Core.Doctors.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbl_Doctors", (string)null);
                });

            modelBuilder.Entity("ClinicManager.Domain.Core.Doctors.Schedules.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdDoctor")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdDoctor");

                    b.ToTable("tbl_Schedules", (string)null);
                });

            modelBuilder.Entity("ClinicManager.Domain.Core.Doctors.Schedules.ScheduleDay", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("Day")
                        .HasColumnType("date");

                    b.Property<Guid>("IdSchedule")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdSchedule");

                    b.ToTable("tbl_ScheduleDay", (string)null);
                });

            modelBuilder.Entity("ClinicManager.Domain.Core.Patients.ConfirmationCode", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Code")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdAppointment")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("tbl_ConfirmationCode", (string)null);
                });

            modelBuilder.Entity("ClinicManager.Domain.Core.Patients.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbl_Patients", (string)null);
                });

            modelBuilder.Entity("ClinicManager.Domain.Core.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tbl_Users", (string)null);
                });

            modelBuilder.Entity("ClinicManager.Domain.Core.Appointments.Appointment", b =>
                {
                    b.HasOne("ClinicManager.Domain.Core.Doctors.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("IdDoctor")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ClinicManager.Domain.Core.Patients.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("IdPatient")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("ClinicManager.Domain.Core.Doctors.Schedules.Schedule", b =>
                {
                    b.HasOne("ClinicManager.Domain.Core.Doctors.Doctor", null)
                        .WithMany("Schedules")
                        .HasForeignKey("IdDoctor")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ClinicManager.Domain.Core.Doctors.Schedules.ScheduleDay", b =>
                {
                    b.HasOne("ClinicManager.Domain.Core.Doctors.Schedules.Schedule", null)
                        .WithMany("Days")
                        .HasForeignKey("IdSchedule")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsMany("ClinicManager.Domain.Core.Doctors.Schedules.BusySlot", "BusySlots", b1 =>
                        {
                            b1.Property<Guid>("ScheduleDayId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<TimeOnly>("End")
                                .HasColumnType("time");

                            b1.Property<TimeOnly>("Start")
                                .HasColumnType("time");

                            b1.HasKey("ScheduleDayId", "Id");

                            b1.ToTable("tbl_BusySlots", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ScheduleDayId");
                        });

                    b.Navigation("BusySlots");
                });

            modelBuilder.Entity("ClinicManager.Domain.Core.Patients.ConfirmationCode", b =>
                {
                    b.HasOne("ClinicManager.Domain.Core.Appointments.Appointment", null)
                        .WithOne("ConfirmationCode")
                        .HasForeignKey("ClinicManager.Domain.Core.Patients.ConfirmationCode", "Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ClinicManager.Domain.Core.Patients.Patient", null)
                        .WithMany("ConfirmationCodes")
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("ClinicManager.Domain.Core.Appointments.Appointment", b =>
                {
                    b.Navigation("ConfirmationCode")
                        .IsRequired();
                });

            modelBuilder.Entity("ClinicManager.Domain.Core.Doctors.Doctor", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("ClinicManager.Domain.Core.Doctors.Schedules.Schedule", b =>
                {
                    b.Navigation("Days");
                });

            modelBuilder.Entity("ClinicManager.Domain.Core.Patients.Patient", b =>
                {
                    b.Navigation("ConfirmationCodes");
                });
#pragma warning restore 612, 618
        }
    }
}
