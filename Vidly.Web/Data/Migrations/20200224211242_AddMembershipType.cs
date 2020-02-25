using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Data.Migrations
{
    public partial class AddMembershipType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsSubscribedToNewsLetter",
                table: "Customers",
                newName: "IsSubscribedToNewsletter");

            migrationBuilder.AddColumn<byte>(
                name: "MemberShipTypeId",
                table: "Customers",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "MembershipType",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false),
                    SignUpFee = table.Column<short>(nullable: false),
                    DurationInMonths = table.Column<byte>(nullable: false),
                    DiscountRate = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MemberShipTypeId",
                table: "Customers",
                column: "MemberShipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MembershipType_MemberShipTypeId",
                table: "Customers",
                column: "MemberShipTypeId",
                principalTable: "MembershipType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_MembershipType_MemberShipTypeId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "MembershipType");

            migrationBuilder.DropIndex(
                name: "IX_Customers_MemberShipTypeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MemberShipTypeId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "IsSubscribedToNewsletter",
                table: "Customers",
                newName: "IsSubscribedToNewsLetter");
        }
    }
}
