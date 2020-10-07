using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mini_Bank.Migrations
{
    public partial class File : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "FileDescriptor");

            migrationBuilder.AlterColumn<string>(
                name: "UniqueFileName",
                table: "FileDescriptor",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "FileDescriptor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileDescriptor_FileId",
                table: "FileDescriptor",
                column: "FileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FileDescriptor_Files_FileId",
                table: "FileDescriptor",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileDescriptor_Files_FileId",
                table: "FileDescriptor");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropIndex(
                name: "IX_FileDescriptor_FileId",
                table: "FileDescriptor");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "FileDescriptor");

            migrationBuilder.AlterColumn<Guid>(
                name: "UniqueFileName",
                table: "FileDescriptor",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "FileDescriptor",
                nullable: true);
        }
    }
}
