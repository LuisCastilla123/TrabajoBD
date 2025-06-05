using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CbMaker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarEntidadUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "academifield_id",
                schema: "dbo",
                table: "tb_languages",
                newName: "academic_field_id");

            migrationBuilder.AlterColumn<long>(
                name: "user_info_id",
                schema: "dbo",
                table: "tb_user_info_languages",
                type: "bigint",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<Guid>(
                name: "language_id",
                schema: "dbo",
                table: "tb_user_info_languages",
                type: "uniqueidentifier",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                schema: "dbo",
                table: "tb_user_info_languages",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LanguageId",
                schema: "dbo",
                table: "tb_languages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tb_work_experience_job_title_id",
                schema: "dbo",
                table: "tb_work_experience",
                column: "job_title_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_work_experience_user_id",
                schema: "dbo",
                table: "tb_work_experience",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_skills_skill_id",
                schema: "dbo",
                table: "tb_user_skills",
                column: "skill_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_skills_user_id",
                schema: "dbo",
                table: "tb_user_skills",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_info_languages_language_id",
                schema: "dbo",
                table: "tb_user_info_languages",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_info_languages_user_info_id",
                schema: "dbo",
                table: "tb_user_info_languages",
                column: "user_info_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_info_languages_UserId",
                schema: "dbo",
                table: "tb_user_info_languages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_info_user_id",
                schema: "dbo",
                table: "tb_user_info",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_languages_academic_field_id",
                schema: "dbo",
                table: "tb_languages",
                column: "academic_field_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_languages_tb_academifields_academic_field_id",
                schema: "dbo",
                table: "tb_languages",
                column: "academic_field_id",
                principalSchema: "dbo",
                principalTable: "tb_academifields",
                principalColumn: "academifield_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_user_info_tb_users_user_id",
                schema: "dbo",
                table: "tb_user_info",
                column: "user_id",
                principalSchema: "dbo",
                principalTable: "tb_users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_user_info_languages_tb_languages_language_id",
                schema: "dbo",
                table: "tb_user_info_languages",
                column: "language_id",
                principalSchema: "dbo",
                principalTable: "tb_languages",
                principalColumn: "external_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_user_info_languages_tb_user_info_user_info_id",
                schema: "dbo",
                table: "tb_user_info_languages",
                column: "user_info_id",
                principalSchema: "dbo",
                principalTable: "tb_user_info",
                principalColumn: "userinfo_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_user_info_languages_tb_users_UserId",
                schema: "dbo",
                table: "tb_user_info_languages",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "tb_users",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_user_skills_tb_skills_skill_id",
                schema: "dbo",
                table: "tb_user_skills",
                column: "skill_id",
                principalSchema: "dbo",
                principalTable: "tb_skills",
                principalColumn: "skill_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_user_skills_tb_users_user_id",
                schema: "dbo",
                table: "tb_user_skills",
                column: "user_id",
                principalSchema: "dbo",
                principalTable: "tb_users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_work_experience_tb_job_titles_job_title_id",
                schema: "dbo",
                table: "tb_work_experience",
                column: "job_title_id",
                principalSchema: "dbo",
                principalTable: "tb_job_titles",
                principalColumn: "jobtitle_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_work_experience_tb_users_user_id",
                schema: "dbo",
                table: "tb_work_experience",
                column: "user_id",
                principalSchema: "dbo",
                principalTable: "tb_users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_languages_tb_academifields_academic_field_id",
                schema: "dbo",
                table: "tb_languages");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_user_info_tb_users_user_id",
                schema: "dbo",
                table: "tb_user_info");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_user_info_languages_tb_languages_language_id",
                schema: "dbo",
                table: "tb_user_info_languages");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_user_info_languages_tb_user_info_user_info_id",
                schema: "dbo",
                table: "tb_user_info_languages");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_user_info_languages_tb_users_UserId",
                schema: "dbo",
                table: "tb_user_info_languages");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_user_skills_tb_skills_skill_id",
                schema: "dbo",
                table: "tb_user_skills");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_user_skills_tb_users_user_id",
                schema: "dbo",
                table: "tb_user_skills");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_work_experience_tb_job_titles_job_title_id",
                schema: "dbo",
                table: "tb_work_experience");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_work_experience_tb_users_user_id",
                schema: "dbo",
                table: "tb_work_experience");

            migrationBuilder.DropIndex(
                name: "IX_tb_work_experience_job_title_id",
                schema: "dbo",
                table: "tb_work_experience");

            migrationBuilder.DropIndex(
                name: "IX_tb_work_experience_user_id",
                schema: "dbo",
                table: "tb_work_experience");

            migrationBuilder.DropIndex(
                name: "IX_tb_user_skills_skill_id",
                schema: "dbo",
                table: "tb_user_skills");

            migrationBuilder.DropIndex(
                name: "IX_tb_user_skills_user_id",
                schema: "dbo",
                table: "tb_user_skills");

            migrationBuilder.DropIndex(
                name: "IX_tb_user_info_languages_language_id",
                schema: "dbo",
                table: "tb_user_info_languages");

            migrationBuilder.DropIndex(
                name: "IX_tb_user_info_languages_user_info_id",
                schema: "dbo",
                table: "tb_user_info_languages");

            migrationBuilder.DropIndex(
                name: "IX_tb_user_info_languages_UserId",
                schema: "dbo",
                table: "tb_user_info_languages");

            migrationBuilder.DropIndex(
                name: "IX_tb_user_info_user_id",
                schema: "dbo",
                table: "tb_user_info");

            migrationBuilder.DropIndex(
                name: "IX_tb_languages_academic_field_id",
                schema: "dbo",
                table: "tb_languages");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "tb_user_info_languages");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "dbo",
                table: "tb_languages");

            migrationBuilder.RenameColumn(
                name: "academic_field_id",
                schema: "dbo",
                table: "tb_languages",
                newName: "academifield_id");

            migrationBuilder.AlterColumn<string>(
                name: "user_info_id",
                schema: "dbo",
                table: "tb_user_info_languages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "language_id",
                schema: "dbo",
                table: "tb_user_info_languages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldMaxLength: 100);
        }
    }
}
