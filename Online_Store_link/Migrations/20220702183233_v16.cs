using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Store_link.Migrations
{
    public partial class v16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
