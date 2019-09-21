using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PainelCipa.Migrations
{
    public partial class newVoteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vote_Candidate_CandidateId",
                table: "Vote");

            migrationBuilder.DropForeignKey(
                name: "FK_Vote_Voter_VoterId",
                table: "Vote");

            migrationBuilder.DropTable(
                name: "Voter");

            migrationBuilder.DropIndex(
                name: "IX_Vote_VoterId",
                table: "Vote");

            migrationBuilder.DropColumn(
                name: "VoterId",
                table: "Vote");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "Vote",
                newName: "CandidateID");

            migrationBuilder.RenameIndex(
                name: "IX_Vote_CandidateId",
                table: "Vote",
                newName: "IX_Vote_CandidateID");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateID",
                table: "Vote",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CPF",
                table: "Vote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_Candidate_CandidateID",
                table: "Vote",
                column: "CandidateID",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vote_Candidate_CandidateID",
                table: "Vote");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Vote");

            migrationBuilder.RenameColumn(
                name: "CandidateID",
                table: "Vote",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_Vote_CandidateID",
                table: "Vote",
                newName: "IX_Vote_CandidateId");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "Vote",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "VoterId",
                table: "Vote",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Voter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CPF = table.Column<string>(nullable: true),
                    ElectionId = table.Column<int>(nullable: true),
                    HasVoted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voter_Election_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Election",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vote_VoterId",
                table: "Vote",
                column: "VoterId");

            migrationBuilder.CreateIndex(
                name: "IX_Voter_ElectionId",
                table: "Voter",
                column: "ElectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_Candidate_CandidateId",
                table: "Vote",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_Voter_VoterId",
                table: "Vote",
                column: "VoterId",
                principalTable: "Voter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
