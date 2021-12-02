using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class SalesDbMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BuyerPhoneNumber",
                table: "Carts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SellerPhoneNumber",
                table: "Carts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyerPhoneNumber",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "SellerPhoneNumber",
                table: "Carts");
        }
    }
}
