using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Store_link.Migrations
{
    public partial class v26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "Customer");

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("4f6fbf10-3e05-4ce1-97a0-4426d406e371"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("543cd39d-9b76-4e5f-baa2-35bb9b990585"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("6889d3a5-4af7-4939-90cf-feb334f86892"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: new Guid("91bdf608-bab4-4522-a3a8-681764c59ebf"));

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Admin");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_AspNetUsers_Id",
                table: "Admin",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_AspNetUsers_Id",
                table: "Customer",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerClaims_AspNetUsers_UserId",
                table: "CustomerClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_AspNetUsers_Id",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_AspNetUsers_Id",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerClaims_AspNetUsers_UserId",
                table: "CustomerClaims");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customer",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Customer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Customer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Customer",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Customer",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Customer",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Customer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Customer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Customer",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Admin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Admin",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Admin",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Admin",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Admin",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Admin",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorID", "Address", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("4f6fbf10-3e05-4ce1-97a0-4426d406e371"), "Cairo", "saif@saif.com", "Saifuddin Ibrahim" },
                    { new Guid("543cd39d-9b76-4e5f-baa2-35bb9b990585"), "Cairo", "islam@islam.com", "Islam Ahmed" },
                    { new Guid("6889d3a5-4af7-4939-90cf-feb334f86892"), "Cairo", "khaled@khaled.com", "Khaled Lotfy" },
                    { new Guid("91bdf608-bab4-4522-a3a8-681764c59ebf"), "Cairo", "ali@ali.com", "Ali Hamed" }
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Customer",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Customer",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
    }
}
