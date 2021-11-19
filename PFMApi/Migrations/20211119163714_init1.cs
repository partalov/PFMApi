using Microsoft.EntityFrameworkCore.Migrations;

namespace PFMApi.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_MccCodes_MccCodeCode",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "MccCodeCode",
                table: "Transactions",
                newName: "MccCodeCoder");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_MccCodeCode",
                table: "Transactions",
                newName: "IX_Transactions_MccCodeCoder");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "MccCodes",
                newName: "Coder");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_MccCodes_MccCodeCoder",
                table: "Transactions",
                column: "MccCodeCoder",
                principalTable: "MccCodes",
                principalColumn: "Coder",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_MccCodes_MccCodeCoder",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "MccCodeCoder",
                table: "Transactions",
                newName: "MccCodeCode");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_MccCodeCoder",
                table: "Transactions",
                newName: "IX_Transactions_MccCodeCode");

            migrationBuilder.RenameColumn(
                name: "Coder",
                table: "MccCodes",
                newName: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_MccCodes_MccCodeCode",
                table: "Transactions",
                column: "MccCodeCode",
                principalTable: "MccCodes",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
