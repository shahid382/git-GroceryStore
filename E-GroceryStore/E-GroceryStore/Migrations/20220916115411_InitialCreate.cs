using Microsoft.EntityFrameworkCore.Migrations;

namespace E_GroceryStore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "groceryItemsModel",
                columns: table => new
                {
                    GroceryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroceryName = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ExpiryDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groceryItemsModel", x => x.GroceryId);
                });

            migrationBuilder.CreateTable(
                name: "orderModel",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroceryName = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderModel", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "ratingModel",
                columns: table => new
                {
                    RatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroceryName = table.Column<string>(nullable: true),
                    RatingScaleValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratingModel", x => x.RatingId);
                });

            migrationBuilder.CreateTable(
                name: "userModel",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userModel", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "groceryItemsModel");

            migrationBuilder.DropTable(
                name: "orderModel");

            migrationBuilder.DropTable(
                name: "ratingModel");

            migrationBuilder.DropTable(
                name: "userModel");
        }
    }
}
