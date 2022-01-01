using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderCollectorAPI.Migrations
{
    public partial class comment_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CollectorComment",
                table: "order_rows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CollectorComment",
                table: "order_rows");
        }
    }
}
