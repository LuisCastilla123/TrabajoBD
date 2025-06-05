using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CbMaker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDegreeSeedAndFixRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_academic_histories_tb_academifields_academifield_id",
                schema: "dbo",
                table: "tb_academic_histories");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_academic_histories_tb_degrees_DegreeId1",
                schema: "dbo",
                table: "tb_academic_histories");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_academic_histories_tb_users_UserId1",
                schema: "dbo",
                table: "tb_academic_histories");

            migrationBuilder.DropIndex(
                name: "IX_tb_academic_histories_DegreeId1",
                schema: "dbo",
                table: "tb_academic_histories");

            migrationBuilder.DropIndex(
                name: "IX_tb_academic_histories_UserId1",
                schema: "dbo",
                table: "tb_academic_histories");

            migrationBuilder.DropColumn(
                name: "DegreeId1",
                schema: "dbo",
                table: "tb_academic_histories");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "dbo",
                table: "tb_academic_histories");

            migrationBuilder.RenameColumn(
                name: "academifield_id",
                schema: "dbo",
                table: "tb_academic_histories",
                newName: "academic_field_id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_academic_histories_academifield_id",
                schema: "dbo",
                table: "tb_academic_histories",
                newName: "IX_tb_academic_histories_academic_field_id");

            migrationBuilder.AlterColumn<bool>(
                name: "phone_number_confirmed",
                schema: "dbo",
                table: "tb_users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                schema: "dbo",
                table: "tb_users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<bool>(
                name: "email_confirmed",
                schema: "dbo",
                table: "tb_users",
                type: "bit",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<byte[]>(
                name: "hash_salting",
                schema: "dbo",
                table: "tb_users",
                type: "varbinary(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "tb_degrees",
                keyColumn: "degree_id",
                keyValue: 1L,
                columns: new[] { "created_at", "external_id", "updated_at" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "tb_degrees",
                keyColumn: "degree_id",
                keyValue: 2L,
                columns: new[] { "created_at", "external_id", "updated_at" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "tb_degrees",
                keyColumn: "degree_id",
                keyValue: 3L,
                columns: new[] { "created_at", "external_id", "updated_at" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "tb_degrees",
                keyColumn: "degree_id",
                keyValue: 4L,
                columns: new[] { "created_at", "external_id", "updated_at" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "tb_degrees",
                keyColumn: "degree_id",
                keyValue: 5L,
                columns: new[] { "created_at", "external_id", "updated_at" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.AddForeignKey(
                name: "FK_tb_academic_histories_tb_academifields_academic_field_id",
                schema: "dbo",
                table: "tb_academic_histories",
                column: "academic_field_id",
                principalSchema: "dbo",
                principalTable: "tb_academifields",
                principalColumn: "academifield_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_academic_histories_tb_academifields_academic_field_id",
                schema: "dbo",
                table: "tb_academic_histories");

            migrationBuilder.DropColumn(
                name: "hash_salting",
                schema: "dbo",
                table: "tb_users");

            migrationBuilder.RenameColumn(
                name: "academic_field_id",
                schema: "dbo",
                table: "tb_academic_histories",
                newName: "academifield_id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_academic_histories_academic_field_id",
                schema: "dbo",
                table: "tb_academic_histories",
                newName: "IX_tb_academic_histories_academifield_id");

            migrationBuilder.AlterColumn<double>(
                name: "phone_number_confirmed",
                schema: "dbo",
                table: "tb_users",
                type: "float",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<double>(
                name: "phone_number",
                schema: "dbo",
                table: "tb_users",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "email_confirmed",
                schema: "dbo",
                table: "tb_users",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<long>(
                name: "DegreeId1",
                schema: "dbo",
                table: "tb_academic_histories",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                schema: "dbo",
                table: "tb_academic_histories",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "tb_degrees",
                keyColumn: "degree_id",
                keyValue: 1L,
                columns: new[] { "created_at", "external_id", "updated_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "tb_degrees",
                keyColumn: "degree_id",
                keyValue: 2L,
                columns: new[] { "created_at", "external_id", "updated_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "tb_degrees",
                keyColumn: "degree_id",
                keyValue: 3L,
                columns: new[] { "created_at", "external_id", "updated_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "tb_degrees",
                keyColumn: "degree_id",
                keyValue: 4L,
                columns: new[] { "created_at", "external_id", "updated_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "tb_degrees",
                keyColumn: "degree_id",
                keyValue: 5L,
                columns: new[] { "created_at", "external_id", "updated_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_tb_academic_histories_DegreeId1",
                schema: "dbo",
                table: "tb_academic_histories",
                column: "DegreeId1");

            migrationBuilder.CreateIndex(
                name: "IX_tb_academic_histories_UserId1",
                schema: "dbo",
                table: "tb_academic_histories",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_academic_histories_tb_academifields_academifield_id",
                schema: "dbo",
                table: "tb_academic_histories",
                column: "academifield_id",
                principalSchema: "dbo",
                principalTable: "tb_academifields",
                principalColumn: "academifield_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_academic_histories_tb_degrees_DegreeId1",
                schema: "dbo",
                table: "tb_academic_histories",
                column: "DegreeId1",
                principalSchema: "dbo",
                principalTable: "tb_degrees",
                principalColumn: "degree_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_academic_histories_tb_users_UserId1",
                schema: "dbo",
                table: "tb_academic_histories",
                column: "UserId1",
                principalSchema: "dbo",
                principalTable: "tb_users",
                principalColumn: "user_id");
        }
    }
}
