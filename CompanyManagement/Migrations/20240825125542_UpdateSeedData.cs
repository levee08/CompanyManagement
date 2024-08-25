using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "AnnualRevenue", "FoundedDate", "Name", "TaxNumber" },
                values: new object[,]
                {
                    { 1, "123 Innovation St", 10000000m, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Innovators", 123456789 },
                    { 2, "456 Global Ave", 15000000m, new DateTime(2005, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Global Solutions", 987654321 },
                    { 3, "789 Green Rd", 8000000m, new DateTime(2010, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eco Friendly Inc.", 567890123 }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Budget", "CompanyId", "Name" },
                values: new object[,]
                {
                    { 1, 5000000m, 1, "Research and Development" },
                    { 2, 3000000m, 1, "Sales" },
                    { 3, 2000000m, 2, "Customer Support" },
                    { 4, 2500000m, 2, "Marketing" },
                    { 5, 1500000m, 3, "Sustainability" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "BirthDate", "BirthPlace", "DepartmentId", "LandlineNumber", "MobileNumber", "Name" },
                values: new object[,]
                {
                    { 1, "101 Main St", new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City A", 1, "098-765-4321", "123-456-7890", "Alice Johnson" },
                    { 2, "102 Main St", new DateTime(1987, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "City B", 1, "098-765-4322", "123-456-7891", "Bob Smith" },
                    { 3, "103 Main St", new DateTime(1990, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "City C", 2, "098-765-4323", "123-456-7892", "Charlie Brown" },
                    { 4, "104 Main St", new DateTime(1992, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "City D", 2, "098-765-4324", "123-456-7893", "David Williams" },
                    { 5, "105 Main St", new DateTime(1994, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "City E", 3, "098-765-4325", "123-456-7894", "Emma Wilson" },
                    { 6, "106 Main St", new DateTime(1996, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "City F", 3, "098-765-4326", "123-456-7895", "Frank Miller" },
                    { 7, "107 Main St", new DateTime(1998, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "City G", 4, "098-765-4327", "123-456-7896", "Grace Davis" },
                    { 8, "108 Main St", new DateTime(2000, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "City H", 4, "098-765-4328", "123-456-7897", "Henry Garcia" },
                    { 9, "109 Main St", new DateTime(2002, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "City I", 5, "098-765-4329", "123-456-7898", "Ivy Martinez" },
                    { 10, "110 Main St", new DateTime(2004, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "City J", 5, null, "123-456-7899", "Jack Taylor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
