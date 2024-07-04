using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessExample.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnotherEnties",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StringProperty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateProperty = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnotherEnties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SampleEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StringProperty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateProperty = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnotherProperty_Id = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleEntities_AnotherEnties_AnotherProperty_Id",
                        column: x => x.AnotherProperty_Id,
                        principalTable: "AnotherEnties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SampleEntities_AnotherProperty_Id",
                table: "SampleEntities",
                column: "AnotherProperty_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SampleEntities");

            migrationBuilder.DropTable(
                name: "AnotherEnties");
        }
    }
}
