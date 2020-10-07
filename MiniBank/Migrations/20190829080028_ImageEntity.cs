using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mini_Bank.Migrations
{
    public partial class ImageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileDescriptor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<byte[]>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    FileExtension = table.Column<string>(nullable: true),
                    UniqueFileName = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    EditedById = table.Column<int>(nullable: true),
                    DateEdited = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDescriptor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileDescriptor_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FileDescriptor_AspNetUsers_EditedById",
                        column: x => x.EditedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileDescriptor_CreatedById",
                table: "FileDescriptor",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FileDescriptor_EditedById",
                table: "FileDescriptor",
                column: "EditedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileDescriptor");
        }
    }
}
