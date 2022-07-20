using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Store_link.Migrations
{
    public partial class v28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("5a831963-15e9-4189-b5f9-8fa3f0d7b871"), "Cairo", "islam@islam.com", "Islam Ahmed" },
                    { new Guid("5b8747db-8fdd-4894-9aca-5efa28ec4dcb"), "Cairo", "ali@ali.com", "Ali Hamed" },
                    { new Guid("d3d40276-43a2-4d0e-be4b-4c27a4a9f775"), "Cairo", "khaled@khaled.com", "Khaled Lotfy" },
                    { new Guid("f90f9c6a-5345-44d0-bd1e-7958169ce3f8"), "Cairo", "saif@saif.com", "Saifuddin Ibrahim" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("5a831963-15e9-4189-b5f9-8fa3f0d7b871"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("5b8747db-8fdd-4894-9aca-5efa28ec4dcb"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("d3d40276-43a2-4d0e-be4b-4c27a4a9f775"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("f90f9c6a-5345-44d0-bd1e-7958169ce3f8"));

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
    }
}
