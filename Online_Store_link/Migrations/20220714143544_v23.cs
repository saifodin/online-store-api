using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Store_link.Migrations
{
    public partial class v23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorID", "Address", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("05becf26-5db3-4666-9c8b-242f599b2742"), "Cairo", "saif@saif.com", "Saifuddin Ibrahim" },
                    { new Guid("30dc738f-1e7f-4156-b9ed-ca7552918a29"), "Cairo", "ali@ali.com", "Ali Hamed" },
                    { new Guid("5e34bc8f-b8bf-4375-83fe-7b6cf868905b"), "Cairo", "islam@islam.com", "Islam Ahmed" },
                    { new Guid("d274ec90-bad1-4515-832a-abcd47e2fa78"), "Cairo", "khaled@khaled.com", "Khaled Lotfy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("05becf26-5db3-4666-9c8b-242f599b2742"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("30dc738f-1e7f-4156-b9ed-ca7552918a29"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("5e34bc8f-b8bf-4375-83fe-7b6cf868905b"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("d274ec90-bad1-4515-832a-abcd47e2fa78"));

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
    }
}
