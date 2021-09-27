using Microsoft.EntityFrameworkCore.Migrations;

namespace Pride_.Migrations
{
    public partial class v03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Andress",
                table: "doctors",
                newName: "Adress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "doctors",
                newName: "Andress");
        }
    }
}
