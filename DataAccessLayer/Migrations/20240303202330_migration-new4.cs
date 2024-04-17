using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migrationnew4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblIlanlar_TblUrunler_UrunlerId",
                table: "TblIlanlar");

            migrationBuilder.DropForeignKey(
                name: "FK_TblUrunler_TblKategoriler_KategorilerId1",
                table: "TblUrunler");

            migrationBuilder.DropIndex(
                name: "IX_TblUrunler_KategorilerId1",
                table: "TblUrunler");

            migrationBuilder.DropIndex(
                name: "IX_TblIlanlar_UrunlerId",
                table: "TblIlanlar");

            migrationBuilder.DropColumn(
                name: "KategorilerId1",
                table: "TblUrunler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategorilerId1",
                table: "TblUrunler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TblUrunler_KategorilerId1",
                table: "TblUrunler",
                column: "KategorilerId1");

            migrationBuilder.CreateIndex(
                name: "IX_TblIlanlar_UrunlerId",
                table: "TblIlanlar",
                column: "UrunlerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblIlanlar_TblUrunler_UrunlerId",
                table: "TblIlanlar",
                column: "UrunlerId",
                principalTable: "TblUrunler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblUrunler_TblKategoriler_KategorilerId1",
                table: "TblUrunler",
                column: "KategorilerId1",
                principalTable: "TblKategoriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
