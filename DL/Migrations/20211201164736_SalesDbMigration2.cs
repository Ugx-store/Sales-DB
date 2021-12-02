using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class SalesDbMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BuyerPhoneNumber",
                table: "Sales",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SellerPhoneNumber",
                table: "Sales",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyerPhoneNumber",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "SellerPhoneNumber",
                table: "Sales");
        }
    }
}
