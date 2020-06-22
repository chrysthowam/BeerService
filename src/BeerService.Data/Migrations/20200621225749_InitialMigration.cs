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
                    TeorAlcoolico = table.Column<decimal>(nullable: false),
                    Ingredientes = table.Column<string>(nullable: true),
                    TemperaturaInicial = table.Column<decimal>(nullable: false),
                    TemperaturaFinal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cervejas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Imagens",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Caminho = table.Column<string>(nullable: true),
                    CervejaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imagens_Cervejas_CervejaId",
                        column: x => x.CervejaId,
                        principalTable: "Cervejas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imagens_CervejaId",
                table: "Imagens",
                column: "CervejaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imagens");

            migrationBuilder.DropTable(
                name: "Cervejas");
        }
    }
}
