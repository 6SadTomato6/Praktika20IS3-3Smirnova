using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class YourMigrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_fname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    customer_lname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    customer_email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "Delivery_method",
                columns: table => new
                {
                    delivery_method_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    delivery_method_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery_method", x => x.delivery_method_id);
                });

            migrationBuilder.CreateTable(
                name: "Filters",
                columns: table => new
                {
                    filter_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    filter_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filters", x => x.filter_id);
                });

            migrationBuilder.CreateTable(
                name: "Shopping_cart",
                columns: table => new
                {
                    cart_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    cart_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Shopping__2EF52A27A2F44812", x => x.cart_id);
                    table.ForeignKey(
                        name: "FK__Shopping___custo__440B1D61",
                        column: x => x.customer_id,
                        principalTable: "Customers",
                        principalColumn: "customer_id");
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    filter_id = table.Column<int>(type: "int", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.category_id);
                    table.ForeignKey(
                        name: "FK__Categorie__filte__398D8EEE",
                        column: x => x.filter_id,
                        principalTable: "Filters",
                        principalColumn: "filter_id");
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    cart_id = table.Column<int>(type: "int", nullable: false),
                    delivery_date = table.Column<DateTime>(type: "date", nullable: false),
                    delivery_method_id = table.Column<int>(type: "int", nullable: false),
                    delivery_status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Deliverie__cart___4BAC3F29",
                        column: x => x.cart_id,
                        principalTable: "Shopping_cart",
                        principalColumn: "cart_id");
                    table.ForeignKey(
                        name: "FK__Deliverie__deliv__4CA06362",
                        column: x => x.delivery_method_id,
                        principalTable: "Delivery_method",
                        principalColumn: "delivery_method_id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    product_count = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK__Products__catego__3C69FB99",
                        column: x => x.category_id,
                        principalTable: "Categories",
                        principalColumn: "category_id");
                });

            migrationBuilder.CreateTable(
                name: "Cart_items",
                columns: table => new
                {
                    cart_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    product_count = table.Column<int>(type: "int", nullable: false),
                    product_price = table.Column<decimal>(type: "numeric(9,2)", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PURCHASE_ITEMS", x => new { x.cart_id, x.product_id });
                    table.ForeignKey(
                        name: "FK__Cart_item__cart___47DBAE45",
                        column: x => x.cart_id,
                        principalTable: "Shopping_cart",
                        principalColumn: "cart_id");
                    table.ForeignKey(
                        name: "FK__Cart_item__produ__46E78A0C",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "product_id");
                });

            migrationBuilder.CreateTable(
                name: "Price_change",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false),
                    date_price_change = table.Column<DateTime>(type: "date", nullable: false),
                    new_price = table.Column<decimal>(type: "numeric(9,2)", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRICE_CHANGE", x => new { x.product_id, x.date_price_change });
                    table.ForeignKey(
                        name: "FK__Price_cha__produ__3F466844",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "product_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_items_product_id",
                table: "Cart_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_filter_id",
                table: "Categories",
                column: "filter_id");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_cart_id",
                table: "Deliveries",
                column: "cart_id");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_delivery_method_id",
                table: "Deliveries",
                column: "delivery_method_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_category_id",
                table: "Products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Shopping_cart_customer_id",
                table: "Shopping_cart",
                column: "customer_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart_items");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Price_change");

            migrationBuilder.DropTable(
                name: "Shopping_cart");

            migrationBuilder.DropTable(
                name: "Delivery_method");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Filters");
        }
    }
}
