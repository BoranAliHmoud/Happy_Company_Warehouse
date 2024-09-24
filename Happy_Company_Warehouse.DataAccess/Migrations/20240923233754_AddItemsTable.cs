using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Happy_Company_Warehouse.DataAccess.Migrations
{
    public partial class AddItemsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cf99087-37a9-43f7-9ebe-1c311c344e7e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a026240b-8d4f-459f-9a88-a126f12bc13c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dc386aae-a835-4071-8163-0658567dae80", "525fde5f-057a-4e06-af56-a31ade0dba29" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc386aae-a835-4071-8163-0658567dae80");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "525fde5f-057a-4e06-af56-a31ade0dba29");

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SKUCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Qty = table.Column<int>(type: "INTEGER", nullable: false),
                    CostPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    MSRPPrice = table.Column<decimal>(type: "TEXT", nullable: true),
                    WarehouseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "033d5a3c-e4ce-4edf-9832-8f92098a453d", "9cd4cb3d-b65b-41ba-a746-bdaa4da69411", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b470f726-9c63-4ac0-8892-9ccf47675f9f", "18387456-2d8f-4bf0-9411-5b8f5d1e3e6f", "Auditor", "AUDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e95bbd2f-4390-471e-ba6e-18caa16d7ff2", "82fc6aa6-4625-413d-8563-288e3c86a334", "Management", "MANAGEMENT" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Active", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TenantId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bb51ec2f-94ba-4e77-a06d-f31d8ce1b72b", 0, true, "ac5cee6b-8a07-4a1a-9074-74f7dbbe6695", "admin@happywarehouse.com", true, "Admin", false, null, "ADMIN@HAPPYWAREHOUSE.COM", "ADMIN", "AQAAAAEAACcQAAAAEE8Alr6KQa+n5VB0fr+PBLvyg3BI9ltg2ULuPCJgi03yPr2pBfL8FyQxiBg9zAHtng==", null, false, "Admin", "440db06a-ce8a-45c4-a5c0-787e0358a893", "ADMIN", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "033d5a3c-e4ce-4edf-9832-8f92098a453d", "bb51ec2f-94ba-4e77-a06d-f31d8ce1b72b" });

            migrationBuilder.CreateIndex(
                name: "IX_Items_WarehouseId",
                table: "Items",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b470f726-9c63-4ac0-8892-9ccf47675f9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e95bbd2f-4390-471e-ba6e-18caa16d7ff2");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "033d5a3c-e4ce-4edf-9832-8f92098a453d", "bb51ec2f-94ba-4e77-a06d-f31d8ce1b72b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "033d5a3c-e4ce-4edf-9832-8f92098a453d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb51ec2f-94ba-4e77-a06d-f31d8ce1b72b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0cf99087-37a9-43f7-9ebe-1c311c344e7e", "18aa585c-10f1-4d13-bb82-72f914bdef8e", "Auditor", "AUDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a026240b-8d4f-459f-9a88-a126f12bc13c", "7fbcd12f-5499-4a48-b6b8-a125bd048ec3", "Management", "MANAGEMENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc386aae-a835-4071-8163-0658567dae80", "ff2bd0bf-c3d7-478e-8095-912d75914691", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Active", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TenantId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "525fde5f-057a-4e06-af56-a31ade0dba29", 0, true, "221142d5-e473-414a-8836-33b8d3c09253", "admin@happywarehouse.com", true, "Admin", false, null, "ADMIN@HAPPYWAREHOUSE.COM", "ADMIN", "AQAAAAEAACcQAAAAEP21aPb7navvtuuGsiFYlY/D9aqQWnAWl4JJk29lWLZOxexIH++2YPcgbjNkRvoIcA==", null, false, "Admin", "2a6ff618-f3ac-4904-bc79-f64001dcd8d9", "ADMIN", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "dc386aae-a835-4071-8163-0658567dae80", "525fde5f-057a-4e06-af56-a31ade0dba29" });
        }
    }
}
