using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVMaker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExtenderModelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_users_skills_tb_users_UserId1",
                table: "tb_users_skills");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_users_skills_tb_users_userid",
                table: "tb_users_skills");

            migrationBuilder.DropIndex(
                name: "IX_tb_users_skills_userid",
                table: "tb_users_skills");

            migrationBuilder.DropIndex(
                name: "IX_tb_users_skills_UserId1",
                table: "tb_users_skills");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "tb_users_skills");

            migrationBuilder.RenameColumn(
                name: "startdate",
                table: "workexperiences",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "enddate",
                table: "workexperiences",
                newName: "end_date");

            migrationBuilder.AlterColumn<long>(
                name: "jobtitleid",
                table: "workexperiences",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "workexperiences",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "about",
                table: "tb_users_info",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "tb_users_info",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_tb_users_skills_userid",
                table: "tb_users_skills",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_users_skills_tb_users_userid",
                table: "tb_users_skills",
                column: "userid",
                principalTable: "tb_users",
                principalColumn: "userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_users_skills_tb_users_userid",
                table: "tb_users_skills");

            migrationBuilder.DropIndex(
                name: "IX_tb_users_skills_userid",
                table: "tb_users_skills");

            migrationBuilder.DropColumn(
                name: "description",
                table: "workexperiences");

            migrationBuilder.DropColumn(
                name: "about",
                table: "tb_users_info");

            migrationBuilder.DropColumn(
                name: "location",
                table: "tb_users_info");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "workexperiences",
                newName: "startdate");

            migrationBuilder.RenameColumn(
                name: "end_date",
                table: "workexperiences",
                newName: "enddate");

            migrationBuilder.AlterColumn<long>(
                name: "jobtitleid",
                table: "workexperiences",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "tb_users_skills",
                type: "bigint",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_tb_users_skills_tb_users_UserId1",
                table: "tb_users_skills",
                column: "UserId1",
                principalTable: "tb_users",
                principalColumn: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_users_skills_tb_users_userid",
                table: "tb_users_skills",
                column: "userid",
                principalTable: "tb_users",
                principalColumn: "userid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
