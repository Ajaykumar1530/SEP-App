using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEP_App.Migrations
{
    public partial class addnewcandidatelistmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "AddCandidates",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Referredby = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HighestQualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passoutyear = table.Column<DateTime>(type: "date", nullable: false),
                    Technology = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CareerGap = table.Column<int>(type: "int", nullable: false),
                    Contact = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<int>(type: "int", nullable: false),
                    Resume = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddCandidates", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddCandidates");
 
        }
    }
}
