﻿// <auto-generated />
using System;
using HRMPj.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HRMPj.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190729081928_test26")]
    partial class test26
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HRMPj.Models.AllowanceDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AllowanceTypeId");

                    b.Property<long>("EmployeeInfoId");

                    b.Property<string>("Month");

                    b.Property<string>("Year");

                    b.HasKey("Id");

                    b.HasIndex("AllowanceTypeId");

                    b.HasIndex("EmployeeInfoId");

                    b.ToTable("AllowanceDetail");
                });

            modelBuilder.Entity("HRMPj.Models.AllowanceType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AmmountPerDay");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("AllowancdType");
                });

            modelBuilder.Entity("HRMPj.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("HRMPj.Models.Attendance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AttendanceDate");

                    b.Property<long>("BranchId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long>("DepartmentId");

                    b.Property<long>("EmployeeInfoId");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeInfoId");

                    b.ToTable("Attendance");
                });

            modelBuilder.Entity("HRMPj.Models.AttendanceSearchViewModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BranchId");

                    b.Property<long>("DepartmentId");

                    b.Property<DateTime>("FromDate");

                    b.Property<DateTime>("ToDate");

                    b.HasKey("Id");

                    b.ToTable("AttendanceSearchViewModel");
                });

            modelBuilder.Entity("HRMPj.Models.Bonus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BonusTypeId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long>("EmployeeInfoId");

                    b.Property<string>("Month");

                    b.Property<string>("Year");

                    b.HasKey("Id");

                    b.HasIndex("BonusTypeId");

                    b.HasIndex("EmployeeInfoId");

                    b.ToTable("Bonus");
                });

            modelBuilder.Entity("HRMPj.Models.BonusType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Amount");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("TypeName");

                    b.Property<string>("Year");

                    b.HasKey("Id");

                    b.ToTable("BonusType");
                });

            modelBuilder.Entity("HRMPj.Models.Branch", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("BranchName");

                    b.Property<long>("CompanyId");

                    b.Property<DateTime>("CreatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Branch");
                });

            modelBuilder.Entity("HRMPj.Models.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName");

                    b.Property<DateTime>("CreatedDate");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("HRMPj.Models.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BranchId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("HRMPj.Models.Designation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long>("DepartmentId");

                    b.Property<string>("Name");

                    b.Property<string>("Remark");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Designation");
                });

            modelBuilder.Entity("HRMPj.Models.Document", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DocumentImagePath");

                    b.Property<long>("EmployeeInfoId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeInfoId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("HRMPj.Models.EmployeeInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ATMNumber");

                    b.Property<long>("AccountNo");

                    b.Property<long>("BasicSalary");

                    b.Property<long>("BranchId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CurrentAddress");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<long>("DepartmentId");

                    b.Property<long>("DesignationId");

                    b.Property<long>("EmergencyNo");

                    b.Property<string>("EmployeeName");

                    b.Property<string>("EmployeeProfile");

                    b.Property<string>("FatherName");

                    b.Property<string>("Gender");

                    b.Property<bool>("IsActive");

                    b.Property<string>("MartialStatus");

                    b.Property<long>("MobilePhone");

                    b.Property<string>("NRC");

                    b.Property<string>("Nationality");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DesignationId");

                    b.ToTable("EmployeeInfo");
                });

            modelBuilder.Entity("HRMPj.Models.LeaveRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CurrentYear");

                    b.Property<string>("Description");

                    b.Property<long>("FromEmployeeInfoId");

                    b.Property<string>("HalfDay");

                    b.Property<DateTime>("LeaveFromDate");

                    b.Property<int>("LeaveRemainDay");

                    b.Property<DateTime>("LeaveToDate");

                    b.Property<decimal>("LeaveTotalDay")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<long?>("LeaveTypeId");

                    b.Property<string>("Status");

                    b.Property<long>("ToEmployeeInfoId");

                    b.Property<string>("UnPaidLeaveStatus");

                    b.HasKey("Id");

                    b.HasIndex("FromEmployeeInfoId");

                    b.HasIndex("LeaveTypeId");

                    b.HasIndex("ToEmployeeInfoId");

                    b.ToTable("LeaveRequest");
                });

            modelBuilder.Entity("HRMPj.Models.LeaveType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long>("ServiceDay");

                    b.Property<string>("TypeName");

                    b.HasKey("Id");

                    b.ToTable("LeaveType");
                });

            modelBuilder.Entity("HRMPj.Models.OverTime", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ApprovedDate");

                    b.Property<long>("FromEmployeeInfoId");

                    b.Property<DateTime>("OTDate");

                    b.Property<DateTime>("OTEndTime");

                    b.Property<DateTime>("OTStartTime");

                    b.Property<int>("OTTime");

                    b.Property<string>("Status");

                    b.Property<long>("ToEmployeeInfoId");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("FromEmployeeInfoId");

                    b.HasIndex("ToEmployeeInfoId");

                    b.ToTable("OverTime");
                });

            modelBuilder.Entity("HRMPj.Models.OverTimeSetting", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Amount");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("Hour");

                    b.Property<string>("Remark");

                    b.HasKey("Id");

                    b.ToTable("OverTimeSetting");
                });

            modelBuilder.Entity("HRMPj.Models.PayRoll", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("BasicSalary")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Bonus")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long>("EmployeeInfoId");

                    b.Property<decimal>("LateDebuct")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("LoanAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Month");

                    b.Property<decimal>("NetPay")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("OTFee")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("PaymentDate");

                    b.Property<decimal>("PenaltyFee")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<bool>("PrintStatus");

                    b.Property<decimal>("Saving")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("TaxFee")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("TotalAllowence")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Year");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeInfoId");

                    b.ToTable("PayRoll");
                });

            modelBuilder.Entity("HRMPj.Models.Resign", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ApprovedDate");

                    b.Property<string>("Comment");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long>("EmployeeInfoId");

                    b.Property<string>("Remark");

                    b.Property<DateTime>("ResignDate");

                    b.Property<string>("ResignStatus");

                    b.Property<string>("Status");

                    b.Property<string>("Year");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeInfoId")
                        .IsUnique();

                    b.ToTable("Resign");
                });

            modelBuilder.Entity("HRMPj.Models.SearchViewModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AttendanceDate");

                    b.Property<long>("BranchId");

                    b.Property<long>("DepartmentId");

                    b.HasKey("Id");

                    b.ToTable("SearchViewModel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HRMPj.Models.AllowanceDetail", b =>
                {
                    b.HasOne("HRMPj.Models.AllowanceType", "AllowanceType")
                        .WithMany("AllowanceDetails")
                        .HasForeignKey("AllowanceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HRMPj.Models.EmployeeInfo", "Employee")
                        .WithMany("AllowanceDetail")
                        .HasForeignKey("EmployeeInfoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HRMPj.Models.Attendance", b =>
                {
                    b.HasOne("HRMPj.Models.EmployeeInfo", "EmployeeInfo")
                        .WithMany("Attendance")
                        .HasForeignKey("EmployeeInfoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HRMPj.Models.Bonus", b =>
                {
                    b.HasOne("HRMPj.Models.BonusType", "BonusType")
                        .WithMany("Bonus")
                        .HasForeignKey("BonusTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HRMPj.Models.EmployeeInfo", "EmployeeInfo")
                        .WithMany("Bonus")
                        .HasForeignKey("EmployeeInfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HRMPj.Models.Branch", b =>
                {
                    b.HasOne("HRMPj.Models.Company", "Company")
                        .WithMany("Branch")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HRMPj.Models.Department", b =>
                {
                    b.HasOne("HRMPj.Models.Branch", "Branch")
                        .WithMany("Department")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HRMPj.Models.Designation", b =>
                {
                    b.HasOne("HRMPj.Models.Department", "Department")
                        .WithMany("Designation")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HRMPj.Models.Document", b =>
                {
                    b.HasOne("HRMPj.Models.EmployeeInfo", "EmployeeInfo")
                        .WithMany("Document")
                        .HasForeignKey("EmployeeInfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HRMPj.Models.EmployeeInfo", b =>
                {
                    b.HasOne("HRMPj.Models.Branch", "Branch")
                        .WithMany("EmployeeInfo")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HRMPj.Models.Department", "Department")
                        .WithMany("EmployeeInfo")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HRMPj.Models.Designation", "Designation")
                        .WithMany("EmployeeInfo")
                        .HasForeignKey("DesignationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HRMPj.Models.LeaveRequest", b =>
                {
                    b.HasOne("HRMPj.Models.EmployeeInfo", "FromEmployeeInfo")
                        .WithMany("FromLeaveRequest")
                        .HasForeignKey("FromEmployeeInfoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HRMPj.Models.LeaveType", "LeaveType")
                        .WithMany("LeaveRequests")
                        .HasForeignKey("LeaveTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HRMPj.Models.EmployeeInfo", "ToEmployeeInfo")
                        .WithMany("ToLeaveRequest")
                        .HasForeignKey("ToEmployeeInfoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HRMPj.Models.OverTime", b =>
                {
                    b.HasOne("HRMPj.Models.EmployeeInfo", "FromEmployeeInfo")
                        .WithMany("FromOverTimeList")
                        .HasForeignKey("FromEmployeeInfoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HRMPj.Models.EmployeeInfo", "ToEmployeeInfo")
                        .WithMany("ToOverTimeList")
                        .HasForeignKey("ToEmployeeInfoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HRMPj.Models.PayRoll", b =>
                {
                    b.HasOne("HRMPj.Models.EmployeeInfo", "EmployeeInfo")
                        .WithMany("PayRoll")
                        .HasForeignKey("EmployeeInfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HRMPj.Models.Resign", b =>
                {
                    b.HasOne("HRMPj.Models.EmployeeInfo", "EmployeeInfo")
                        .WithOne("Resign")
                        .HasForeignKey("HRMPj.Models.Resign", "EmployeeInfoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HRMPj.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HRMPj.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HRMPj.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HRMPj.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
