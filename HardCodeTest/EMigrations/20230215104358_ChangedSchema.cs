﻿using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HardCodeTest.Migrations
{
    /// <inheritdoc />
    public partial class ChangedSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldValue",
                table: "MiscFields");

            migrationBuilder.CreateTable(
                name: "MiscFieldValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FieldValue = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    MiscFieldId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiscFieldValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MiscFieldValue_MiscFields_MiscFieldId",
                        column: x => x.MiscFieldId,
                        principalTable: "MiscFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MiscFieldValue_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MiscFieldValue_MiscFieldId",
                table: "MiscFieldValue",
                column: "MiscFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_MiscFieldValue_ProductId",
                table: "MiscFieldValue",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MiscFieldValue");

            migrationBuilder.AddColumn<string>(
                name: "FieldValue",
                table: "MiscFields",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
