using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolSystem_Labb3.Models;

public partial class SchoolsystemContext : DbContext
{
    public SchoolsystemContext()
    {
    }

    public SchoolsystemContext(DbContextOptions<SchoolsystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffCourse> StaffCourses { get; set; }

    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Department> Departments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Schoolsystem;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.ToTable("Class");

            entity.Property(e => e.ClassId).ValueGeneratedNever();
            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__C92D71872410840C");

            entity.ToTable("Course");

            entity.Property(e => e.CourseName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK_Department");
            
                entity.ToTable("Department");

            entity.Property(e => e.DepartmentName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.Property(e => e.GradeId).HasColumnName("GradeID");
            entity.Property(e => e.Dates).HasColumnType("datetime");
            entity.Property(e => e.FkcourseId).HasColumnName("FKCourseId");
            entity.Property(e => e.FkstaffId).HasColumnName("FKStaffId");
            entity.Property(e => e.FkstudentId).HasColumnName("FKStudentId");
            entity.Property(e => e.Grade1)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("Grade");

            entity.HasOne(d => d.Fkcourse).WithMany(p => p.Grades)
                .HasForeignKey(d => d.FkcourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grades_Course");

            entity.HasOne(d => d.Fkstudent).WithMany(p => p.Grades)
                .HasForeignKey(d => d.FkstudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grades_Student");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AAF75B0C0CB9");

            entity.Property(e => e.StaffId)
                .ValueGeneratedNever()
                .HasColumnName("StaffID");
            entity.Property(e => e.EmploymentYear).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FKDepartmentId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("FKDepartmentId");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Position)
                .HasMaxLength(30)
                .IsUnicode(false);

        });

        modelBuilder.Entity<StaffCourse>(entity =>
        {
            entity.ToTable("StaffCourse");

            entity.Property(e => e.FkcourseId).HasColumnName("FKCourseId");
            entity.Property(e => e.FkstaffId).HasColumnName("FKStaffId");

            entity.HasOne(d => d.Fkcourse).WithMany(p => p.StaffCourses)
                .HasForeignKey(d => d.FkcourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StaffCourse_Course");

            entity.HasOne(d => d.Fkstaff).WithMany(p => p.StaffCourses)
                .HasForeignKey(d => d.FkstaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StaffCourse_Staff");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentID).HasName("PK__Student__32C52A799F5CDCFF");

            entity.ToTable("Student");

            entity.Property(e => e.StudentID).ValueGeneratedNever();
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FkclassId).HasColumnName("FKClassId");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pnumber).HasColumnName("PNumber");

            entity.HasOne(d => d.Fkclass).WithMany(p => p.Students)
                .HasForeignKey(d => d.FkclassId)
                .HasConstraintName("FK_Student_Class");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    
}
