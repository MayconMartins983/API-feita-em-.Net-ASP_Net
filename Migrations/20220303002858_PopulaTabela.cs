using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD_back.Migrations
{
    public partial class PopulaTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Email", "Name", "Tel" },
                values: new object[] { 1, "maycon@gmail.com", "Maycon Martins", 99999999 });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Email", "Name", "Tel" },
                values: new object[] { 2, "Gabi@gmail.com", "Gabi Silva", 88888888 });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Email", "Name", "Tel" },
                values: new object[] { 3, "Maria@gmail.com", "Maria Rosa", 99999999 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
