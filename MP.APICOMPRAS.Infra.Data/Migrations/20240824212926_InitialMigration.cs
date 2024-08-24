using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MP.APICOMPRAS.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pessoa",
                columns: table => new
                {
                    idpessoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    celular = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoa", x => x.idpessoa);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    idproduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codErp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.idproduto);
                });

            migrationBuilder.CreateTable(
                name: "compra",
                columns: table => new
                {
                    idcompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idproduto = table.Column<int>(type: "int", nullable: false),
                    idpessoa = table.Column<int>(type: "int", nullable: false),
                    dataCompra = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compra", x => x.idcompra);
                    table.ForeignKey(
                        name: "FK_compra_pessoa_idpessoa",
                        column: x => x.idpessoa,
                        principalTable: "pessoa",
                        principalColumn: "idpessoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_compra_product_idproduto",
                        column: x => x.idproduto,
                        principalTable: "product",
                        principalColumn: "idproduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_compra_idpessoa",
                table: "compra",
                column: "idpessoa");

            migrationBuilder.CreateIndex(
                name: "IX_compra_idproduto",
                table: "compra",
                column: "idproduto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "compra");

            migrationBuilder.DropTable(
                name: "pessoa");

            migrationBuilder.DropTable(
                name: "product");
        }
    }
}
