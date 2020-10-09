using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class intialdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(maxLength: 40, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 40, nullable: false),
                    MobileNo = table.Column<string>(maxLength: 10, nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    OrderStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pizzaDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Toppings = table.Column<int>(maxLength: 200, nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    OrderDetailsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pizzaDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pizzaDetails_orderDetails_OrderDetailsId",
                        column: x => x.OrderDetailsId,
                        principalTable: "orderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pizzaDetails_OrderDetailsId",
                table: "pizzaDetails",
                column: "OrderDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pizzaDetails");

            migrationBuilder.DropTable(
                name: "orderDetails");
        }
    }
}
