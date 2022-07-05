using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Store_link.Migrations
{
    public partial class v14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_Customers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_Customers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Customers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_Customers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("396b4ca7-69df-4c91-87db-c0d89a36384f"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("ac0c8aa1-6df9-40d1-8063-d0bdd86e82cb"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("bd3e000b-4c15-4b9f-b28d-692950582631"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("cc62caa4-dbdb-4b2c-8815-54b061182206"));

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "CustomerClaims");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "CustomerClaims",
                newName: "IX_CustomerClaims_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerClaims",
                table: "CustomerClaims",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_Customer_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Customer_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_Customer_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerClaims_Customer_UserId",
                table: "CustomerClaims",
                column: "UserId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_Customer_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Customer_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_Customer_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerClaims_Customer_UserId",
                table: "CustomerClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerClaims",
                table: "CustomerClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

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

            migrationBuilder.RenameTable(
                name: "CustomerClaims",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerClaims_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorID", "Address", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("396b4ca7-69df-4c91-87db-c0d89a36384f"), "Cairo", "ali@ali.com", "Ali Hamed" },
                    { new Guid("ac0c8aa1-6df9-40d1-8063-d0bdd86e82cb"), "Cairo", "islam@islam.com", "Islam Ahmed" },
                    { new Guid("bd3e000b-4c15-4b9f-b28d-692950582631"), "Cairo", "saif@saif.com", "Saifuddin Ibrahim" },
                    { new Guid("cc62caa4-dbdb-4b2c-8815-54b061182206"), "Cairo", "khaled@khaled.com", "Khaled Lotfy" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_Customers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_Customers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Customers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_Customers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
