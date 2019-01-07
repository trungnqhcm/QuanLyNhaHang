using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyNhaHangServer.Migrations
{
    public partial class updateTableOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "TableWithOrders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    TableId = table.Column<long>(nullable: false),
                    OrderId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableWithOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableWithOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableWithOrders_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TableWithOrders_OrderId",
                table: "TableWithOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TableWithOrders_TableId",
                table: "TableWithOrders",
                column: "TableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableWithOrders");

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
    }
}
