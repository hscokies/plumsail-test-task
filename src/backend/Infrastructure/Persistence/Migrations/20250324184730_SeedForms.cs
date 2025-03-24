using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedForms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "forms",
                columns: new[] { "id", "color", "subtitle", "title" },
                values: new object[] { 1, "#7A5CFA", "Thu, Jun 5 at 07:00 PM EDT at The Amp Ballantyne", "RUN THE JEWELS" });

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "id", "discriminator", "form_id", "key", "placeholder", "title", "validator" },
                values: new object[,]
                {
                    { 1, "OpenQuestion", 1, "email", "Enter email address", "Email", "email" },
                    { 2, "DateQuestion", 1, "birthdate", null, "Date of birth", "birthdate" },
                    { 3, "SelectionQuestion", 1, "ticket-type", null, "Ticket Type", null },
                    { 4, "SingleOptionQuestion", 1, "preferred-seating", null, "Preferred Seating", null },
                    { 5, "MultipleOptionsQuestion", 1, "add-ons", null, "Add-ons", "none" }
                });

            migrationBuilder.InsertData(
                table: "question_options",
                columns: new[] { "id", "question_id", "value" },
                values: new object[,]
                {
                    { 1, 3, "General Admission" },
                    { 2, 3, "VIP" },
                    { 3, 3, "Student" },
                    { 4, 4, "Front row" },
                    { 5, 4, "Middle row" },
                    { 6, 4, "Back row" },
                    { 7, 5, "Parking Pass" },
                    { 8, 5, "Afterpaty ticket" },
                    { 9, 5, "Backstage pass" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "question_options",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "question_options",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "question_options",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "question_options",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "question_options",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "question_options",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "question_options",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "question_options",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "question_options",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "questions",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "questions",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "questions",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "questions",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "questions",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "forms",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
