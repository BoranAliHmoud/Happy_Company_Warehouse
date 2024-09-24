using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Happy_Company_Warehouse.DataAccess.Migrations
{
    public partial class internaldatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4330df1-1357-458c-bfa7-016d01126b4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8bee929-963b-4b7b-9be2-4cebd6b88831");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0690d1da-be31-4aac-9c2d-0362b0ec8b33", "82d45cb2-21c2-4881-bb94-ecd076d0dc32" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0690d1da-be31-4aac-9c2d-0362b0ec8b33");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82d45cb2-21c2-4881-bb94-ecd076d0dc32");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0690d1da-be31-4aac-9c2d-0362b0ec8b33", "5697741a-4140-4afe-b09e-aa15e41d2071", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b4330df1-1357-458c-bfa7-016d01126b4c", "0abc03f9-7358-4d88-b911-d623ae5f4854", "Auditor", "AUDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8bee929-963b-4b7b-9be2-4cebd6b88831", "93c0885b-fd15-42dd-84a7-488a73111650", "Management", "MANAGEMENT" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Active", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TenantId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "82d45cb2-21c2-4881-bb94-ecd076d0dc32", 0, true, "d1db340a-0014-4796-a785-82681718c9f9", "admin@happywarehouse.com", true, "Admin", false, null, "ADMIN@HAPPYWAREHOUSE.COM", "ADMIN", "AQAAAAEAACcQAAAAEGuJDqS2/T9NevTYKHtre+deWhCHM8U3qMvTQmIynNhrO3gqfGkEp4528jZcEqPcIw==", null, false, "Admin", "e651d99f-38ef-4e9f-940d-84702ef9f81b", "ADMIN", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0690d1da-be31-4aac-9c2d-0362b0ec8b33", "82d45cb2-21c2-4881-bb94-ecd076d0dc32" });
        }
    }
}
