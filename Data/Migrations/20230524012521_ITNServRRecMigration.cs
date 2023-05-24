using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIPorrtabilidadeWebOkPrrojetos.Data.Migrations
{
    /// <inheritdoc />
    public partial class ITNServRRecMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdRecebimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroNf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeRecebimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataDeCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UltimaModificacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdRecebimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdServico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroPo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeOperadora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescricaoPo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaseAtual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UltimaModificacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdServico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItnServRec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrdRec = table.Column<int>(type: "int", nullable: true),
                    IdOrdServ = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UltimaModificacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdOrdRecNavigationId = table.Column<int>(type: "int", nullable: true),
                    IdOrdServNavigationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItnServRec", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItnServRec_OrdRecebimento_IdOrdRecNavigationId",
                        column: x => x.IdOrdRecNavigationId,
                        principalTable: "OrdRecebimento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItnServRec_OrdServico_IdOrdServNavigationId",
                        column: x => x.IdOrdServNavigationId,
                        principalTable: "OrdServico",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItnServRec_IdOrdRecNavigationId",
                table: "ItnServRec",
                column: "IdOrdRecNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ItnServRec_IdOrdServNavigationId",
                table: "ItnServRec",
                column: "IdOrdServNavigationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItnServRec");

            migrationBuilder.DropTable(
                name: "OrdRecebimento");

            migrationBuilder.DropTable(
                name: "OrdServico");
        }
    }
}
