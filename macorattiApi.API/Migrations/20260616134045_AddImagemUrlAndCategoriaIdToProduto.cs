using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace macorattiApi.API.Migrations
{
    /// <inheritdoc />
    public partial class AddImagemUrlAndCategoriaIdToProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagmUrl",
                table: "Produtos",
                newName: "ImagemUrl");

            migrationBuilder.RenameColumn(
                name: "ImagmUrl",
                table: "Categorias",
                newName: "ImagemUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagemUrl",
                table: "Produtos",
                newName: "ImagmUrl");

            migrationBuilder.RenameColumn(
                name: "ImagemUrl",
                table: "Categorias",
                newName: "ImagmUrl");
        }
    }
}
