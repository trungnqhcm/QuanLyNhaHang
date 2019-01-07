using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyNhaHangServer.Migrations
{
    public partial class UpdateOrderWithTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tables_TableId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TableId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "Orders");

            migrationBuilder.AddColumn<long>(
                name: "OrderId",
                table: "Tables",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tables_OrderId",
                table: "Tables",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Orders_OrderId",
                table: "Tables",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Orders_OrderId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_OrderId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Tables");

            migrationBuilder.AddColumn<long>(
                name: "TableId",
                table: "Orders",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TableId",
                table: "Orders",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tables_TableId",
                table: "Orders",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
