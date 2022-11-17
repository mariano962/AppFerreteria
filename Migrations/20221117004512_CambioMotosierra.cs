using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppFerreteria.Migrations
{
    public partial class CambioMotosierra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rental_Motosierra_MotosierraID",
                table: "Rental");

            migrationBuilder.AlterColumn<int>(
                name: "MotosierraID",
                table: "Rental",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Codigodefabrica",
                table: "Motosierra",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_Rental_Motosierra_MotosierraID",
                table: "Rental",
                column: "MotosierraID",
                principalTable: "Motosierra",
                principalColumn: "MotosierraID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rental_Motosierra_MotosierraID",
                table: "Rental");

            migrationBuilder.AlterColumn<int>(
                name: "MotosierraID",
                table: "Rental",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Codigodefabrica",
                table: "Motosierra",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Rental_Motosierra_MotosierraID",
                table: "Rental",
                column: "MotosierraID",
                principalTable: "Motosierra",
                principalColumn: "MotosierraID");
        }
    }
}
