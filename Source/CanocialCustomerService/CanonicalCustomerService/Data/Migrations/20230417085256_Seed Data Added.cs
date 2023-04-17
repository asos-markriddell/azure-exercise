using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CanonicalCustomer",
                columns: new[] { "CanonicalCustomerId", "Country", "CustomerId", "Email", "FullName", "MobileNumber" },
                values: new object[] { 1, "N. Ireland", 1, "john.smith@asos.com", "John Smith", "02876 651326" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CanonicalCustomer",
                keyColumn: "CanonicalCustomerId",
                keyValue: 1);
        }
    }
}
