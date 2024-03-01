using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CDN.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Hobby", "Mail", "PhoneNumber", "Skillsets", "Username" },
                values: new object[,]
                {
                    { 1, "Gardening", "johndoe@example.com", "1234567890", "C#, .NET", "JohnDoe" },
                    { 2, "Photography", "janedoe@example.com", "0987654321", "JavaScript, React", "JaneDoe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
