using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Store_link.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");
        }
    }
}
