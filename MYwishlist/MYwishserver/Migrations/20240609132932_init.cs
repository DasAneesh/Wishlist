using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MYwishserver.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wishes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Productname = table.Column<string>(type: "TEXT", nullable: true),
                    Link = table.Column<string>(type: "TEXT", nullable: true),
                    Wishmeter = table.Column<int>(type: "INTEGER", nullable: false),
                    Cost = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishes", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wishes");
        }
    }
}
