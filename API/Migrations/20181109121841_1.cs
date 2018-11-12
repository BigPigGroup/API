using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class _1 : Migration
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
                name: "Temperature",
                columns: table => new
                {
                    TemperatureValue = table.Column<float>(nullable: false),
                    CtsNo = table.Column<DateTime>(nullable: false),
                    BoxNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperature", x => new { x.BoxNo, x.CtsNo });
                    table.ForeignKey(
                        name: "FK_Temperature_Box_BoxNo",
                        column: x => x.BoxNo,
                        principalTable: "Box",
                        principalColumn: "BoxNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Temperature_BoxNo",
                table: "Temperature",
                column: "BoxNo");
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
