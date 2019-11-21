using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRouteApp.Infrastructure.Persistence.Migrations
{
    public partial class seedroutefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Cost", "DestinationPointId", "OriginalPointId", "Time" },
                values: new object[] { 1, 20, 3, 1, 1 });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Cost", "DestinationPointId", "OriginalPointId", "Time" },
                values: new object[] { 2, 10, 8, 1, 1 });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Cost", "DestinationPointId", "OriginalPointId", "Time" },
                values: new object[] { 3, 30, 5, 1, 5 });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Cost", "DestinationPointId", "OriginalPointId", "Time" },
                values: new object[] { 4, 12, 2, 3, 1 });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Cost", "DestinationPointId", "OriginalPointId", "Time" },
                values: new object[] { 5, 1, 5, 8, 30 });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Cost", "DestinationPointId", "OriginalPointId", "Time" },
                values: new object[] { 6, 5, 4, 5, 3 });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Cost", "DestinationPointId", "OriginalPointId", "Time" },
                values: new object[] { 7, 50, 6, 4, 4 });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Cost", "DestinationPointId", "OriginalPointId", "Time" },
                values: new object[] { 8, 50, 9, 6, 45 });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Cost", "DestinationPointId", "OriginalPointId", "Time" },
                values: new object[] { 9, 50, 8, 6, 40 });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Cost", "DestinationPointId", "OriginalPointId", "Time" },
                values: new object[] { 10, 73, 2, 7, 64 });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Cost", "DestinationPointId", "OriginalPointId", "Time" },
                values: new object[] { 11, 73, 2, 9, 64 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
