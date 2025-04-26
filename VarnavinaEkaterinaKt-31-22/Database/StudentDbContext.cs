using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using VarnavinaEkaterinaKt_31_22.DbContext.Configuration;
using VarnavinaEkaterinaKt_31_22.Models;

public class StudentDbContext : DbContext
{
    //Добавляем таблицы 
    DbSet<Student> Students { get; set; }
    DbSet<AcademicGroup> AcademicGroups { get; set; }
    DbSet<Performance> Performances { get; set; }
    DbSet<Subject> Subjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Добавляем конфигурации к таблицам 
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new SubjectConfigurations());
        modelBuilder.ApplyConfiguration(new AcademicGroupConfiguration());
        modelBuilder.ApplyConfiguration(new PerformanceConfiguration());
    }

    public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
    {
    }
}