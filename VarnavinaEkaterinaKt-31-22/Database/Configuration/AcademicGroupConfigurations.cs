using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VarnavinaEkaterinaKt_31_22.DbContext.Helpers;
using VarnavinaEkaterinaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace VarnavinaEkaterinaKt_31_22.DbContext.Configuration
{
    public class AcademicGroupConfiguration : IEntityTypeConfiguration<AcademicGroup>
    {
        private const string TableName = "cd_academic_group";

        public void Configure(EntityTypeBuilder<AcademicGroup> builder)
        {
            // Задание первичного ключа
            builder
                .HasKey(p => p.AcademicGroupId)
                .HasName($"pk_{TableName}_academic_group_id");

            // Для целочисленного первичного ключа задаем автогенерацию
            builder.Property(p => p.AcademicGroupId)
                .ValueGeneratedOnAdd()
                .HasColumnName("academic_group_id")
                .HasComment("Идентификатор записи академической группы");

            // Настройка свойства имени группы
            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("c_group_name")
                .HasColumnType("varchar") // Изменил на varchar
                .HasMaxLength(100)
                .HasComment("Название академической группы");

            // Настройка индекса по имени группы
            builder.HasIndex(p => p.Name, $"idx_{TableName}_group_name");

            // Автоподгрузка связанной сущности (коллекция студентов)
            builder.Navigation(p => p.Students)
                .AutoInclude();
        }
    }
}