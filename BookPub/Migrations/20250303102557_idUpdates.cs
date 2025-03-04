using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookPub.Migrations
{
    /// <inheritdoc />
    public partial class idUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistCover_Artist_ArtistsArtistId",
                table: "ArtistCover");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistCover_Cover_CoversCoverId",
                table: "ArtistCover");

            migrationBuilder.RenameColumn(
                name: "CoverId",
                table: "Cover",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Books",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Authors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CoversCoverId",
                table: "ArtistCover",
                newName: "CoversId");

            migrationBuilder.RenameColumn(
                name: "ArtistsArtistId",
                table: "ArtistCover",
                newName: "ArtistsId");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistCover_CoversCoverId",
                table: "ArtistCover",
                newName: "IX_ArtistCover_CoversId");

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "Artist",
                newName: "Id");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistCover_Artist_ArtistsId",
                table: "ArtistCover");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistCover_Cover_CoversId",
                table: "ArtistCover");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cover",
                newName: "CoverId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Books",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Authors",
                newName: "AuthorId");

            migrationBuilder.RenameColumn(
                name: "CoversId",
                table: "ArtistCover",
                newName: "CoversCoverId");

            migrationBuilder.RenameColumn(
                name: "ArtistsId",
                table: "ArtistCover",
                newName: "ArtistsArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistCover_CoversId",
                table: "ArtistCover",
                newName: "IX_ArtistCover_CoversCoverId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Artist",
                newName: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistCover_Artist_ArtistsArtistId",
                table: "ArtistCover",
                column: "ArtistsArtistId",
                principalTable: "Artist",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistCover_Cover_CoversCoverId",
                table: "ArtistCover",
                column: "CoversCoverId",
                principalTable: "Cover",
                principalColumn: "CoverId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
