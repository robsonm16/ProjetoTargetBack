using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TargetApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbCliente",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nome = table.Column<string>(maxLength: 300, nullable: true),
                    endereco = table.Column<string>(maxLength: 200, nullable: true),
                    numero = table.Column<string>(maxLength: 10, nullable: true),
                    bairro = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbCliente");
        }
    }
}
