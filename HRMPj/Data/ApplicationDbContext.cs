using System;
using System.Collections.Generic;
using System.Text;
using HRMPj.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRMPj.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Query<UserInfo>();

            // modelBuilder.Entity<EmployeeInfo>()
            //.HasOne(i => i.Branch)
            //.WithMany(c => c.EmployeeInfo)
            //.OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Attendance>()
           .HasOne(i => i.EmployeeInfo)
           .WithMany(c => c.Attendance)
           .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EmployeeInfo>()
           .HasOne(i => i.Department)
           .WithMany(c => c.EmployeeInfo)
           .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EmployeeInfo>()
           .HasOne(i => i.Designation)
           .WithMany(c => c.EmployeeInfo)
           .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AllowanceDetail>()
           .HasOne(i => i.Employee)
           .WithMany(c => c.AllowanceDetail)
           .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OverTime>()
           .HasOne(i => i.FromEmployeeInfo)
           .WithMany(t => t.FromOverTimeList)
           .HasForeignKey(m => m.FromEmployeeInfoId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OverTime>()
           .HasOne(m => m.ToEmployeeInfo)
           .WithMany(t => t.ToOverTimeList)
           .HasForeignKey(m => m.ToEmployeeInfoId)
           .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<LeaveRequest>()
          .HasOne(i => i.FromEmployeeInfo)
          .WithMany(t => t.FromLeaveRequest)
          .HasForeignKey(m => m.FromEmployeeInfoId)
          .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LeaveRequest>()
           .HasOne(m => m.ToEmployeeInfo)
           .WithMany(t => t.ToLeaveRequest)
           .HasForeignKey(m => m.ToEmployeeInfoId)
           .OnDelete(DeleteBehavior.Restrict);
          

            modelBuilder.Entity<LeaveRequest>()
           .HasOne(m => m.LeaveType)
           .WithMany(t => t.LeaveRequests)
           .HasForeignKey(m => m.LeaveTypeId)
           .IsRequired(false)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Resign>()
           .HasOne(i => i.FromEmployeeInfo)
           .WithMany(t => t.FromResign)
           .HasForeignKey(m => m.FromEmployeeInfoId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Resign>()
           .HasOne(m => m.ToEmployeeInfo)
           .WithMany(t => t.ToResign)
           .HasForeignKey(m => m.ToEmployeeInfoId)
           .OnDelete(DeleteBehavior.Restrict);

        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<EmployeeInfo> EmployeeInfos { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<AllowanceType> AllowanceTypes { get; set; }
        public DbSet<AllowanceDetail> AllowanceDetails { get; set; }
        public DbSet<OverTime> OverTimes { get; set; }
        public DbSet<OverTimeSetting> OverTimeSettings { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
       
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<BonusType> BonusTypes { get; set; }
        public DbSet<Bonus> Bonuses { get; set; }
        public DbSet<Resign> Resigns { get; set; }
        public DbSet<PayRoll> PayRolls { get; set; }
      
        public DbSet<HRMPj.Models.SearchViewModel> SearchViewModel { get; set; }
        public DbSet<HRMPj.Models.AttendanceSearchViewModel> AttendanceSearchViewModel { get; set; }
        public DbSet<HRMPj.Models.EmpResignViewModel> EmpResignViewModel { get; set; }
     
    }
}
