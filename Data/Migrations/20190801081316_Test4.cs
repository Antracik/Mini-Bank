using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountStatus",
                table: "Account",
                column: "AccountStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Status_AccountStatus",
                table: "Account",
                column: "AccountStatus",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Status_AccountStatus",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_AccountStatus",
                table: "Account");
        }
    }
}
