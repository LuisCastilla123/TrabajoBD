using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVMaker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Eliminarcampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "addressone",
                table: "tb_users_info");

            migrationBuilder.DropColumn(
                name: "addresstwo",
                table: "tb_users_info");

            migrationBuilder.DropColumn(
                name: "city",
                table: "tb_users_info");

            migrationBuilder.DropColumn(
                name: "iscitizen",
                table: "tb_users_info");

            migrationBuilder.DropColumn(
                name: "isover18",
                table: "tb_users_info");

            migrationBuilder.DropColumn(
                name: "state",
                table: "tb_users_info");

            migrationBuilder.DropColumn(
                name: "zipcode",
                table: "tb_users_info");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "addressone",
                table: "tb_users_info",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "addresstwo",
                table: "tb_users_info",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "tb_users_info",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "iscitizen",
                table: "tb_users_info",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isover18",
                table: "tb_users_info",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "state",
                table: "tb_users_info",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "zipcode",
                table: "tb_users_info",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
