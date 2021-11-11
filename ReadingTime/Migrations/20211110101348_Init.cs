using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadingTime.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Read = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Title);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BookTitle = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Book_BookTitle",
                        column: x => x.BookTitle,
                        principalTable: "Book",
                        principalColumn: "Title",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MyGoalList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyGoalList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyGoalList_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookMyGoalList",
                columns: table => new
                {
                    BooksTitle = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ListsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookMyGoalList", x => new { x.BooksTitle, x.ListsId });
                    table.ForeignKey(
                        name: "FK_BookMyGoalList_Book_BooksTitle",
                        column: x => x.BooksTitle,
                        principalTable: "Book",
                        principalColumn: "Title",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookMyGoalList_MyGoalList_ListsId",
                        column: x => x.ListsId,
                        principalTable: "MyGoalList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookMyGoalList_ListsId",
                table: "BookMyGoalList",
                column: "ListsId");

            migrationBuilder.CreateIndex(
                name: "IX_MyGoalList_UserId",
                table: "MyGoalList",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_BookTitle",
                table: "User",
                column: "BookTitle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookMyGoalList");

            migrationBuilder.DropTable(
                name: "MyGoalList");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
