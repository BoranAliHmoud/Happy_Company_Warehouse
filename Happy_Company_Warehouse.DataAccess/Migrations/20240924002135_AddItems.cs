using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Happy_Company_Warehouse.DataAccess.Migrations
{
    public partial class AddItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { "1b02b9c6-03c3-42c0-868b-0f5fdf2925e4", "fe5ff34b-25f2-475d-b994-4f1554227489", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "484a59ac-ab79-49cc-8c4c-956f7d30b0f8", "f5a807f7-8469-4fc1-b9cd-1090846b0fd3", "Auditor", "AUDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf893b7a-f8b1-489e-87f7-641a8226ff30", "7673ff04-1d28-4522-85bc-b4baad3608a7", "Management", "MANAGEMENT" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Active", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TenantId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c7e37a94-ee2e-4915-afef-ff50098943c5", 0, true, "4de94718-bb1d-4f35-a76c-59dd15971c6a", "admin@happywarehouse.com", true, "Admin", false, null, "ADMIN@HAPPYWAREHOUSE.COM", "ADMIN", "AQAAAAEAACcQAAAAELIRwEm1mWVwiH7uMbqaWi4Ustq12R6XncgL2YZuXf9kNu0OlgUK9pPTIw2jXNxsEw==", null, false, "Admin", "8a7de8dd-7143-4cbb-af00-c8c91f5ba26b", "ADMIN", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1b02b9c6-03c3-42c0-868b-0f5fdf2925e4", "c7e37a94-ee2e-4915-afef-ff50098943c5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "484a59ac-ab79-49cc-8c4c-956f7d30b0f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf893b7a-f8b1-489e-87f7-641a8226ff30");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1b02b9c6-03c3-42c0-868b-0f5fdf2925e4", "c7e37a94-ee2e-4915-afef-ff50098943c5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b02b9c6-03c3-42c0-868b-0f5fdf2925e4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7e37a94-ee2e-4915-afef-ff50098943c5");

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
        }
    }
}
