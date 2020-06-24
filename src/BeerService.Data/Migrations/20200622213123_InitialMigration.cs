using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerService.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cervejas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Harmonizacao = table.Column<string>(nullable: true),
                    Cor = table.Column<string>(nullable: true),
                    Categoria = table.Column<string>(nullable: true),
                    Ingredientes = table.Column<string>(nullable: true),
                    TeorAlcoolico = table.Column<decimal>(nullable: false),
                    TemperaturaInicial = table.Column<decimal>(nullable: false),
                    TemperaturaFinal = table.Column<decimal>(nullable: false),
                    Imagem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cervejas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cervejas");
        }
    }
}
