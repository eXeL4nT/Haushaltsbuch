using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseholdBook.Migrations
{
    public partial class DateIsStringNow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Bookings",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Bookings",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
