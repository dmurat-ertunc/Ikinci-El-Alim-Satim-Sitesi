using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migrationnew3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblKategoriler_TblKategoriler_KategorilerId",
                table: "TblKategoriler");

            migrationBuilder.DropIndex(
                name: "IX_TblKategoriler_KategorilerId",
                table: "TblKategoriler");

            migrationBuilder.DropColumn(
                name: "KategorilerId",
                table: "TblKategoriler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategorilerId",
                table: "TblKategoriler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblKategoriler_KategorilerId",
                table: "TblKategoriler",
                column: "KategorilerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblKategoriler_TblKategoriler_KategorilerId",
                table: "TblKategoriler",
                column: "KategorilerId",
                principalTable: "TblKategoriler",
                principalColumn: "Id");
        }
    }
}
