using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Store_link.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: new Guid("2be8a360-aa1b-4dd5-b591-6c412d123432"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: new Guid("509c4617-d463-4d59-85b8-d27c851e5a9e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: new Guid("cd6a8469-d0dd-4915-acc9-a6d6dfacf019"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: new Guid("f1025ff3-4bda-4b04-bee8-91c7b58b68a6"));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryID",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "ArabicName", "Description", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("2be8a360-aa1b-4dd5-b591-6c412d123432"), "بلاي ستايشن", "playStation 5 plack color come with 2 hadles", "Mobile", 2200.5m, 5 },
                    { new Guid("509c4617-d463-4d59-85b8-d27c851e5a9e"), "بلاي ستايشن", "playStation 5 plack color come with 2 hadles", "Tablet", 2200.5m, 5 },
                    { new Guid("cd6a8469-d0dd-4915-acc9-a6d6dfacf019"), "بلاي ستايشن", "playStation 5 plack color come with 2 hadles", "IPhone", 2200.5m, 0 },
                    { new Guid("f1025ff3-4bda-4b04-bee8-91c7b58b68a6"), "بلاي ستايشن", "playStation 5 plack color come with 2 hadles", "PlayStation", 2200.5m, 5 }
                });
        }
    }
}
