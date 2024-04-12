﻿// <auto-generated />
using System;
using Leha.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Leha.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240412000518_AddSlogan")]
    partial class AddSlogan
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Leha.Data.Entities.BoardMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("PositionAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("PositionEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BoardMembers", (string)null);
                });

            modelBuilder.Entity("Leha.Data.Entities.BoardMemberSpeech", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoardMemberId")
                        .HasColumnType("int");

                    b.Property<string>("ContentAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("ContentEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("BoardMemberId");

                    b.ToTable("BoardMemberSpeeches", (string)null);
                });

            modelBuilder.Entity("Leha.Data.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Clients", (string)null);
                });

            modelBuilder.Entity("Leha.Data.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<int>("Employees")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("SloganAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("SloganEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies", (string)null);
                });

            modelBuilder.Entity("Leha.Data.Entities.CompanyAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("AddressEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyAddresses", (string)null);
                });

            modelBuilder.Entity("Leha.Data.Entities.Form", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("AddressEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("CV")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("FullNameAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("FullNameEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("JobTitleAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("JobTitleEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("Forms", (string)null);
                });

            modelBuilder.Entity("Leha.Data.Entities.HomeImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("ImageBytes")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("HomeImages", (string)null);
                });

            modelBuilder.Entity("Leha.Data.Entities.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AverageSalary")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("DescriptionAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("DescriptionEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("TitleAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("TitleEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Jobs", (string)null);
                });

            modelBuilder.Entity("Leha.Data.Entities.PhaseItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("ActualInventoryQuantities")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("AcumulativePercentage")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ExecutionProgressAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("ExecutionProgressEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<decimal>("InitialInventoryQuantities")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<decimal>("PercentageLossOrExceed")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("ProgressPercentage")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("ProjectPhaseId")
                        .HasColumnType("int");

                    b.Property<string>("RFIAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("RFIEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("ScheduleAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("ScheduleEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("UnitAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("UnitEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("WIRAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("WIREn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectPhaseId");

                    b.ToTable("PhaseItems", (string)null);
                });

            modelBuilder.Entity("Leha.Data.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("ContentAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("ContentEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Posts", (string)null);
                });

            modelBuilder.Entity("Leha.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("DescriptionEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("Leha.Data.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("AddressEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("DescriptionEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<decimal>("ProjectProgressPercentage")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("SiteEngineerNameAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("SiteEngineerNameEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Projects", (string)null);
                });

            modelBuilder.Entity("Leha.Data.Entities.ProjectPhase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectPhases", (string)null);
                });

            modelBuilder.Entity("Leha.Data.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("DescriptionEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("Nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Servcies", (string)null);
                });

            modelBuilder.Entity("Leha.Data.Entities.BoardMemberSpeech", b =>
                {
                    b.HasOne("Leha.Data.Entities.BoardMember", "BoardMember")
                        .WithMany("BoardMemberSpeeches")
                        .HasForeignKey("BoardMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoardMember");
                });

            modelBuilder.Entity("Leha.Data.Entities.Client", b =>
                {
                    b.HasOne("Leha.Data.Entities.Company", "Company")
                        .WithMany("Clients")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Leha.Data.Entities.CompanyAddress", b =>
                {
                    b.HasOne("Leha.Data.Entities.Company", "Company")
                        .WithMany("CompanyAddresses")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Leha.Data.Entities.Form", b =>
                {
                    b.HasOne("Leha.Data.Entities.Job", "Job")
                        .WithMany("Forms")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Leha.Data.Entities.HomeImage", b =>
                {
                    b.HasOne("Leha.Data.Entities.Company", "Company")
                        .WithMany("HomeImages")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Leha.Data.Entities.Job", b =>
                {
                    b.HasOne("Leha.Data.Entities.Company", "Company")
                        .WithMany("Jobs")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Leha.Data.Entities.PhaseItem", b =>
                {
                    b.HasOne("Leha.Data.Entities.ProjectPhase", "ProjectPhase")
                        .WithMany("PhaseItems")
                        .HasForeignKey("ProjectPhaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectPhase");
                });

            modelBuilder.Entity("Leha.Data.Entities.Post", b =>
                {
                    b.HasOne("Leha.Data.Entities.Company", "Company")
                        .WithMany("Posts")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Leha.Data.Entities.Product", b =>
                {
                    b.HasOne("Leha.Data.Entities.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Leha.Data.Entities.Project", b =>
                {
                    b.HasOne("Leha.Data.Entities.Company", "Company")
                        .WithMany("Projects")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Leha.Data.Entities.ProjectPhase", b =>
                {
                    b.HasOne("Leha.Data.Entities.Project", "Project")
                        .WithMany("ProjectPhases")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Leha.Data.Entities.Service", b =>
                {
                    b.HasOne("Leha.Data.Entities.Company", "Company")
                        .WithMany("Services")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Leha.Data.Entities.BoardMember", b =>
                {
                    b.Navigation("BoardMemberSpeeches");
                });

            modelBuilder.Entity("Leha.Data.Entities.Company", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("CompanyAddresses");

                    b.Navigation("HomeImages");

                    b.Navigation("Jobs");

                    b.Navigation("Posts");

                    b.Navigation("Products");

                    b.Navigation("Projects");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("Leha.Data.Entities.Job", b =>
                {
                    b.Navigation("Forms");
                });

            modelBuilder.Entity("Leha.Data.Entities.Project", b =>
                {
                    b.Navigation("ProjectPhases");
                });

            modelBuilder.Entity("Leha.Data.Entities.ProjectPhase", b =>
                {
                    b.Navigation("PhaseItems");
                });
#pragma warning restore 612, 618
        }
    }
}
