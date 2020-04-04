using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SacrementPlanner.Migrations
{
    public partial class InitiaCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MembersId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MembersName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MembersId);
                });

            migrationBuilder.CreateTable(
                name: "SacrementMeetings",
                columns: table => new
                {
                    SacrementMeetingsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    SpeakerTopic = table.Column<string>(nullable: true),
                    ConductingLeader = table.Column<string>(nullable: true),
                    OpenignSong = table.Column<string>(nullable: true),
                    OpeningPrayer = table.Column<string>(nullable: true),
                    IntermediateHymn = table.Column<string>(nullable: true),
                    ClosingPrayer = table.Column<string>(nullable: true),
                    MembersId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SacrementMeetings", x => x.SacrementMeetingsId);
                    table.ForeignKey(
                        name: "FK_SacrementMeetings_Members_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Members",
                        principalColumn: "MembersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SacrementMeetings_MembersId",
                table: "SacrementMeetings",
                column: "MembersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SacrementMeetings");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
