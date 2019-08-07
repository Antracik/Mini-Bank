using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_WalletStatusId",
                table: "Wallet",
                column: "WalletStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_Status_WalletStatusId",
                table: "Wallet",
                column: "WalletStatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_Status_WalletStatusId",
                table: "Wallet");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Wallet_WalletStatusId",
                table: "Wallet");
        }
    }
}
