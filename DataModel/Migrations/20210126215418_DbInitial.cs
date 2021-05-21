using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataModel.Migrations
{
    public partial class DbInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculoHistorico",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCriacao = table.Column<DateTime>(nullable: true),
                    ValorPrimario = table.Column<decimal>(nullable: true),
                    Operacao = table.Column<int>(nullable: true),
                    ValorSecundario = table.Column<decimal>(nullable: true),
                    Resultado = table.Column<decimal>(nullable: true),
                    Usuario = table.Column<string>(nullable: true),
                    Calculo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculoHistorico", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalculoHistorico_Id",
                table: "CalculoHistorico",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculoHistorico");
        }
    }
}
