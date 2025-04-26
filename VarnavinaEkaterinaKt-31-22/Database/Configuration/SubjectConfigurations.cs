using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VarnavinaEkaterinaKt_31_22.DbContext.Helpers;
using VarnavinaEkaterinaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

namespace VarnavinaEkaterinaKt_31_22.DbContext.Configuration
{
    public class SubjectConfigurations : IEntityTypeConfiguration<Subject>
    {
        private const string TableName = "cd_subject";

        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            // Задание первичного ключа
            builder
                .HasKey(p => p.SubjectId)
                .HasName($"pk_{TableName}_subject_id");

            // Для целочисленного первичного ключа задаем автогенерацию
            builder.Property(p => p.SubjectId)
                .ValueGeneratedOnAdd()
                .HasColumnName("subject_id")
                .HasComment("Идентификатор записи предмета");

            // Настройка свойств предмета
            builder.Property(p => p.SubjectName)
                .IsRequired()
                .HasColumnName("c_subject_name")
                .HasColumnType("varchar") // Изменил на varchar
                .HasMaxLength(100)
                .HasComment("Название предмета");

            // Настройка индекса
            builder.HasIndex(p => p.SubjectName, $"idx_{TableName}_subject_name");

            // Автоподгрузка связанной сущности (если есть навигационные свойства)
            // Например, если у вас есть связь с другой сущностью, например, Group:
            // builder.Navigation(p => p.Group)
            //     .AutoInclude();
        }
    }
}