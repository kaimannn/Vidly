using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Data.Migrations
{
    public partial class ChangeMembershipTypeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_MembershipType_MemberShipTypeId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MembershipType",
                table: "MembershipType");

            migrationBuilder.RenameTable(
                name: "MembershipType",
                newName: "MembershipTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MembershipTypes",
                table: "MembershipTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MembershipTypes_MemberShipTypeId",
                table: "Customers",
                column: "MemberShipTypeId",
                principalTable: "MembershipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_MembershipTypes_MemberShipTypeId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MembershipTypes",
                table: "MembershipTypes");

            migrationBuilder.RenameTable(
                name: "MembershipTypes",
                newName: "MembershipType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MembershipType",
                table: "MembershipType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MembershipType_MemberShipTypeId",
                table: "Customers",
                column: "MemberShipTypeId",
                principalTable: "MembershipType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
