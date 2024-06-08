using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sube1.HelloMVC.Migrations
{
    /// <inheritdoc />
    public partial class dersdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblDersler",
                columns: table => new
                {
                    Dersid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dersad = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Kredi = table.Column<byte>(type: "tinyint", nullable: false),
                    Ogrenciid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDersler", x => x.Dersid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblDersler");
        }
    }
}
