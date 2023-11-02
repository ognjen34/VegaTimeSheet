﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeSheet.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_LeadId",
                table: "Projects");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "LeadId",
                keyValue: null,
                column: "LeadId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "LeadId",
                table: "Projects",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_LeadId",
                table: "Projects",
                column: "LeadId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_LeadId",
                table: "Projects");

            migrationBuilder.AlterColumn<string>(
                name: "LeadId",
                table: "Projects",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_LeadId",
                table: "Projects",
                column: "LeadId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
