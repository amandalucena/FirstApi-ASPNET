using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace macorattiApi.API.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Nome", "Descricao", "ImagmUrl", "Preco", "Estoque", "DataCadastro", "CategoriaId" },
                values: new object[,]
                {
                    { 1, "Coca-Cola", "Refrigerante de cola 350ml", "coca.jpg", 5.45m, 50f, new DateTime(2026, 6, 15), 1 },
                    { 2, "Hamburguer", "Hamburguer artesanal", "hamburguer.jpg", 18.90m, 20f, new DateTime(2026, 6, 15), 2 },
                    { 3, "Pudim", "Pudim de leite", "pudim.jpg", 7.50m, 15f, new DateTime(2026, 6, 15), 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "Produtos", keyColumn: "Id", keyValue: 1);
            migrationBuilder.DeleteData(table: "Produtos", keyColumn: "Id", keyValue: 2);
            migrationBuilder.DeleteData(table: "Produtos", keyColumn: "Id", keyValue: 3);
        }
    }
}
