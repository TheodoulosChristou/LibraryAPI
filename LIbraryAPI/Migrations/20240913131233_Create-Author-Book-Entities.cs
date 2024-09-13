using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LIbraryAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateAuthorBookEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AUTHOR_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AUTHOR_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AUTHOR_SURNAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AGE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AUTHOR_ID);
                });

            migrationBuilder.CreateTable(
                name: "Publish",
                columns: table => new
                {
                    PUBLISH_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AUTHOR_ID = table.Column<int>(type: "int", nullable: false),
                    BOOK_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publish", x => x.PUBLISH_ID);
                    table.ForeignKey(
                        name: "FK_Publish_Author_AUTHOR_ID",
                        column: x => x.AUTHOR_ID,
                        principalTable: "Author",
                        principalColumn: "AUTHOR_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publish_Book_BOOK_ID",
                        column: x => x.BOOK_ID,
                        principalTable: "Book",
                        principalColumn: "BOOK_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Publish_AUTHOR_ID",
                table: "Publish",
                column: "AUTHOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Publish_BOOK_ID",
                table: "Publish",
                column: "BOOK_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Publish");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
