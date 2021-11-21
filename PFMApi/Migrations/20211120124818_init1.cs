using Microsoft.EntityFrameworkCore.Migrations;

namespace PFMApi.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "MccCodes",
                newName: "Coder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Coder",
                table: "MccCodes",
                newName: "Code");
        }
    }
}
