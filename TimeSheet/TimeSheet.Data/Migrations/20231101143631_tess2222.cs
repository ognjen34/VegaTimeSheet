using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeSheet.Data.Migrations
{
    /// <inheritdoc />
    public partial class tess2222 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Country_CountryId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_CountryId",
                table: "Client");

            migrationBuilder.AlterColumn<string>(
                name: "CountryId",
                table: "Client",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId1",
                table: "Client",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Client_CountryId1",
                table: "Client",
                column: "CountryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Country_CountryId1",
                table: "Client",
                column: "CountryId1",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Country_CountryId1",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_CountryId1",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "CountryId1",
                table: "Client");

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "Client",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Client_CountryId",
                table: "Client",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Country_CountryId",
                table: "Client",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
