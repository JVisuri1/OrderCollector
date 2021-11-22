using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderCollectorAPI.Migrations
{
    public partial class collected_bit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Collected",
                table: "orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Collected",
                table: "orders");
        }
    }
}
