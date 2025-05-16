using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CVMaker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CargarDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_academic_fields",
                columns: table => new
                {
                    academic_field_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    external_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    created_at = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "DateTime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("academic_fields_pkey", x => x.academic_field_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_degrees",
                columns: table => new
                {
                    degreeid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    external_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    created_at = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    updatedat = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("degrees_pkey", x => x.degreeid);
                });

            migrationBuilder.CreateTable(
                name: "tb_job_titles",
                columns: table => new
                {
                    jobtitleid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    external_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    createdat = table.Column<DateTime>(type: "DateTime", nullable: false),
                    updatedat = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("job_titles_pkey", x => x.jobtitleid);
                });

            migrationBuilder.CreateTable(
                name: "tb_languages",
                columns: table => new
                {
                    languageid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    external_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    createdat = table.Column<DateTime>(type: "DateTime", nullable: false),
                    updatedat = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("languages_pkey", x => x.languageid);
                });

            migrationBuilder.CreateTable(
                name: "tb_skills",
                columns: table => new
                {
                    skillid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    external_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    createdat = table.Column<DateTime>(type: "DateTime", nullable: false),
                    updatedat = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("skills_pkey", x => x.skillid);
                });

            migrationBuilder.CreateTable(
                name: "tb_users",
                columns: table => new
                {
                    userid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    external_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    username = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    tag = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    emailconfirmed = table.Column<bool>(type: "bit", nullable: false),
                    phonenumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phonenumberconfirmed = table.Column<bool>(type: "bit", nullable: false),
                    twofactorenabled = table.Column<bool>(type: "bit", nullable: false),
                    hashedpassword = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    createdat = table.Column<DateTime>(type: "DateTime", nullable: false),
                    updatedat_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deletedat = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "tb_academic_history",
                columns: table => new
                {
                    academic_history_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    external_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    institutionname = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    specialty = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    startdate = table.Column<DateTime>(type: "date", nullable: false),
                    enddate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    degreeid = table.Column<long>(type: "bigint", nullable: false),
                    academicfieldid = table.Column<long>(type: "bigint", nullable: false),
                    userid = table.Column<long>(type: "bigint", nullable: false),
                    createdat = table.Column<DateTime>(type: "DateTime", nullable: false),
                    updatedat = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("academic_history_pkey", x => x.academic_history_id);
                    table.ForeignKey(
                        name: "FK_tb_academic_history_tb_academic_fields_academicfieldid",
                        column: x => x.academicfieldid,
                        principalTable: "tb_academic_fields",
                        principalColumn: "academic_field_id");
                    table.ForeignKey(
                        name: "FK_tb_academic_history_tb_degrees_degreeid",
                        column: x => x.degreeid,
                        principalTable: "tb_degrees",
                        principalColumn: "degreeid");
                    table.ForeignKey(
                        name: "FK_tb_academic_history_tb_users_userid",
                        column: x => x.userid,
                        principalTable: "tb_users",
                        principalColumn: "userid");
                });

            migrationBuilder.CreateTable(
                name: "tb_users_info",
                columns: table => new
                {
                    userinfoid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    external_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    addressone = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    addresstwo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    city = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    state = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    zipcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isover18 = table.Column<bool>(type: "bit", nullable: false),
                    iscitizen = table.Column<bool>(type: "bit", nullable: false),
                    userid = table.Column<long>(type: "bigint", nullable: false),
                    createdat = table.Column<DateTime>(type: "DateTime", nullable: false),
                    updatedat = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_info_pkey", x => x.userinfoid);
                    table.ForeignKey(
                        name: "FK_tb_users_info_tb_users_userid",
                        column: x => x.userid,
                        principalTable: "tb_users",
                        principalColumn: "userid");
                });

            migrationBuilder.CreateTable(
                name: "tb_users_skills",
                columns: table => new
                {
                    userskillid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<long>(type: "bigint", nullable: false),
                    skillid = table.Column<long>(type: "bigint", nullable: false),
                    external_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    createdat = table.Column<DateTime>(type: "DateTime", nullable: false),
                    updatedat = table.Column<DateTime>(type: "DateTime", nullable: false),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_skills_pkey", x => x.userskillid);
                    table.ForeignKey(
                        name: "FK_tb_users_skills_tb_skills_skillid",
                        column: x => x.skillid,
                        principalTable: "tb_skills",
                        principalColumn: "skillid");
                    table.ForeignKey(
                        name: "FK_tb_users_skills_tb_users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "tb_users",
                        principalColumn: "userid");
                    table.ForeignKey(
                        name: "FK_tb_users_skills_tb_users_userid",
                        column: x => x.userid,
                        principalTable: "tb_users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workexperiences",
                columns: table => new
                {
                    workexperienceid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    externalid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    enterprisename = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    responsibilities = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    startdate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    enddate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    jobtitleid = table.Column<long>(type: "bigint", nullable: false),
                    userid = table.Column<long>(type: "bigint", nullable: false),
                    createdat = table.Column<DateTime>(type: "DateTime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("workexperiences_pkey", x => x.workexperienceid);
                    table.ForeignKey(
                        name: "FK_workexperiences_tb_job_titles_jobtitleid",
                        column: x => x.jobtitleid,
                        principalTable: "tb_job_titles",
                        principalColumn: "jobtitleid");
                    table.ForeignKey(
                        name: "FK_workexperiences_tb_users_userid",
                        column: x => x.userid,
                        principalTable: "tb_users",
                        principalColumn: "userid");
                });

            migrationBuilder.CreateTable(
                name: "tb_users_info_languages",
                columns: table => new
                {
                    userinfo_language_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    external_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    level = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    userinfoid = table.Column<long>(type: "bigint", nullable: false),
                    languageid = table.Column<long>(type: "bigint", nullable: false),
                    createdat = table.Column<DateTime>(type: "Date", nullable: false),
                    updatedat = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_info_languages_pkey", x => x.userinfo_language_id);
                    table.ForeignKey(
                        name: "FK_tb_users_info_languages_tb_languages_languageid",
                        column: x => x.languageid,
                        principalTable: "tb_languages",
                        principalColumn: "languageid");
                    table.ForeignKey(
                        name: "FK_tb_users_info_languages_tb_users_info_userinfoid",
                        column: x => x.userinfoid,
                        principalTable: "tb_users_info",
                        principalColumn: "userinfoid");
                });

            migrationBuilder.InsertData(
                table: "tb_academic_fields",
                columns: new[] { "academic_field_id", "created_at", "description", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ciencias Sociales", null },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ciencias Naturales", null },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matematicas", null },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ingeneria", null },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tecnologia de la Informacion", null },
                    { 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ciencias de la Salud", null },
                    { 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ciencias de la Educacion", null },
                    { 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Artes", null },
                    { 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ciencias Economicas", null },
                    { 10L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ciencias Politicas", null }
                });

            migrationBuilder.InsertData(
                table: "tb_degrees",
                columns: new[] { "degreeid", "created_at", "description", "updatedat" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primaria", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Secundaria", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Universidad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maestria", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctorado", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tb_job_titles",
                columns: new[] { "jobtitleid", "createdat", "description", "updatedat" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desarrollador de sistemas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Analista de compras", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gerente de Mercado", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Director de Planta", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coordinador de Produccion", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asistente Personal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consultar de Sistemas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arquitecto", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ingeniero electrico", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tb_languages",
                columns: new[] { "languageid", "createdat", "description", "updatedat" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Espanol", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ingles", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frances", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Almenan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Italiano", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "academic_fields_externalid_key",
                table: "tb_academic_fields",
                column: "external_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "academic_history_externalid_key",
                table: "tb_academic_history",
                column: "external_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_academic_history_academicfieldid",
                table: "tb_academic_history",
                column: "academicfieldid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_academic_history_degreeid",
                table: "tb_academic_history",
                column: "degreeid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_academic_history_userid",
                table: "tb_academic_history",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "degrees_externalid_key",
                table: "tb_degrees",
                column: "external_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "job_titles_externalid_key",
                table: "tb_job_titles",
                column: "external_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "languages_externalid_key",
                table: "tb_languages",
                column: "external_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "skills_externalid_key",
                table: "tb_skills",
                column: "external_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "users_externalid_key",
                table: "tb_users",
                column: "external_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_users_info_userid",
                table: "tb_users_info",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "users_info_externalid_key",
                table: "tb_users_info",
                column: "external_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_users_info_languages_languageid",
                table: "tb_users_info_languages",
                column: "languageid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_users_info_languages_userinfoid",
                table: "tb_users_info_languages",
                column: "userinfoid");

            migrationBuilder.CreateIndex(
                name: "users_info_languages_externalid_key",
                table: "tb_users_info_languages",
                column: "external_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_users_skills_skillid",
                table: "tb_users_skills",
                column: "skillid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_users_skills_userid",
                table: "tb_users_skills",
                column: "userid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_users_skills_UserId1",
                table: "tb_users_skills",
                column: "UserId1",
                unique: true,
                filter: "[UserId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "users_skills_externalid_key",
                table: "tb_users_skills",
                column: "external_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_workexperiences_jobtitleid",
                table: "workexperiences",
                column: "jobtitleid");

            migrationBuilder.CreateIndex(
                name: "IX_workexperiences_userid",
                table: "workexperiences",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "workexperiences_externalid_key",
                table: "workexperiences",
                column: "externalid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_academic_history");

            migrationBuilder.DropTable(
                name: "tb_users_info_languages");

            migrationBuilder.DropTable(
                name: "tb_users_skills");

            migrationBuilder.DropTable(
                name: "workexperiences");

            migrationBuilder.DropTable(
                name: "tb_academic_fields");

            migrationBuilder.DropTable(
                name: "tb_degrees");

            migrationBuilder.DropTable(
                name: "tb_languages");

            migrationBuilder.DropTable(
                name: "tb_users_info");

            migrationBuilder.DropTable(
                name: "tb_skills");

            migrationBuilder.DropTable(
                name: "tb_job_titles");

            migrationBuilder.DropTable(
                name: "tb_users");
        }
    }
}
