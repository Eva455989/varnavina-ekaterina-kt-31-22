using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VarnavinaEkaterinaKt_31_22.DbContext.Helpers;
using VarnavinaEkaterinaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

namespace VarnavinaEkaterinaKt_31_22.DbContext.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string TableName = "cd_student";

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // Задание первичного ключа
            builder
                .HasKey(p => p.StudentId)
                .HasName($"pk_{TableName}_student_id");

            // Для целочисленного первичного ключа задаем автогенерацию
            builder.Property(p => p.StudentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("student_id")
                .HasComment("Идентификатор записи студента");

            // Настройка свойств студента
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_student_firstname")
                .HasColumnType("varchar") // Изменил на varchar
                .HasMaxLength(100)
                .HasComment("Имя студента");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("s_student_lastname")
                .HasColumnType("varchar") // Изменил на varchar
                .HasMaxLength(100)
                .HasComment("Фамилия студента");

            builder.Property(p => p.MiddleName)
                .IsRequired()
                .HasColumnName("s_student_middlename")
                .HasColumnType("varchar") // Изменил на varchar
                .HasMaxLength(100)
                .HasComment("Отчество студента");

            builder.Property(p => p.GroupID)
                .HasColumnName("group_id")
                .HasComment("Идентификатор записи группы");

            // Настройка внешнего ключа и навигационного свойства
            builder
                .HasOne(p => p.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupID) // Исправлено на GroupID
                .HasConstraintName("fk_f_group_id")
                .OnDelete(DeleteBehavior.Cascade);

            // Настройка индекса
            builder.HasIndex(p => p.GroupID, $"idx_{TableName}_fk_f_group_id");

            // Автоподгрузка связанной сущности
            builder.Navigation(p => p.Group)
                .AutoInclude();
        }
    }
}
