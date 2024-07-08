using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class basket_jsonb_optional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BasketEntityBasketId",
                table: "Product",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BasketEntityBasketId",
                table: "BasketProduct",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BasketEntityBasketId1",
                table: "BasketProduct",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JsonProducts",
                table: "Basket",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "jsonb");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BasketEntityBasketId",
                table: "Product",
                column: "BasketEntityBasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketProduct_BasketEntityBasketId",
                table: "BasketProduct",
                column: "BasketEntityBasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketProduct_BasketEntityBasketId1",
                table: "BasketProduct",
                column: "BasketEntityBasketId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketProduct_Basket_BasketEntityBasketId",
                table: "BasketProduct",
                column: "BasketEntityBasketId",
                principalTable: "Basket",
                principalColumn: "BasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketProduct_Basket_BasketEntityBasketId1",
                table: "BasketProduct",
                column: "BasketEntityBasketId1",
                principalTable: "Basket",
                principalColumn: "BasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Basket_BasketEntityBasketId",
                table: "Product",
                column: "BasketEntityBasketId",
                principalTable: "Basket",
                principalColumn: "BasketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketProduct_Basket_BasketEntityBasketId",
                table: "BasketProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketProduct_Basket_BasketEntityBasketId1",
                table: "BasketProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Basket_BasketEntityBasketId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_BasketEntityBasketId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_BasketProduct_BasketEntityBasketId",
                table: "BasketProduct");

            migrationBuilder.DropIndex(
                name: "IX_BasketProduct_BasketEntityBasketId1",
                table: "BasketProduct");

            migrationBuilder.DropColumn(
                name: "BasketEntityBasketId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BasketEntityBasketId",
                table: "BasketProduct");

            migrationBuilder.DropColumn(
                name: "BasketEntityBasketId1",
                table: "BasketProduct");

            migrationBuilder.AlterColumn<string>(
                name: "JsonProducts",
                table: "Basket",
                type: "jsonb",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "jsonb",
                oldNullable: true);
        }
    }
}
