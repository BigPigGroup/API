using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Temperature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Box",
                columns: table => new
                {
                    BoxNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Box", x => x.BoxNo);
                });

            migrationBuilder.CreateTable(
                name: "TemperatureTable",
                columns: table => new
                {
                    BoxNo = table.Column<int>(nullable: false),
                    TemperatureValue = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperatureTable", x => x.BoxNo);
                    table.ForeignKey(
                        name: "FK_TemperatureTable_Box_BoxNo",
                        column: x => x.BoxNo,
                        principalTable: "Box",
                        principalColumn: "BoxNo",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemperatureTable");

            migrationBuilder.DropTable(
                name: "Box");
        }
    }
}
