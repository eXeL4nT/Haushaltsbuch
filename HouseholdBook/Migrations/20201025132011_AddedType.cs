using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace HouseholdBook.Migrations
{
    public partial class AddedType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Bookings");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Bookings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Bookings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.TypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TypeId",
                table: "Bookings",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Type_TypeId",
                table: "Bookings",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Type_TypeId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_TypeId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Bookings",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
