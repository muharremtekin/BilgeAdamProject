using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilgeAdamProject.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Author",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookOfAuthor",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookOfAuthor", x => x.Id);
                    table.UniqueConstraint("AK_BookOfAuthor_BookId", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_BookOfAuthor_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "dbo",
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Author_Id",
                schema: "dbo",
                table: "Author",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Id",
                schema: "dbo",
                table: "Book",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookOfAuthor_AuthorId",
                schema: "dbo",
                table: "BookOfAuthor",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookOfAuthor_Id",
                schema: "dbo",
                table: "BookOfAuthor",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BookOfAuthor",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Author",
                schema: "dbo");
        }
    }
}
