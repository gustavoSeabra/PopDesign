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
            migrationBuilder.DropColumn(
                name: "ValorHora",
                table: "Equipamento");

            migrationBuilder.DropColumn(
                name: "QuantidadeFilamento",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Filamento");

            migrationBuilder.RenameColumn(
                name: "Comissao",
                table: "TaxasMarketplace",
                newName: "ComissaoPercentual");

            migrationBuilder.RenameColumn(
                name: "TempoImpressao",
                table: "Produto",
                newName: "TempoMaoDeObraMinutos");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Filamento",
                newName: "ValorCompra");

            migrationBuilder.RenameColumn(
                name: "Potencia",
                table: "Equipamento",
                newName: "VidaUtilHoras");

            migrationBuilder.RenameColumn(
                name: "ExpectativaVida",
                table: "Equipamento",
                newName: "PotenciaWatts");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorFinal",
                table: "TaxasMarketplace",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdProdutoPai",
                table: "Produto_Composicao",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdProdutoFilho",
                table: "Produto_Composicao",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdEquipamento",
                table: "Produto",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TempoImpressaoMinutos",
                table: "Produto",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PesoLiquidoGramas",
                table: "Filamento",
                type: "numeric(10,3)",
                precision: 10,
                scale: 3,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CustoDepreciacaoHora",
                table: "Equipamento",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                computedColumnSql: "CASE WHEN \"VidaUtilHoras\" > 0 THEN \"ValorCompra\" / \"VidaUtilHoras\" ELSE 0 END",
                stored: true);

            migrationBuilder.CreateTable(
                name: "CustoMaoDeObra",
                columns: table => new
                {
                    IdCustoMaoDeObra = table.Column<Guid>(type: "uuid", nullable: false),
                    ValorHora = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    InicioVigencia = table.Column<DateOnly>(type: "date", nullable: false),
                    FimVigencia = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustoMaoDeObra", x => x.IdCustoMaoDeObra);
                });

            migrationBuilder.CreateTable(
                name: "Insumo",
                columns: table => new
                {
                    IdInsumo = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ValorCompra = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    QuantidadeComprada = table.Column<decimal>(type: "numeric(12,4)", precision: 12, scale: 4, nullable: false),
                    UnidadeMedida = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Excluido = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DataExclusao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumo", x => x.IdInsumo);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoFilamento",
                columns: table => new
                {
                    IdProdutoFilamento = table.Column<Guid>(type: "uuid", nullable: false),
                    IdProduto = table.Column<Guid>(type: "uuid", nullable: false),
                    IdFilamento = table.Column<Guid>(type: "uuid", nullable: false),
                    QuantidadeGramas = table.Column<decimal>(type: "numeric(10,3)", precision: 10, scale: 3, nullable: false),
                    PercentualPerda = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false)
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

            migrationBuilder.CreateTable(
                name: "TarifaEnergia",
                columns: table => new
                {
                    IdTarifaEnergia = table.Column<Guid>(type: "uuid", nullable: false),
                    ValorKwh = table.Column<decimal>(type: "numeric(10,4)", precision: 10, scale: 4, nullable: false),
                    InicioVigencia = table.Column<DateOnly>(type: "date", nullable: false),
                    FimVigencia = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarifaEnergia", x => x.IdTarifaEnergia);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoInsumo",
                columns: table => new
                {
                    IdProdutoInsumo = table.Column<Guid>(type: "uuid", nullable: false),
                    IdProduto = table.Column<Guid>(type: "uuid", nullable: false),
                    IdInsumo = table.Column<Guid>(type: "uuid", nullable: false),
                    QuantidadeUtilizada = table.Column<decimal>(type: "numeric(12,4)", precision: 12, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoInsumo", x => x.IdProdutoInsumo);
                    table.ForeignKey(
                        name: "FK_ProdutoInsumo_Insumo_IdInsumo",
                        column: x => x.IdInsumo,
                        principalTable: "Insumo",
                        principalColumn: "IdInsumo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdutoInsumo_Produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produto",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FichaPrecificacao",
                columns: table => new
                {
                    IdFichaPrecificacao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdProduto = table.Column<Guid>(type: "uuid", nullable: false),
                    IdEquipamento = table.Column<Guid>(type: "uuid", nullable: false),
                    IdTarifaEnergia = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCustoMaoDeObra = table.Column<Guid>(type: "uuid", nullable: false),
                    IdMarketplace = table.Column<Guid>(type: "uuid", nullable: true),
                    IdTaxaMarketplace = table.Column<Guid>(type: "uuid", nullable: true),
                    CalculadaEmUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    QuantidadeProduzida = table.Column<int>(type: "integer", nullable: false),
                    MargemPercentual = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    ComissaoPercentual = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    TaxaFixa = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    CustoFilamentos = table.Column<decimal>(type: "numeric(14,4)", precision: 14, scale: 4, nullable: false),
                    CustoInsumos = table.Column<decimal>(type: "numeric(14,4)", precision: 14, scale: 4, nullable: false),
                    CustoComponentes = table.Column<decimal>(type: "numeric(14,4)", precision: 14, scale: 4, nullable: false),
                    CustoEnergia = table.Column<decimal>(type: "numeric(14,4)", precision: 14, scale: 4, nullable: false),
                    CustoEquipamento = table.Column<decimal>(type: "numeric(14,4)", precision: 14, scale: 4, nullable: false),
                    CustoMaoDeObra = table.Column<decimal>(type: "numeric(14,4)", precision: 14, scale: 4, nullable: false),
                    CustoTotalLote = table.Column<decimal>(type: "numeric(14,4)", precision: 14, scale: 4, nullable: false),
                    CustoUnitario = table.Column<decimal>(type: "numeric(14,4)", precision: 14, scale: 4, nullable: false),
                    ValorComissao = table.Column<decimal>(type: "numeric(14,4)", precision: 14, scale: 4, nullable: false),
                    LucroUnitario = table.Column<decimal>(type: "numeric(14,4)", precision: 14, scale: 4, nullable: false),
                    PrecoVenda = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaPrecificacao", x => x.IdFichaPrecificacao);
                    table.ForeignKey(
                        name: "FK_FichaPrecificacao_CustoMaoDeObra_IdCustoMaoDeObra",
                        column: x => x.IdCustoMaoDeObra,
                        principalTable: "CustoMaoDeObra",
                        principalColumn: "IdCustoMaoDeObra",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichaPrecificacao_Equipamento_IdEquipamento",
                        column: x => x.IdEquipamento,
                        principalTable: "Equipamento",
                        principalColumn: "IdEquipamento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichaPrecificacao_Marketplace_IdMarketplace",
                        column: x => x.IdMarketplace,
                        principalTable: "Marketplace",
                        principalColumn: "IdMarketplace",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichaPrecificacao_Produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produto",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichaPrecificacao_TarifaEnergia_IdTarifaEnergia",
                        column: x => x.IdTarifaEnergia,
                        principalTable: "TarifaEnergia",
                        principalColumn: "IdTarifaEnergia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichaPrecificacao_TaxasMarketplace_IdTaxaMarketplace",
                        column: x => x.IdTaxaMarketplace,
                        principalTable: "TaxasMarketplace",
                        principalColumn: "IdTaxa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemFichaPrecificacao",
                columns: table => new
                {
                    IdItemFichaPrecificacao = table.Column<Guid>(type: "uuid", nullable: false),
                    IdFichaPrecificacao = table.Column<Guid>(type: "uuid", nullable: false),
                    Tipo = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Quantidade = table.Column<decimal>(type: "numeric(14,4)", precision: 14, scale: 4, nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "numeric(14,4)", precision: 14, scale: 4, nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric(14,4)", precision: 14, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemFichaPrecificacao", x => x.IdItemFichaPrecificacao);
                    table.ForeignKey(
                        name: "FK_ItemFichaPrecificacao_FichaPrecificacao_IdFichaPrecificacao",
                        column: x => x.IdFichaPrecificacao,
                        principalTable: "FichaPrecificacao",
                        principalColumn: "IdFichaPrecificacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_IdEquipamento",
                table: "Produto",
                column: "IdEquipamento");

            migrationBuilder.CreateIndex(
                name: "IX_CustoMaoDeObra_InicioVigencia",
                table: "CustoMaoDeObra",
                column: "InicioVigencia");

            migrationBuilder.CreateIndex(
                name: "IX_FichaPrecificacao_IdCustoMaoDeObra",
                table: "FichaPrecificacao",
                column: "IdCustoMaoDeObra");

            migrationBuilder.CreateIndex(
                name: "IX_FichaPrecificacao_IdEquipamento",
                table: "FichaPrecificacao",
                column: "IdEquipamento");

            migrationBuilder.CreateIndex(
                name: "IX_FichaPrecificacao_IdMarketplace",
                table: "FichaPrecificacao",
                column: "IdMarketplace");

            migrationBuilder.CreateIndex(
                name: "IX_FichaPrecificacao_IdProduto_CalculadaEmUtc",
                table: "FichaPrecificacao",
                columns: new[] { "IdProduto", "CalculadaEmUtc" });

            migrationBuilder.CreateIndex(
                name: "IX_FichaPrecificacao_IdTarifaEnergia",
                table: "FichaPrecificacao",
                column: "IdTarifaEnergia");

            migrationBuilder.CreateIndex(
                name: "IX_FichaPrecificacao_IdTaxaMarketplace",
                table: "FichaPrecificacao",
                column: "IdTaxaMarketplace");

            migrationBuilder.CreateIndex(
                name: "IX_ItemFichaPrecificacao_IdFichaPrecificacao",
                table: "ItemFichaPrecificacao",
                column: "IdFichaPrecificacao");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoFilamento_IdFilamento",
                table: "ProdutoFilamento",
                column: "IdFilamento");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoFilamento_IdProduto_IdFilamento",
                table: "ProdutoFilamento",
                columns: new[] { "IdProduto", "IdFilamento" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoInsumo_IdInsumo",
                table: "ProdutoInsumo",
                column: "IdInsumo");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoInsumo_IdProduto_IdInsumo",
                table: "ProdutoInsumo",
                columns: new[] { "IdProduto", "IdInsumo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TarifaEnergia_InicioVigencia",
                table: "TarifaEnergia",
                column: "InicioVigencia");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Equipamento_IdEquipamento",
                table: "Produto",
                column: "IdEquipamento",
                principalTable: "Equipamento",
                principalColumn: "IdEquipamento",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Equipamento_IdEquipamento",
                table: "Produto");

            migrationBuilder.DropTable(
                name: "ItemFichaPrecificacao");

            migrationBuilder.DropTable(
                name: "ProdutoFilamento");

            migrationBuilder.DropTable(
                name: "ProdutoInsumo");

            migrationBuilder.DropTable(
                name: "FichaPrecificacao");

            migrationBuilder.DropTable(
                name: "Insumo");

            migrationBuilder.DropTable(
                name: "CustoMaoDeObra");

            migrationBuilder.DropTable(
                name: "TarifaEnergia");

            migrationBuilder.DropIndex(
                name: "IX_Produto_IdEquipamento",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "CustoDepreciacaoHora",
                table: "Equipamento");

            migrationBuilder.DropColumn(
                name: "IdEquipamento",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "TempoImpressaoMinutos",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "PesoLiquidoGramas",
                table: "Filamento");

            migrationBuilder.RenameColumn(
                name: "ComissaoPercentual",
                table: "TaxasMarketplace",
                newName: "Comissao");

            migrationBuilder.RenameColumn(
                name: "TempoMaoDeObraMinutos",
                table: "Produto",
                newName: "TempoImpressao");

            migrationBuilder.RenameColumn(
                name: "ValorCompra",
                table: "Filamento",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "VidaUtilHoras",
                table: "Equipamento",
                newName: "Potencia");

            migrationBuilder.RenameColumn(
                name: "PotenciaWatts",
                table: "Equipamento",
                newName: "ExpectativaVida");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorFinal",
                table: "TaxasMarketplace",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdProdutoPai",
                table: "Produto_Composicao",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdProdutoFilho",
                table: "Produto_Composicao",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<decimal>(
                name: "QuantidadeFilamento",
                table: "Produto",
                type: "numeric(8,2)",
                precision: 8,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Peso",
                table: "Filamento",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorHora",
                table: "Equipamento",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                computedColumnSql: "CASE WHEN \"ExpectativaVida\" > 0 THEN \"ValorCompra\" / \"ExpectativaVida\" ELSE 0 END",
                stored: true);
        }
    }
}
