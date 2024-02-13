using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StorageServiceLibrary.Migrations
{
    /// <inheritdoc />
    public partial class initDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id_Field = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Field_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ha = table.Column<double>(type: "float", nullable: false),
                    J = table.Column<double>(type: "float", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id_Field);
                });

            migrationBuilder.CreateTable(
                name: "Seeds",
                columns: table => new
                {
                    Id_Seed = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seeds", x => x.Id_Seed);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id_plan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FieldRefId = table.Column<int>(type: "int", nullable: false),
                    SeedRefId = table.Column<int>(type: "int", nullable: false),
                    Ha = table.Column<double>(type: "float", nullable: false),
                    J = table.Column<double>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id_plan);
                    table.ForeignKey(
                        name: "FK_Plans_Fields_FieldRefId",
                        column: x => x.FieldRefId,
                        principalTable: "Fields",
                        principalColumn: "Id_Field",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plans_Seeds_SeedRefId",
                        column: x => x.SeedRefId,
                        principalTable: "Seeds",
                        principalColumn: "Id_Seed",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Fields",
                columns: new[] { "Id_Field", "Field_number", "Ha", "J", "Link", "Name", "Note" },
                values: new object[,]
                {
                    { 1, "2494/20", 2.0, 3.5, "", "Kuvajt", "" },
                    { 2, "7739", 1.5, 2.25, "https://a3.geosrbija.rs/share/0dfacc67fca1", "Kanal", "" }
                });

            migrationBuilder.InsertData(
                table: "Seeds",
                columns: new[] { "Id_Seed", "Name", "Note" },
                values: new object[,]
                {
                    { 1, "Korn", "" },
                    { 2, "Soybean", "" },
                    { 3, "Wheat", "" }
                });

            migrationBuilder.InsertData(
                table: "Plans",
                columns: new[] { "Id_plan", "FieldRefId", "Ha", "J", "Note", "SeedRefId", "Year" },
                values: new object[,]
                {
                    { 1, 1, 1.5, 2.25, "", 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 1.5, 2.25, "", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, 1.5, 2.25, "", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plans_FieldRefId",
                table: "Plans",
                column: "FieldRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_SeedRefId",
                table: "Plans",
                column: "SeedRefId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Seeds");
        }
    }
}
