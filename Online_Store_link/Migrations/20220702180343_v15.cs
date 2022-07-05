using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Store_link.Migrations
{
    public partial class v15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("1b8112cb-7436-49f3-bafd-20c528183e06"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("56e3e81c-c0f4-475f-8f90-19d2ad4065ee"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("82b0e159-ea44-4c46-8b9a-8fb3014f817c"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("e0732f80-5581-4c49-ad5f-7d180ae4f5dc"));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorID", "Address", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("11dd2396-4704-48e8-b126-8b01e891bdf5"), "Cairo", "saif@saif.com", "Saifuddin Ibrahim" },
                    { new Guid("69a0dd36-754d-471b-be67-9cd8f7edacd1"), "Cairo", "islam@islam.com", "Islam Ahmed" },
                    { new Guid("a744961d-12b9-4fd6-a1f5-0b9b995e5f45"), "Cairo", "ali@ali.com", "Ali Hamed" },
                    { new Guid("ccde79b9-f0b9-49e0-b99d-77e0b6d2219b"), "Cairo", "khaled@khaled.com", "Khaled Lotfy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("11dd2396-4704-48e8-b126-8b01e891bdf5"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("69a0dd36-754d-471b-be67-9cd8f7edacd1"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("a744961d-12b9-4fd6-a1f5-0b9b995e5f45"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("ccde79b9-f0b9-49e0-b99d-77e0b6d2219b"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Customer");

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorID", "Address", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("1b8112cb-7436-49f3-bafd-20c528183e06"), "Cairo", "islam@islam.com", "Islam Ahmed" },
                    { new Guid("56e3e81c-c0f4-475f-8f90-19d2ad4065ee"), "Cairo", "ali@ali.com", "Ali Hamed" },
                    { new Guid("82b0e159-ea44-4c46-8b9a-8fb3014f817c"), "Cairo", "khaled@khaled.com", "Khaled Lotfy" },
                    { new Guid("e0732f80-5581-4c49-ad5f-7d180ae4f5dc"), "Cairo", "saif@saif.com", "Saifuddin Ibrahim" }
                });
        }
    }
}
