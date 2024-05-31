using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedLoansAndBorrowers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Borrowers",
                columns: new[] { "Id", "Email", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { 1, "ron.walker@example.com", "Ron", "3806747254818", "Walker" },
                    { 2, "jane.doe@example.com", "Jane", "380671234567", "Doe" },
                    { 3, "john.smith@example.com", "John", "380671234568", "Smith" },
                    { 4, "emily.johnson@example.com", "Emily", "380671234569", "Johnson" },
                    { 5, "michael.brown@example.com", "Michael", "380671234570", "Brown" },
                    { 6, "jessica.davis@example.com", "Jessica", "380671234571", "Davis" },
                    { 7, "david.miller@example.com", "David", "380671234572", "Miller" },
                    { 8, "sarah.wilson@example.com", "Sarah", "380671234573", "Wilson" },
                    { 9, "daniel.moore@example.com", "Daniel", "380671234574", "Moore" },
                    { 10, "laura.taylor@example.com", "Laura", "380671234575", "Taylor" }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "BookId", "BorrowerId", "LoanDate", "ReturnDate" },
                values: new object[,]
                {
                    { 1, 12, 2, new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 5, 1, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 7, 3, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, 4, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 8, 5, new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 10, 6, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 4, 7, new DateTime(2022, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 6, 8, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 9, 9, new DateTime(2022, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 11, 10, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 12, 1, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 12, 3, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 12, 4, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 12, 5, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 12, 6, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 12, 7, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 12, 8, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 12, 9, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 12, 10, new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 12, 2, new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Borrowers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Borrowers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Borrowers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Borrowers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Borrowers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Borrowers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Borrowers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Borrowers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Borrowers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Borrowers",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
