using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CbMaker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CargaDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tb_degrees",
                columns: new[] { "degree_id", "created_at", "description", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primaria", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Secundaria", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Universidad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maestría", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctorado", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tb_job_titles",
                columns: new[] { "jobtitle_id", "created_at", "description", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desarrollador de sistemas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Analista de compras", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gerente de mercado", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Director de planta", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coordinador", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asistente personal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consultor de sistemas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arquitecto", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ingeniero eléctrico", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_degrees",
                keyColumn: "degree_id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_degrees",
                keyColumn: "degree_id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_degrees",
                keyColumn: "degree_id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_degrees",
                keyColumn: "degree_id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_degrees",
                keyColumn: "degree_id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_job_titles",
                keyColumn: "jobtitle_id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_job_titles",
                keyColumn: "jobtitle_id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_job_titles",
                keyColumn: "jobtitle_id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_job_titles",
                keyColumn: "jobtitle_id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_job_titles",
                keyColumn: "jobtitle_id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_job_titles",
                keyColumn: "jobtitle_id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_job_titles",
                keyColumn: "jobtitle_id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_job_titles",
                keyColumn: "jobtitle_id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tb_job_titles",
                keyColumn: "jobtitle_id",
                keyValue: 9L);
        }
    }
}
