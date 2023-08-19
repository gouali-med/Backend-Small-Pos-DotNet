using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionCommercialeServices.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailsSales_Ventes_SaleID",
                table: "DetailsSales");

            migrationBuilder.RenameColumn(
                name: "TotalTCC",
                table: "Ventes",
                newName: "TotalTTC");

            migrationBuilder.AlterColumn<int>(
                name: "SaleID",
                table: "DetailsSales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsSales_Ventes_SaleID",
                table: "DetailsSales",
                column: "SaleID",
                principalTable: "Ventes",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailsSales_Ventes_SaleID",
                table: "DetailsSales");

            migrationBuilder.RenameColumn(
                name: "TotalTTC",
                table: "Ventes",
                newName: "TotalTCC");

            migrationBuilder.AlterColumn<int>(
                name: "SaleID",
                table: "DetailsSales",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsSales_Ventes_SaleID",
                table: "DetailsSales",
                column: "SaleID",
                principalTable: "Ventes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
