using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WalletStatus",
                table: "Wallet",
                newName: "WalletStatusId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_RegistrantId",
                table: "Wallet",
                column: "RegistrantId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrant_UserId",
                table: "Registrant",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_WalletId",
                table: "Account",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Wallet_WalletId",
                table: "Account",
                column: "WalletId",
                principalTable: "Wallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrant_User_UserId",
                table: "Registrant",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_Registrant_RegistrantId",
                table: "Wallet",
                column: "RegistrantId",
                principalTable: "Registrant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Wallet_WalletId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrant_User_UserId",
                table: "Registrant");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_Registrant_RegistrantId",
                table: "Wallet");

            migrationBuilder.DropIndex(
                name: "IX_Wallet_RegistrantId",
                table: "Wallet");

            migrationBuilder.DropIndex(
                name: "IX_Registrant_UserId",
                table: "Registrant");

            migrationBuilder.DropIndex(
                name: "IX_Account_WalletId",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "WalletStatusId",
                table: "Wallet",
                newName: "WalletStatus");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
