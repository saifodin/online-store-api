using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Store_link.Migrations
{
    public partial class v24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerClaims_Customer_UserId",
                table: "CustomerClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerClaims",
                table: "CustomerClaims");

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

            migrationBuilder.RenameTable(
                name: "CustomerClaims",
                newName: "AdminClaims");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerClaims_UserId",
                table: "AdminClaims",
                newName: "IX_AdminClaims_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminClaims",
                table: "AdminClaims",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorID", "Address", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("0c49b0ae-c797-4328-9114-8b4c719ea68e"), "Cairo", "ali@ali.com", "Ali Hamed" },
                    { new Guid("b5e52d02-e482-4689-9f13-46014675b2e8"), "Cairo", "khaled@khaled.com", "Khaled Lotfy" },
                    { new Guid("c9eb0cac-9aad-46fe-919a-2a983ba8fb5a"), "Cairo", "saif@saif.com", "Saifuddin Ibrahim" },
                    { new Guid("f262c21a-6d00-49eb-a1f8-1342a7c2b39c"), "Cairo", "islam@islam.com", "Islam Ahmed" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AdminClaims_Customer_UserId",
                table: "AdminClaims",
                column: "UserId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminClaims_Customer_UserId",
                table: "AdminClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminClaims",
                table: "AdminClaims");

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("0c49b0ae-c797-4328-9114-8b4c719ea68e"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("b5e52d02-e482-4689-9f13-46014675b2e8"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("c9eb0cac-9aad-46fe-919a-2a983ba8fb5a"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("f262c21a-6d00-49eb-a1f8-1342a7c2b39c"));

            migrationBuilder.RenameTable(
                name: "AdminClaims",
                newName: "CustomerClaims");

            migrationBuilder.RenameIndex(
                name: "IX_AdminClaims_UserId",
                table: "CustomerClaims",
                newName: "IX_CustomerClaims_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerClaims",
                table: "CustomerClaims",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerClaims_Customer_UserId",
                table: "CustomerClaims",
                column: "UserId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
