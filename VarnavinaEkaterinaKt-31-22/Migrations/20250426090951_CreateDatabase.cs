using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VarnavinaEkaterinaKt_31_22.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicGroups",
                columns: table => new
                {
                    academic_group_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи академической группы")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_group_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название академической группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_academic_group_academic_group_id", x => x.academic_group_id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи предмета")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_subject_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название предмета")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_subject_subject_id", x => x.subject_id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи студента")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_student_firstname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Имя студента"),
                    s_student_lastname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Фамилия студента"),
                    s_student_middlename = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Отчество студента"),
                    group_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи группы"),
                    AcademicGroupId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_student_student_id", x => x.student_id);
                    table.ForeignKey(
                        name: "FK_Students_AcademicGroups_AcademicGroupId",
                        column: x => x.AcademicGroupId,
                        principalTable: "AcademicGroups",
                        principalColumn: "academic_group_id");
                    table.ForeignKey(
                        name: "fk_f_group_id",
                        column: x => x.group_id,
                        principalTable: "AcademicGroups",
                        principalColumn: "academic_group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Performances",
                columns: table => new
                {
                    performance_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи успеваемости")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    student_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор студента"),
                    subject_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор предмета"),
                    grade = table.Column<double>(type: "double precision", nullable: false, comment: "Оценка студента"),
                    is_passed = table.Column<bool>(type: "boolean", nullable: false, comment: "Статус прохождения предмета")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_performance_performance_id", x => x.performance_id);
                    table.ForeignKey(
                        name: "fk_cd_performance_student_id",
                        column: x => x.student_id,
                        principalTable: "Students",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cd_performance_subject_id",
                        column: x => x.subject_id,
                        principalTable: "Subjects",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_academic_group_group_name",
                table: "AcademicGroups",
                column: "c_group_name");

            migrationBuilder.CreateIndex(
                name: "IX_Performances_student_id",
                table: "Performances",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_Performances_subject_id",
                table: "Performances",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_student_fk_f_group_id",
                table: "Students",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AcademicGroupId",
                table: "Students",
                column: "AcademicGroupId");

            migrationBuilder.CreateIndex(
                name: "idx_cd_subject_subject_name",
                table: "Subjects",
                column: "c_subject_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Performances");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "AcademicGroups");
        }
    }
}
