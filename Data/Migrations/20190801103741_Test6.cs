using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Test6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Status_AccountStatus",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Registrant",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "AccountStatus",
                table: "Account",
                newName: "StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Account_AccountStatus",
                table: "Account",
                newName: "IX_Account_StatusId");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Registrant",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registrant_CountryId",
                table: "Registrant",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Status_StatusId",
                table: "Account",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrant_Country_CountryId",
                table: "Registrant",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Status_StatusId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrant_Country_CountryId",
                table: "Registrant");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Registrant_CountryId",
                table: "Registrant");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Registrant",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Account",
                newName: "AccountStatus");

            migrationBuilder.RenameIndex(
                name: "IX_Account_StatusId",
                table: "Account",
                newName: "IX_Account_AccountStatus");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Registrant",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Status_AccountStatus",
                table: "Account",
                column: "AccountStatus",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
