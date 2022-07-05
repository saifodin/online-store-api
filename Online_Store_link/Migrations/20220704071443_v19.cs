using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Store_link.Migrations
{
    public partial class v19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("2b534365-76f2-4998-9d35-11bb002b3bb4"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("4fc0796d-0acf-4bae-b737-8498a1f70858"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("50bde529-719c-4def-8d76-4fcdf48cfbab"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("6dc9471d-4141-4341-a1ea-6da7f0df02f2"));

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => new { x.ProductId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_Carts_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorID", "Address", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("8111d9a0-d293-40c6-a698-4753d7268382"), "Cairo", "saif@saif.com", "Saifuddin Ibrahim" },
                    { new Guid("bff6bb3c-6f37-4ff1-8501-e9cd1e675e15"), "Cairo", "islam@islam.com", "Islam Ahmed" },
                    { new Guid("ccc0d0af-756e-42aa-8830-e6553f04482e"), "Cairo", "ali@ali.com", "Ali Hamed" },
                    { new Guid("d26b2702-f276-47f9-be74-c1d22ccaae00"), "Cairo", "khaled@khaled.com", "Khaled Lotfy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CustomerId",
                table: "Carts",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("8111d9a0-d293-40c6-a698-4753d7268382"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("bff6bb3c-6f37-4ff1-8501-e9cd1e675e15"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("ccc0d0af-756e-42aa-8830-e6553f04482e"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("d26b2702-f276-47f9-be74-c1d22ccaae00"));

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorID", "Address", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("2b534365-76f2-4998-9d35-11bb002b3bb4"), "Cairo", "khaled@khaled.com", "Khaled Lotfy" },
                    { new Guid("4fc0796d-0acf-4bae-b737-8498a1f70858"), "Cairo", "saif@saif.com", "Saifuddin Ibrahim" },
                    { new Guid("50bde529-719c-4def-8d76-4fcdf48cfbab"), "Cairo", "ali@ali.com", "Ali Hamed" },
                    { new Guid("6dc9471d-4141-4341-a1ea-6da7f0df02f2"), "Cairo", "islam@islam.com", "Islam Ahmed" }
                });
        }
    }
}
