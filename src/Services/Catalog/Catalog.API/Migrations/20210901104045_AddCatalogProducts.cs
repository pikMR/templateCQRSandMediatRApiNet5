using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.API.Migrations
{
    public partial class AddCatalogProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Manufacturer", "Name", "Price" },
                values: new object[] { 1, "Lubricante para gasoil 95 de papa Ardila", "Daniel Lubricantes", "Mas por Mas lubricante 95", 100m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Manufacturer", "Name", "Price" },
                values: new object[] { 2, "Lubricante para gasoil 98 de papa Ardila", "Daniel Lubricantes", "Mas por Mas lubricante 98", 200m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);
        }
    }
}
