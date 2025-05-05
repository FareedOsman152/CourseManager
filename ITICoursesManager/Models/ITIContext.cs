using Microsoft.AspNetCore.Cors.Infrastructure;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ITICoursesManager.Models;

public class ITIContext : IdentityDbContext<AppUser>
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Trainee> Trainees { get; set; }
    public DbSet<CRResult> CRResult { get; set; }

    public ITIContext() : base()
    {
    }
    public ITIContext(DbContextOptions<ITIContext> options) :base(options) 
    {
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //     optionsBuilder.UseSqlServer("Data Source=DESKTOP-LDN11DO;Initial Catalog=ITI_Courses_Manager;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
    //    base.OnConfiguring(optionsBuilder);
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // العلاقة 1:M بين Course و Instructor
        modelBuilder.Entity<Instructor>()
            .HasOne(i => i.Course)
            .WithMany(c => c.Instructors)
            .HasForeignKey(i => i.CourseId);

        // العلاقة 1:M بين CRResult و Trainee
        modelBuilder.Entity<CRResult>()
            .HasOne(cr => cr.Trainee)
            .WithMany(t => t.CRResult)
            .HasForeignKey(cr => cr.TraineeId);

        // العلاقة 1:M بين CRResult و Course
        modelBuilder.Entity<CRResult>()
            .HasOne(cr => cr.Course)
            .WithMany(c => c.CRResult)
            .HasForeignKey(cr => cr.CourseId);
    }
}