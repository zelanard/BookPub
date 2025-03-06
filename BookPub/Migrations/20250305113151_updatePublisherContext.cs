using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookPub.Migrations
{
    /// <inheritdoc />
    public partial class updatePublisherContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistCover_Artist_ArtistsId",
                table: "ArtistCover");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistCover_Cover_CoversId",
                table: "ArtistCover");

            migrationBuilder.DropForeignKey(
                name: "FK_Cover_Books_BookId",
                table: "Cover");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cover",
                table: "Cover");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artist",
                table: "Artist");

            migrationBuilder.RenameTable(
                name: "Cover",
                newName: "Covers");

            migrationBuilder.RenameTable(
                name: "Artist",
                newName: "Artists");

            migrationBuilder.RenameIndex(
                name: "IX_Cover_BookId",
                table: "Covers",
                newName: "IX_Covers_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Covers",
                table: "Covers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artists",
                table: "Artists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistCover_Artists_ArtistsId",
                table: "ArtistCover",
                column: "ArtistsId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistCover_Covers_CoversId",
                table: "ArtistCover",
                column: "CoversId",
                principalTable: "Covers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Covers_Books_BookId",
                table: "Covers",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistCover_Artists_ArtistsId",
                table: "ArtistCover");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistCover_Covers_CoversId",
                table: "ArtistCover");

            migrationBuilder.DropForeignKey(
                name: "FK_Covers_Books_BookId",
                table: "Covers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Covers",
                table: "Covers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artists",
                table: "Artists");

            migrationBuilder.RenameTable(
                name: "Covers",
                newName: "Cover");

            migrationBuilder.RenameTable(
                name: "Artists",
                newName: "Artist");

            migrationBuilder.RenameIndex(
                name: "IX_Covers_BookId",
                table: "Cover",
                newName: "IX_Cover_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cover",
                table: "Cover",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artist",
                table: "Artist",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistCover_Artist_ArtistsId",
                table: "ArtistCover",
                column: "ArtistsId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistCover_Cover_CoversId",
                table: "ArtistCover",
                column: "CoversId",
                principalTable: "Cover",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cover_Books_BookId",
                table: "Cover",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
