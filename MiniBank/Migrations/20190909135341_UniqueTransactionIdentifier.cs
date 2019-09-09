using Microsoft.EntityFrameworkCore.Migrations;

namespace Mini_Bank.Migrations
{
    public partial class UniqueTransactionIdentifier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UniqueTransactionIdentifier",
                table: "Transactions",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniqueTransactionIdentifier",
                table: "Transactions");
        }
    }
}
