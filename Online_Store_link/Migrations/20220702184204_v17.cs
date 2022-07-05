using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Store_link.Migrations
{
    public partial class v17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("51398c80-2d48-4e9d-8353-c07a2d6eab98"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("8210e7d2-16aa-4c4b-a301-55b2284a1c6c"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("d88e84de-4f64-4747-a6db-4fc8506a95c7"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("eff9eb02-ae6c-4d72-a93d-e428903fecef"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("51398c80-2d48-4e9d-8353-c07a2d6eab98"), "Cairo", "saif@saif.com", "Saifuddin Ibrahim" },
                    { new Guid("8210e7d2-16aa-4c4b-a301-55b2284a1c6c"), "Cairo", "ali@ali.com", "Ali Hamed" },
                    { new Guid("d88e84de-4f64-4747-a6db-4fc8506a95c7"), "Cairo", "islam@islam.com", "Islam Ahmed" },
                    { new Guid("eff9eb02-ae6c-4d72-a93d-e428903fecef"), "Cairo", "khaled@khaled.com", "Khaled Lotfy" }
                });
        }
    }
}
