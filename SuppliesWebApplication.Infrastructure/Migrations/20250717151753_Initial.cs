using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SuppliesWebApplication.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    date_create = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_suppliers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "offers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stamp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    supplier_id = table.Column<int>(type: "int", nullable: false),
                    date_registration = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_offers", x => x.id);
                    table.ForeignKey(
                        name: "fk_offers_suppliers_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "suppliers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "suppliers",
                columns: new[] { "id", "date_create", "name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 17, 16, 40, 17, 0, DateTimeKind.Local), "Поставщик 1" },
                    { 2, new DateTime(2025, 7, 17, 16, 40, 17, 0, DateTimeKind.Local), "Поставщик 2" },
                    { 3, new DateTime(2025, 7, 17, 16, 40, 17, 0, DateTimeKind.Local), "Поставщик 3" },
                    { 4, new DateTime(2025, 7, 17, 16, 40, 17, 0, DateTimeKind.Local), "Поставщик 4" },
                    { 5, new DateTime(2025, 7, 17, 16, 40, 17, 0, DateTimeKind.Local), "Поставщик 5" }
                });

            migrationBuilder.InsertData(
                table: "offers",
                columns: new[] { "id", "date_registration", "model", "stamp", "supplier_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 17, 16, 40, 17, 0, DateTimeKind.Local), "Модель 1", "Марка 1", 1 },
                    { 2, new DateTime(2025, 7, 17, 16, 40, 17, 0, DateTimeKind.Local), "Модель 2", "Марка 2", 2 },
                    { 3, new DateTime(2025, 7, 17, 16, 40, 17, 0, DateTimeKind.Local), "Модель 3", "Марка 3", 3 },
                    { 4, new DateTime(2025, 7, 17, 16, 40, 17, 0, DateTimeKind.Local), "Модель 4", "Марка 4", 4 },
                    { 5, new DateTime(2025, 7, 17, 16, 40, 17, 0, DateTimeKind.Local), "Модель 5", "Марка 5", 5 },
                    { 6, new DateTime(2025, 7, 17, 16, 40, 17, 0, DateTimeKind.Local), "Модель 6", "Марка 6", 1 },
                    { 7, new DateTime(2025, 7, 17, 16, 40, 17, 0, DateTimeKind.Local), "Модель 7", "Марка 7", 2 },
                    { 8, new DateTime(2025, 7, 17, 16, 40, 17, 0, DateTimeKind.Local), "Модель 8", "Марка 8", 3 },
                    { 9, new DateTime(2025, 7, 17, 16, 40, 17, 0, DateTimeKind.Local), "Модель 9", "Марка 9", 4 },
                    { 10, new DateTime(2025, 7, 17, 16, 40, 17, 0, DateTimeKind.Local), "Модель 10", "Марка 10", 5 },
                    { 11, new DateTime(2025, 7, 17, 16, 40, 17, 0, DateTimeKind.Local), "Модель 11", "Марка 11", 1 },
                    { 12, new DateTime(2025, 7, 17, 16, 40, 17, 0, DateTimeKind.Local), "Модель 12", "Марка 12", 2 },
                    { 13, new DateTime(2025, 7, 17, 16, 40, 17, 0, DateTimeKind.Local), "Модель 13", "Марка 13", 3 },
                    { 14, new DateTime(2025, 7, 17, 16, 40, 17, 0, DateTimeKind.Local), "Модель 14", "Марка 14", 4 },
                    { 15, new DateTime(2025, 7, 17, 16, 40, 17, 0, DateTimeKind.Local), "Модель 15", "Марка 15", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "ix_offers_supplier_id",
                table: "offers",
                column: "supplier_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "offers");

            migrationBuilder.DropTable(
                name: "suppliers");
        }
    }
}
