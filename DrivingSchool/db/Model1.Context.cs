﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DrivingSchool.db
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DrivingSchoolDBEntities1 : DbContext
    {
        public DrivingSchoolDBEntities1()
            : base("name=DrivingSchoolDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Absences> Absences { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Discounts> Discounts { get; set; }
        public virtual DbSet<DrivingCategories> DrivingCategories { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Grades> Grades { get; set; }
        public virtual DbSet<Instructors> Instructors { get; set; }
        public virtual DbSet<MaintenanceHistory> MaintenanceHistory { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<Vehicles> Vehicles { get; set; }
    }
}