using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvaTrade.News.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArticleUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstrumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FetchedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_RefId",
                table: "Article",
                column: "RefId",
                unique: true,
                filter: "[RefId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");
        }
    }
}
