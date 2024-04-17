using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class newmigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblAdmin_TblContact_UrunlerId",
                table: "TblAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_TblContact_TblKategoriler_KategorilerId1",
                table: "TblContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblContact",
                table: "TblContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblAdmin",
                table: "TblAdmin");

            migrationBuilder.RenameTable(
                name: "TblContact",
                newName: "TblUrunler");

            migrationBuilder.RenameTable(
                name: "TblAdmin",
                newName: "TblIlanlar");

            migrationBuilder.RenameIndex(
                name: "IX_TblContact_KategorilerId1",
                table: "TblUrunler",
                newName: "IX_TblUrunler_KategorilerId1");

            migrationBuilder.RenameIndex(
                name: "IX_TblAdmin_UrunlerId",
                table: "TblIlanlar",
                newName: "IX_TblIlanlar_UrunlerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblUrunler",
                table: "TblUrunler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblIlanlar",
                table: "TblIlanlar",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblIlanlar_TblUrunler_UrunlerId",
                table: "TblIlanlar");

            migrationBuilder.DropForeignKey(
                name: "FK_TblUrunler_TblKategoriler_KategorilerId1",
                table: "TblUrunler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblUrunler",
                table: "TblUrunler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblIlanlar",
                table: "TblIlanlar");

            migrationBuilder.RenameTable(
                name: "TblUrunler",
                newName: "TblContact");

            migrationBuilder.RenameTable(
                name: "TblIlanlar",
                newName: "TblAdmin");

            migrationBuilder.RenameIndex(
                name: "IX_TblUrunler_KategorilerId1",
                table: "TblContact",
                newName: "IX_TblContact_KategorilerId1");

            migrationBuilder.RenameIndex(
                name: "IX_TblIlanlar_UrunlerId",
                table: "TblAdmin",
                newName: "IX_TblAdmin_UrunlerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblContact",
                table: "TblContact",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblAdmin",
                table: "TblAdmin",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblAdmin_TblContact_UrunlerId",
                table: "TblAdmin",
                column: "UrunlerId",
                principalTable: "TblContact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblContact_TblKategoriler_KategorilerId1",
                table: "TblContact",
                column: "KategorilerId1",
                principalTable: "TblKategoriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
