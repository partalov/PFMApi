using Microsoft.EntityFrameworkCore.Migrations;

namespace PFMApi.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MerchanTtype",
                table: "MccCodes",
                newName: "MerchantType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MerchantType",
                table: "MccCodes",
                newName: "MerchanTtype");
        }
    }
}
