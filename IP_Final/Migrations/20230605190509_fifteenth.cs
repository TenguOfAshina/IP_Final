using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IP_Final.Migrations
{
    /// <inheritdoc />
    public partial class fifteenth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DenemeTables",
                columns: table => new
                {
                    deneme_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deneme_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DenemeTables", x => x.deneme_id);
                });

            migrationBuilder.CreateTable(
                name: "Softwares",
                columns: table => new
                {
                    app_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    app_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    app_version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    app_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    app_size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    app_owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    app_image_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    app_install_count = table.Column<int>(type: "int", nullable: false),
                    lang_code = table.Column<int>(type: "int", nullable: false),
                    os_code = table.Column<int>(type: "int", nullable: false),
                    cat_code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Softwares", x => x.app_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DenemeTables");

            migrationBuilder.DropTable(
                name: "Softwares");
        }
    }
}
