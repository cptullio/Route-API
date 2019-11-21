using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRouteApp.Infrastructure.Persistence.Migrations
{
    public partial class seedfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "A" });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "B" });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "C" });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "D" });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "E" });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "F" });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "G" });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "H" });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "I" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
