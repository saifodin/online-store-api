using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Store_link.Migrations
{
    public partial class v27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("5641f679-9243-4f0c-b0b8-005cf6d6de99"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("5865cbf0-8e51-4b5d-b58b-05a5b86e01e4"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("70b1f1f7-e6f9-4800-9c9e-79291da00483"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("ef3145b9-6412-4feb-865b-7ced899858af"));

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorID", "Address", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("033ec784-e0f2-4de0-bd97-91d040152d03"), "Cairo", "khaled@khaled.com", "Khaled Lotfy" },
                    { new Guid("33a23350-4d3d-47e0-803a-4e386867760b"), "Cairo", "saif@saif.com", "Saifuddin Ibrahim" },
                    { new Guid("872b198a-ab4f-4c07-92fd-6454645af492"), "Cairo", "ali@ali.com", "Ali Hamed" },
                    { new Guid("d1324448-e2f3-4692-b8f8-d9c6575eda09"), "Cairo", "islam@islam.com", "Islam Ahmed" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("033ec784-e0f2-4de0-bd97-91d040152d03"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("33a23350-4d3d-47e0-803a-4e386867760b"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("872b198a-ab4f-4c07-92fd-6454645af492"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("d1324448-e2f3-4692-b8f8-d9c6575eda09"));

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorID", "Address", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("5641f679-9243-4f0c-b0b8-005cf6d6de99"), "Cairo", "saif@saif.com", "Saifuddin Ibrahim" },
                    { new Guid("5865cbf0-8e51-4b5d-b58b-05a5b86e01e4"), "Cairo", "islam@islam.com", "Islam Ahmed" },
                    { new Guid("70b1f1f7-e6f9-4800-9c9e-79291da00483"), "Cairo", "khaled@khaled.com", "Khaled Lotfy" },
                    { new Guid("ef3145b9-6412-4feb-865b-7ced899858af"), "Cairo", "ali@ali.com", "Ali Hamed" }
                });
        }
    }
}
