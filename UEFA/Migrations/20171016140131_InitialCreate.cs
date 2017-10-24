using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UEFA.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UEFAteams",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Manager = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    currentPhase = table.Column<string>(nullable: true),
                    currentRecord = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    neededQualification = table.Column<bool>(nullable: false),
                    previousWinner = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UEFAteams", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UEFAteams");
        }
    }
}
