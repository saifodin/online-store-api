using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Store_link.Migrations
{
    public partial class v18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("b2a2cff5-cb28-4059-8d8e-8ee19ab201b9"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("d650499d-898d-4f26-9c01-5253e2ac3125"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("e7410416-b0ab-4904-a97d-8c69abf32b1e"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("f4b10cfd-b203-4966-ab7a-c49f4b597f8e"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorID", "Address", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("b2a2cff5-cb28-4059-8d8e-8ee19ab201b9"), "Cairo", "saif@saif.com", "Saifuddin Ibrahim" },
                    { new Guid("d650499d-898d-4f26-9c01-5253e2ac3125"), "Cairo", "islam@islam.com", "Islam Ahmed" },
                    { new Guid("e7410416-b0ab-4904-a97d-8c69abf32b1e"), "Cairo", "khaled@khaled.com", "Khaled Lotfy" },
                    { new Guid("f4b10cfd-b203-4966-ab7a-c49f4b597f8e"), "Cairo", "ali@ali.com", "Ali Hamed" }
                });
        }
    }
}
