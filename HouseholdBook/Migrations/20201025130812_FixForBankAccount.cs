using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseholdBook.Migrations
{
    public partial class FixForBankAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_BankAccounts_BankAccountId",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "BankAccountId",
                table: "Bookings",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_BankAccounts_BankAccountId",
                table: "Bookings",
                column: "BankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "BankAccountId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_BankAccounts_BankAccountId",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "BankAccountId",
                table: "Bookings",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_BankAccounts_BankAccountId",
                table: "Bookings",
                column: "BankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "BankAccountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
