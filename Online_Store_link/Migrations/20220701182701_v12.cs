using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Store_link.Migrations
{
    public partial class v12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("207a48ba-7911-43d9-a770-33243c008863"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("66e70202-e57c-4b48-818b-cc8b6b2aeaef"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("95083ff8-a72c-434a-91a6-6f6b4824b009"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("b061b40c-6517-43f8-b574-51c08b305c44"));

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorID", "Address", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("21e7e6d3-fc8d-4b51-8150-66669372f25a"), "Cairo", "khaled@khaled.com", "Khaled Lotfy" },
                    { new Guid("4e24496a-71ec-4f9c-908c-54efe4861bcb"), "Cairo", "ali@ali.com", "Ali Hamed" },
                    { new Guid("9a1e4c6b-73b7-431e-90b0-d26b4c1a21be"), "Cairo", "islam@islam.com", "Islam Ahmed" },
                    { new Guid("e6af74a6-ab2f-4ea3-9587-6d79a19d70db"), "Cairo", "saif@saif.com", "Saifuddin Ibrahim" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("21e7e6d3-fc8d-4b51-8150-66669372f25a"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("4e24496a-71ec-4f9c-908c-54efe4861bcb"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("9a1e4c6b-73b7-431e-90b0-d26b4c1a21be"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("e6af74a6-ab2f-4ea3-9587-6d79a19d70db"));

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorID", "Address", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("207a48ba-7911-43d9-a770-33243c008863"), "Cairo", "khaled@khaled.com", "Khaled Lotfy" },
                    { new Guid("66e70202-e57c-4b48-818b-cc8b6b2aeaef"), "Cairo", "islam@islam.com", "Islam Ahmed" },
                    { new Guid("95083ff8-a72c-434a-91a6-6f6b4824b009"), "Cairo", "saif@saif.com", "Saifuddin Ibrahim" },
                    { new Guid("b061b40c-6517-43f8-b574-51c08b305c44"), "Cairo", "ali@ali.com", "Ali Hamed" }
                });
        }
    }
}
