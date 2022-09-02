using Microsoft.EntityFrameworkCore.Migrations;

namespace Phoneshop.Business.Migrations
{
    public partial class attempt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsPerOrder_Orders_OrderId",
                table: "ProductsPerOrder");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "ProductsPerOrder",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsPerOrder_Orders_OrderId",
                table: "ProductsPerOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsPerOrder_Orders_OrderId",
                table: "ProductsPerOrder");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "ProductsPerOrder",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsPerOrder_Orders_OrderId",
                table: "ProductsPerOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
