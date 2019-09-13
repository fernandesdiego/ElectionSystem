using Microsoft.EntityFrameworkCore.Migrations;

namespace PainelCipa.Migrations
{
    public partial class NewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Election_ElectionId",
                table: "Candidate");

            migrationBuilder.RenameColumn(
                name: "ElectionId",
                table: "Candidate",
                newName: "ElectionID");

            migrationBuilder.RenameIndex(
                name: "IX_Candidate_ElectionId",
                table: "Candidate",
                newName: "IX_Candidate_ElectionID");

            migrationBuilder.AlterColumn<int>(
                name: "ElectionID",
                table: "Candidate",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Election_ElectionID",
                table: "Candidate",
                column: "ElectionID",
                principalTable: "Election",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Election_ElectionID",
                table: "Candidate");

            migrationBuilder.RenameColumn(
                name: "ElectionID",
                table: "Candidate",
                newName: "ElectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Candidate_ElectionID",
                table: "Candidate",
                newName: "IX_Candidate_ElectionId");

            migrationBuilder.AlterColumn<int>(
                name: "ElectionId",
                table: "Candidate",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Election_ElectionId",
                table: "Candidate",
                column: "ElectionId",
                principalTable: "Election",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
