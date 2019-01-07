using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyNhaHangServer.Migrations
{
    public partial class CurrentIngredientcs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TableWithOrders_Orders_OrderId",
                table: "TableWithOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TableWithOrders_Tables_TableId",
                table: "TableWithOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TableWithOrders",
                table: "TableWithOrders");

            migrationBuilder.RenameTable(
                name: "TableWithOrders",
                newName: "TableWithOrder");

            migrationBuilder.RenameIndex(
                name: "IX_TableWithOrders_TableId",
                table: "TableWithOrder",
                newName: "IX_TableWithOrder_TableId");

            migrationBuilder.RenameIndex(
                name: "IX_TableWithOrders_OrderId",
                table: "TableWithOrder",
                newName: "IX_TableWithOrder_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TableWithOrder",
                table: "TableWithOrder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TableWithOrder_Orders_OrderId",
                table: "TableWithOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TableWithOrder_Tables_TableId",
                table: "TableWithOrder",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TableWithOrder_Orders_OrderId",
                table: "TableWithOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_TableWithOrder_Tables_TableId",
                table: "TableWithOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TableWithOrder",
                table: "TableWithOrder");

            migrationBuilder.RenameTable(
                name: "TableWithOrder",
                newName: "TableWithOrders");

            migrationBuilder.RenameIndex(
                name: "IX_TableWithOrder_TableId",
                table: "TableWithOrders",
                newName: "IX_TableWithOrders_TableId");

            migrationBuilder.RenameIndex(
                name: "IX_TableWithOrder_OrderId",
                table: "TableWithOrders",
                newName: "IX_TableWithOrders_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TableWithOrders",
                table: "TableWithOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TableWithOrders_Orders_OrderId",
                table: "TableWithOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TableWithOrders_Tables_TableId",
                table: "TableWithOrders",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
