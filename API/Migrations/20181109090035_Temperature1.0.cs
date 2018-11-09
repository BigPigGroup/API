using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Temperature10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Box",
                columns: table => new
                {
                    box_no = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Box", x => x.box_no);
                });

            migrationBuilder.CreateTable(
                name: "Temperature",
                columns: table => new
                {
                    box_no = table.Column<int>(nullable: false),
                    temperature = table.Column<float>(nullable: false),
                    c_ts = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperature", x => new { x.box_no, x.c_ts });
                    table.ForeignKey(
                        name: "FK_Temperature_Box_box_no",
                        column: x => x.box_no,
                        principalTable: "Box",
                        principalColumn: "box_no",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Temperature_box_no",
                table: "Temperature",
                column: "box_no",
                unique: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Temperature");

            migrationBuilder.DropTable(
                name: "Box");
        }
    }
}
