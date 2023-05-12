using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelManagement.Infrastructure.Ef.Migrations
{
    /// <inheritdoc />
    public partial class AddInitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TravelCheckList");

            migrationBuilder.CreateTable(
                name: "TravelCheckList",
                schema: "TravelCheckList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelCheckList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelerItems",
                schema: "TravelCheckList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    IsTaken = table.Column<bool>(type: "bit", nullable: false),
                    TravelCheckListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelerItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelerItems_TravelCheckList_TravelCheckListId",
                        column: x => x.TravelCheckListId,
                        principalSchema: "TravelCheckList",
                        principalTable: "TravelCheckList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelerItems_TravelCheckListId",
                schema: "TravelCheckList",
                table: "TravelerItems",
                column: "TravelCheckListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelerItems",
                schema: "TravelCheckList");

            migrationBuilder.DropTable(
                name: "TravelCheckList",
                schema: "TravelCheckList");
        }
    }
}
