using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StorageServiceLibrary.Migrations
{
    /// <inheritdoc />
    public partial class JWT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a463086-90e4-4070-9e45-d48040558d92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4429893e-13f2-4374-bb65-7b9adfd91990");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c86d2352-9cde-4287-b8f7-f8de1c2861c4");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "001b21d4-95b8-44f8-8083-39b95a632cfc", null, "Administrator", "ADMINISTRATOR" },
                    { "85e55551-4e49-4dc9-bf0c-9207f00753cb", null, "SuperAdmin", "SUPERADMIN" },
                    { "9f145c54-ed30-408e-ab15-7fc05f228f11", null, "Users", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "001b21d4-95b8-44f8-8083-39b95a632cfc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85e55551-4e49-4dc9-bf0c-9207f00753cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f145c54-ed30-408e-ab15-7fc05f228f11");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a463086-90e4-4070-9e45-d48040558d92", null, "Administrator", "ADMINISTRATOR" },
                    { "4429893e-13f2-4374-bb65-7b9adfd91990", null, "Users", "USER" },
                    { "c86d2352-9cde-4287-b8f7-f8de1c2861c4", null, "SuperAdmin", "SUPERADMIN" }
                });
        }
    }
}
