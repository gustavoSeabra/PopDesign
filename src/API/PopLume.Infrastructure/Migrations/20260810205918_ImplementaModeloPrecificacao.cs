using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PopLume.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImplementaModeloPrecificacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoFilamento");

            migrationBuilder.DropIndex(
                name: "IX_Produto_Composicao_IdProdutoPai_IdProdutoFilho",
                table: "Produto_Composicao");

            migrationBuilder.DropColumn(
                name: "PrecoCusto",
                table: "Produto");

            migrationBuilder.AddColumn<Guid>(
                name: "IdProdutoVariacaoFilho",
                table: "Produto_Composicao",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdProdutoVariacao",
                table: "FichaPrecificacao",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ProdutoVariacao",
                columns: table => new
                {
                    IdProdutoVariacao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdProduto = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CodigoInterno = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Ativa = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    PrecoCusto = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoVariacao", x => x.IdProdutoVariacao);
                    table.ForeignKey(
                        name: "FK_ProdutoVariacao_Produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produto",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoVariacaoFilamento",
                columns: table => new
                {
                    IdProdutoVariacaoFilamento = table.Column<Guid>(type: "uuid", nullable: false),
                    IdProdutoVariacao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdFilamento = table.Column<Guid>(type: "uuid", nullable: false),
                    QuantidadeGramas = table.Column<decimal>(type: "numeric(10,3)", precision: 10, scale: 3, nullable: false),
                    PercentualPerda = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoVariacaoFilamento", x => x.IdProdutoVariacaoFilamento);
                    table.ForeignKey(
                        name: "FK_ProdutoVariacaoFilamento_Filamento_IdFilamento",
                        column: x => x.IdFilamento,
                        principalTable: "Filamento",
                        principalColumn: "IdFilamento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdutoVariacaoFilamento_ProdutoVariacao_IdProdutoVariacao",
                        column: x => x.IdProdutoVariacao,
                        principalTable: "ProdutoVariacao",
                        principalColumn: "IdProdutoVariacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Composicao_IdProdutoPai_IdProdutoFilho_IdProdutoVar~",
                table: "Produto_Composicao",
                columns: new[] { "IdProdutoPai", "IdProdutoFilho", "IdProdutoVariacaoFilho" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Composicao_IdProdutoVariacaoFilho",
                table: "Produto_Composicao",
                column: "IdProdutoVariacaoFilho");

            migrationBuilder.CreateIndex(
                name: "IX_FichaPrecificacao_IdProdutoVariacao_CalculadaEmUtc",
                table: "FichaPrecificacao",
                columns: new[] { "IdProdutoVariacao", "CalculadaEmUtc" });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoVariacao_IdProduto_Nome",
                table: "ProdutoVariacao",
                columns: new[] { "IdProduto", "Nome" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoVariacaoFilamento_IdFilamento",
                table: "ProdutoVariacaoFilamento",
                column: "IdFilamento");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoVariacaoFilamento_IdProdutoVariacao_IdFilamento",
                table: "ProdutoVariacaoFilamento",
                columns: new[] { "IdProdutoVariacao", "IdFilamento" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FichaPrecificacao_ProdutoVariacao_IdProdutoVariacao",
                table: "FichaPrecificacao",
                column: "IdProdutoVariacao",
                principalTable: "ProdutoVariacao",
                principalColumn: "IdProdutoVariacao",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Composicao_ProdutoVariacao_IdProdutoVariacaoFilho",
                table: "Produto_Composicao",
                column: "IdProdutoVariacaoFilho",
                principalTable: "ProdutoVariacao",
                principalColumn: "IdProdutoVariacao",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichaPrecificacao_ProdutoVariacao_IdProdutoVariacao",
                table: "FichaPrecificacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Composicao_ProdutoVariacao_IdProdutoVariacaoFilho",
                table: "Produto_Composicao");

            migrationBuilder.DropTable(
                name: "ProdutoVariacaoFilamento");

            migrationBuilder.DropTable(
                name: "ProdutoVariacao");

            migrationBuilder.DropIndex(
                name: "IX_Produto_Composicao_IdProdutoPai_IdProdutoFilho_IdProdutoVar~",
                table: "Produto_Composicao");

            migrationBuilder.DropIndex(
                name: "IX_Produto_Composicao_IdProdutoVariacaoFilho",
                table: "Produto_Composicao");

            migrationBuilder.DropIndex(
                name: "IX_FichaPrecificacao_IdProdutoVariacao_CalculadaEmUtc",
                table: "FichaPrecificacao");

            migrationBuilder.DropColumn(
                name: "IdProdutoVariacaoFilho",
                table: "Produto_Composicao");

            migrationBuilder.DropColumn(
                name: "IdProdutoVariacao",
                table: "FichaPrecificacao");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoCusto",
                table: "Produto",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ProdutoFilamento",
                columns: table => new
                {
                    IdProdutoFilamento = table.Column<Guid>(type: "uuid", nullable: false),
                    IdFilamento = table.Column<Guid>(type: "uuid", nullable: false),
                    IdProduto = table.Column<Guid>(type: "uuid", nullable: false),
                    PercentualPerda = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    QuantidadeGramas = table.Column<decimal>(type: "numeric(10,3)", precision: 10, scale: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoFilamento", x => x.IdProdutoFilamento);
                    table.ForeignKey(
                        name: "FK_ProdutoFilamento_Filamento_IdFilamento",
                        column: x => x.IdFilamento,
                        principalTable: "Filamento",
                        principalColumn: "IdFilamento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdutoFilamento_Produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produto",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Composicao_IdProdutoPai_IdProdutoFilho",
                table: "Produto_Composicao",
                columns: new[] { "IdProdutoPai", "IdProdutoFilho" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoFilamento_IdFilamento",
                table: "ProdutoFilamento",
                column: "IdFilamento");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoFilamento_IdProduto_IdFilamento",
                table: "ProdutoFilamento",
                columns: new[] { "IdProduto", "IdFilamento" },
                unique: true);
        }
    }
}
