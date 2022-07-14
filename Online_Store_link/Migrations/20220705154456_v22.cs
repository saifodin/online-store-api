using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Store_link.Migrations
{
    public partial class v22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("8a3da12b-1691-41f1-bfa0-b5e92e0b76c7"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("9858d679-580e-42aa-a94d-39f773fa8cff"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("a28817bd-99a9-4ca9-ab90-ee99ca3bcc36"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("c9096364-65a4-4efb-8817-69418b9ba6bb"));

            migrationBuilder.AddColumn<int>(
                name: "ItemsCount",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotatlPrice",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorID", "Address", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("256a31cd-c456-4b71-a98a-bcc6174d8e87"), "Cairo", "khaled@khaled.com", "Khaled Lotfy" },
                    { new Guid("2f956a02-8f96-4d88-aef8-af1daf9d1029"), "Cairo", "islam@islam.com", "Islam Ahmed" },
                    { new Guid("936be734-044e-44d1-8dc1-7e8c1dee16fd"), "Cairo", "saif@saif.com", "Saifuddin Ibrahim" },
                    { new Guid("c65361fc-e841-4a69-bbeb-8fbc6dc179f7"), "Cairo", "ali@ali.com", "Ali Hamed" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("256a31cd-c456-4b71-a98a-bcc6174d8e87"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("2f956a02-8f96-4d88-aef8-af1daf9d1029"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("936be734-044e-44d1-8dc1-7e8c1dee16fd"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("c65361fc-e841-4a69-bbeb-8fbc6dc179f7"));

            migrationBuilder.DropColumn(
                name: "ItemsCount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotatlPrice",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorID", "Address", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("8a3da12b-1691-41f1-bfa0-b5e92e0b76c7"), "Cairo", "ali@ali.com", "Ali Hamed" },
                    { new Guid("9858d679-580e-42aa-a94d-39f773fa8cff"), "Cairo", "saif@saif.com", "Saifuddin Ibrahim" },
                    { new Guid("a28817bd-99a9-4ca9-ab90-ee99ca3bcc36"), "Cairo", "khaled@khaled.com", "Khaled Lotfy" },
                    { new Guid("c9096364-65a4-4efb-8817-69418b9ba6bb"), "Cairo", "islam@islam.com", "Islam Ahmed" }
                });
        }
    }
}
