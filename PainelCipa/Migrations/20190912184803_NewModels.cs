using Microsoft.EntityFrameworkCore.Migrations;

namespace PainelCipa.Migrations
{
    public partial class NewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Election_CipaId",
                table: "Candidate");

            migrationBuilder.DropForeignKey(
                name: "FK_Voter_Election_CipaId",
                table: "Voter");

            migrationBuilder.RenameColumn(
                name: "CipaId",
                table: "Voter",
                newName: "ElectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Voter_CipaId",
                table: "Voter",
                newName: "IX_Voter_ElectionId");

            migrationBuilder.RenameColumn(
                name: "CipaId",
                table: "Candidate",
                newName: "ElectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Candidate_CipaId",
                table: "Candidate",
                newName: "IX_Candidate_ElectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Election_ElectionId",
                table: "Candidate",
                column: "ElectionId",
                principalTable: "Election",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voter_Election_ElectionId",
                table: "Voter",
                column: "ElectionId",
                principalTable: "Election",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Election_ElectionId",
                table: "Candidate");

            migrationBuilder.DropForeignKey(
                name: "FK_Voter_Election_ElectionId",
                table: "Voter");

            migrationBuilder.RenameColumn(
                name: "ElectionId",
                table: "Voter",
                newName: "CipaId");

            migrationBuilder.RenameIndex(
                name: "IX_Voter_ElectionId",
                table: "Voter",
                newName: "IX_Voter_CipaId");

            migrationBuilder.RenameColumn(
                name: "ElectionId",
                table: "Candidate",
                newName: "CipaId");

            migrationBuilder.RenameIndex(
                name: "IX_Candidate_ElectionId",
                table: "Candidate",
                newName: "IX_Candidate_CipaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Election_CipaId",
                table: "Candidate",
                column: "CipaId",
                principalTable: "Election",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voter_Election_CipaId",
                table: "Voter",
                column: "CipaId",
                principalTable: "Election",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
