using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthDate", "Email", "Name", "Surname" },
                values: new object[,]
                {
                    { 4, new DateTime(1990, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "sarah.brown@example.com", "Sarah", "Brown" },
                    { 5, new DateTime(1972, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.jones@example.com", "Michael", "Jones" },
                    { 6, new DateTime(1985, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "rachel.miller@example.com", "Rachel", "Miller" },
                    { 7, new DateTime(1968, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "david.martinez@example.com", "David", "Martinez" },
                    { 8, new DateTime(1983, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "jessica.garcia@example.com", "Jessica", "Garcia" },
                    { 9, new DateTime(1977, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "kevin.taylor@example.com", "Kevin", "Taylor" },
                    { 10, new DateTime(1995, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "michelle.lee@example.com", "Michelle", "Lee" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "ISBN", "Price", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 5, "ISBN-345678901", 11.25m, 1, "The Catcher in the Rye" },
                    { 6, "ISBN-876543210", 15.99m, 1, "Harry Potter and the Philosopher's Stone" },
                    { 7, "ISBN-567890123", 14.50m, 2, "To the Lighthouse" },
                    { 8, "ISBN-210987654", 13.25m, 1, "Moby-Dick" },
                    { 9, "ISBN-789012345", 16.75m, 1, "The Hobbit" },
                    { 10, "ISBN-321098765", 10.99m, 2, "Lord of the Flies" },
                    { 11, "ISBN-654321098", 9.50m, 2, "Brave New World" },
                    { 12, "ISBN-543210987", 8.25m, 1, "Wuthering Heights" },
                    { 13, "ISBN-432109876", 11.75m, 2, "The Grapes of Wrath" },
                    { 14, "ISBN-210987654", 14.99m, 2, "One Hundred Years of Solitude" },
                    { 15, "ISBN-789012345", 17.50m, 1, "The Lord of the Rings" },
                    { 16, "ISBN-543210987", 12.25m, 2, "Animal Farm" },
                    { 17, "ISBN-654321098", 15.75m, 1, "Fahrenheit 451" },
                    { 18, "ISBN-432109876", 10.99m, 1, "Gone with the Wind" },
                    { 19, "ISBN-321098765", 9.50m, 2, "The Odyssey" },
                    { 20, "ISBN-789012345", 14.25m, 1, "Crime and Punishment" },
                    { 21, "ISBN-123456789", 12.99m, 2, "The Great Gatsby" },
                    { 22, "ISBN-987654321", 10.50m, 1, "To Kill a Mockingbird" },
                    { 23, "ISBN-234567890", 9.99m, 1, "1984" },
                    { 24, "ISBN-098765432", 8.75m, 2, "Pride and Prejudice" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24);
        }
    }
}
