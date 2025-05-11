using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CbMaker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "tb_academifields",
                schema: "dbo",
                columns: table => new
                {
                    academifield_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    external_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("academifields_pkey", x => x.academifield_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_degrees",
                schema: "dbo",
                columns: table => new
                {
                    degree_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    external_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("degrees_pkey", x => x.degree_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_job_titles",
                schema: "dbo",
                columns: table => new
                {
                    jobtitle_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    external_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("jobtitles_pkey", x => x.jobtitle_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_languages",
                schema: "dbo",
                columns: table => new
                {
                    external_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    academifield_id = table.Column<long>(type: "bigint", nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("languages_pkey", x => x.external_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_skills",
                schema: "dbo",
                columns: table => new
                {
                    skill_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    external_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("skills_pkey", x => x.skill_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_user_info",
                schema: "dbo",
                columns: table => new
                {
                    userinfo_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    external_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    address_one = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    address_two = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    city = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    state = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    zip_code = table.Column<double>(type: "float", nullable: false),
                    is_over_18 = table.Column<bool>(type: "bit", nullable: false),
                    is_citizen = table.Column<bool>(type: "bit", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("userinfo_pkey", x => x.userinfo_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_user_info_languages",
                schema: "dbo",
                columns: table => new
                {
                    external_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    level = table.Column<double>(type: "float", nullable: false),
                    user_info_id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    language_id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("userinfolanguages_pkey", x => x.external_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_user_skills",
                schema: "dbo",
                columns: table => new
                {
                    user_skill_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    skill_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("userskills_pkey", x => x.user_skill_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_users",
                schema: "dbo",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    external_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    tag = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email_confirmed = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    phone_number = table.Column<double>(type: "float", nullable: false),
                    phone_number_confirmed = table.Column<double>(type: "float", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "bit", nullable: false),
                    hash_password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_work_experience",
                schema: "dbo",
                columns: table => new
                {
                    work_experience_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    external_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    enterprise_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    responsibilities = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    job_title_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("workexperience_pkey", x => x.work_experience_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_academic_histories",
                schema: "dbo",
                columns: table => new
                {
                    external_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    institution_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    speciality = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    degree_id = table.Column<long>(type: "bigint", maxLength: 100, nullable: false),
                    academifield_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DegreeId1 = table.Column<long>(type: "bigint", nullable: true),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("academichistories_pkey", x => x.external_id);
                    table.ForeignKey(
                        name: "FK_tb_academic_histories_tb_academifields_academifield_id",
                        column: x => x.academifield_id,
                        principalSchema: "dbo",
                        principalTable: "tb_academifields",
                        principalColumn: "academifield_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_academic_histories_tb_degrees_DegreeId1",
                        column: x => x.DegreeId1,
                        principalSchema: "dbo",
                        principalTable: "tb_degrees",
                        principalColumn: "degree_id");
                    table.ForeignKey(
                        name: "FK_tb_academic_histories_tb_degrees_degree_id",
                        column: x => x.degree_id,
                        principalSchema: "dbo",
                        principalTable: "tb_degrees",
                        principalColumn: "degree_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_academic_histories_tb_users_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "dbo",
                        principalTable: "tb_users",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK_tb_academic_histories_tb_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "dbo",
                        principalTable: "tb_users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "academichistories_externalid_key",
                schema: "dbo",
                table: "tb_academic_histories",
                column: "external_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_academic_histories_academifield_id",
                schema: "dbo",
                table: "tb_academic_histories",
                column: "academifield_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_academic_histories_degree_id",
                schema: "dbo",
                table: "tb_academic_histories",
                column: "degree_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_academic_histories_DegreeId1",
                schema: "dbo",
                table: "tb_academic_histories",
                column: "DegreeId1");

            migrationBuilder.CreateIndex(
                name: "IX_tb_academic_histories_user_id",
                schema: "dbo",
                table: "tb_academic_histories",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_academic_histories_UserId1",
                schema: "dbo",
                table: "tb_academic_histories",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "academifields_externalid_key",
                schema: "dbo",
                table: "tb_academifields",
                column: "external_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "degrees_externalid_key",
                schema: "dbo",
                table: "tb_degrees",
                column: "external_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "jobtitles_externalid_key",
                schema: "dbo",
                table: "tb_job_titles",
                column: "external_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "languages_externalid_key",
                schema: "dbo",
                table: "tb_languages",
                column: "external_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "skills_externalid_key",
                schema: "dbo",
                table: "tb_skills",
                column: "external_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "userinfo_externalid_key",
                schema: "dbo",
                table: "tb_user_info",
                column: "external_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "userinfolanguages_externalid_key",
                schema: "dbo",
                table: "tb_user_info_languages",
                column: "external_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "users_externalid_key",
                schema: "dbo",
                table: "tb_users",
                column: "external_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "workexperience_externalid_key",
                schema: "dbo",
                table: "tb_work_experience",
                column: "external_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_academic_histories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tb_job_titles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tb_languages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tb_skills",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tb_user_info",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tb_user_info_languages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tb_user_skills",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tb_work_experience",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tb_academifields",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tb_degrees",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tb_users",
                schema: "dbo");
        }
    }
}
