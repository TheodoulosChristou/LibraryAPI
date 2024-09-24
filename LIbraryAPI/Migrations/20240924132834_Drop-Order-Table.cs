using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LIbraryAPI.Migrations
{
    /// <inheritdoc />
    public partial class DropOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ORDER_ID = table.Column<int>(type: "int", nullable: false),
                    BOOK_ID = table.Column<int>(type: "int", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ORDER_ID);
                    table.ForeignKey(
                        name: "FK_Order_Book_ORDER_ID",
                        column: x => x.ORDER_ID,
                        principalTable: "Book",
                        principalColumn: "BOOK_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_User_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "User",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_USER_ID",
                table: "Order",
                column: "USER_ID");
        }
    }
}
