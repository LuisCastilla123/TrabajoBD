using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVMaker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Eliminarresponsabilidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "responsibilities",
                table: "workexperiences");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "responsibilities",
                table: "workexperiences",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }
    }
}
