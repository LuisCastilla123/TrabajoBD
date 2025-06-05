using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVMaker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarEntidadUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hashedpassword",
                table: "tb_users");

            migrationBuilder.AddColumn<byte[]>(
                name: "hash_salting",
                table: "tb_users",
                type: "varbinary(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "hashpassword",
                table: "tb_users",
                type: "varbinary(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hash_salting",
                table: "tb_users");

            migrationBuilder.DropColumn(
                name: "hashpassword",
                table: "tb_users");

            migrationBuilder.AddColumn<string>(
                name: "hashedpassword",
                table: "tb_users",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }
    }
}
