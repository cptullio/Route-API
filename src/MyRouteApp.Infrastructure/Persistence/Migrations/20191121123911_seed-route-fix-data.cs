using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRouteApp.Infrastructure.Persistence.Migrations
{
    public partial class seedroutefixdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 11,
                column: "Cost",
                value: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 11,
                column: "Cost",
                value: 73);
        }
    }
}
