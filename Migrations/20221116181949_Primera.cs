using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppFerreteria.Migrations
{
    public partial class Primera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ClienteApellido = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ClientePhone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClienteDNI = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "Motosierra",
                columns: table => new
                {
                    MotosierraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoAlfanumericoMotosierra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrecioMotosierra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Codigodefabrica = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    MotosierraImg = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EstaAlquilada = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motosierra", x => x.MotosierraID);
                });

            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    RentalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    ClienteApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotosierraID = table.Column<int>(type: "int", nullable: true),
                    CodigoAlfanumericoMotosierra = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental", x => x.RentalID);
                    table.ForeignKey(
                        name: "FK_Rental_Cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rental_Motosierra_MotosierraID",
                        column: x => x.MotosierraID,
                        principalTable: "Motosierra",
                        principalColumn: "MotosierraID");
                });

            migrationBuilder.CreateTable(
                name: "Return",
                columns: table => new
                {
                    ReturnID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    ClienteApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoAlfanumericoMotosierra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotosierraID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Return", x => x.ReturnID);
                    table.ForeignKey(
                        name: "FK_Return_Cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Return_Motosierra_MotosierraID",
                        column: x => x.MotosierraID,
                        principalTable: "Motosierra",
                        principalColumn: "MotosierraID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rental_ClienteID",
                table: "Rental",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_MotosierraID",
                table: "Rental",
                column: "MotosierraID");

            migrationBuilder.CreateIndex(
                name: "IX_Return_ClienteID",
                table: "Return",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Return_MotosierraID",
                table: "Return",
                column: "MotosierraID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rental");

            migrationBuilder.DropTable(
                name: "Return");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Motosierra");
        }
    }
}
