using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VarnavinaEkaterinaKt_31_22.DbContext.Helpers;
using VarnavinaEkaterinaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace VarnavinaEkaterinaKt_31_22.DbContext.Configuration
{
    public class PerformanceConfiguration : IEntityTypeConfiguration<Performance>
    {
        private const string TableName = "cd_performance";

        public void Configure(EntityTypeBuilder<Performance> builder)
        {
            builder.HasKey(p => p.PerformanceId)
                .HasName($"pk_{TableName}_performance_id");

            builder.Property(p => p.PerformanceId)
                .ValueGeneratedOnAdd()
                .HasColumnName("performance_id")
                .HasComment("Идентификатор записи успеваемости");

            builder.Property(p => p.StudentId)
                .IsRequired()
                .HasColumnName("student_id")
                .HasComment("Идентификатор студента");

            builder.Property(p => p.SubjectId)
                .IsRequired()
                .HasColumnName("subject_id")
                .HasComment("Идентификатор предмета");

            builder.Property(p => p.Grade)
                .IsRequired()
                .HasColumnName("grade")
                .HasComment("Оценка студента");

            builder.Property(p => p.IsPassed)
                .IsRequired()
                .HasColumnName("is_passed")
                .HasComment("Статус прохождения предмета");

            builder.HasOne(p => p.Student)
                .WithMany(s => s.Performances)
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName($"fk_{TableName}_student_id");

            builder.HasOne(p => p.Subject)
                .WithMany(s => s.Performances) // Обратная навигация
                .HasForeignKey(p => p.SubjectId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName($"fk_{TableName}_subject_id");
        }
    }

}