using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PainelCipa.Migrations
{
    public partial class NewModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Candidate",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "Candidate",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
