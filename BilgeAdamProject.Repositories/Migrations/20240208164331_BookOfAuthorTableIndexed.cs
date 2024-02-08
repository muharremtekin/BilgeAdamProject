using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilgeAdamProject.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class BookOfAuthorTableIndexed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BookOfAuthor_BookId",
                schema: "dbo",
                table: "BookOfAuthor",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookOfAuthor_BookId",
                schema: "dbo",
                table: "BookOfAuthor");
        }
    }
}
