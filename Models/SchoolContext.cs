using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace KomgrichApi.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
            
        }
        public DbSet<Students> Student {get;set;}
        public DbSet<universities> universitie {get;set;}
        //public DbSet<StudentsUniversities> StudentsUniversitie {get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>().ToTable("Students");
            modelBuilder.Entity<universities>().ToTable("universities");

            modelBuilder.Entity<Students>()
            .HasMany(St => St.universitie)
            .WithMany(St => St.Student)
            .UsingEntity(j => j.ToTable("StudentsUniversities"));

            //modelBuilder.Entity<StudentsUniversities>().ToTable("StudentsUniversities");
            
            //modelBuilder.Entity<StudentsUniversities>().HasKey(sc => new { sc.StudentId , sc.UniversitieId });
            
        }

        
    }
}