using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlumGuide.Exercises.PlutoRover.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    Direction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "Id", "Direction", "X", "Y" },
                values: new object[] { new Guid("7add428f-6811-44f9-bbd8-be6b27fe907a"), 78, 0, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Position_Id",
                table: "Position",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
