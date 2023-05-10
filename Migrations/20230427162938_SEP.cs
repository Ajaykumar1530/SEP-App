using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEP_App.Migrations
{
    public partial class SEP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateDetails",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passoutyear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HighestQualification = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    score = table.Column<int>(type: "int", nullable: false),   
                    date =  table.Column<DateOnly>(type: "date", nullable: false)

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateDetails", x => x.CandidateId);
                });

            migrationBuilder.CreateTable(
                name: "OnlineTests",
                columns: table => new
                {
                    Qno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    answer = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineTests", x => x.Qno);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateDetails");

            migrationBuilder.DropTable(
                name: "OnlineTests");
        }
    }
}
