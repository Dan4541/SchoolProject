﻿using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Configurations;
using SchoolProject.Models;

namespace SchoolProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Profesor> Profesors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ClassSchedule> ClassSchedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfigurations());
        }

    }
}
