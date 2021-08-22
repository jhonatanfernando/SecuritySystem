using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecuritySystem.EntityFrameworkCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoorLogActivities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    keyCardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsGranted = table.Column<bool>(type: "bit", nullable: false),
                    DateTimeEvent = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoorLogActivities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeyCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotionSensors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotionSensors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ControlAccesses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KeyCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HasAccess = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlAccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlAccesses_Doors_DoorId",
                        column: x => x.DoorId,
                        principalTable: "Doors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ControlAccesses_KeyCards_KeyCardId",
                        column: x => x.KeyCardId,
                        principalTable: "KeyCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotionSensorActivities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotionSensorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAlarmTriggered = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotionSensorActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotionSensorActivities_MotionSensors_MotionSensorId",
                        column: x => x.MotionSensorId,
                        principalTable: "MotionSensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlAccesses_DoorId",
                table: "ControlAccesses",
                column: "DoorId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlAccesses_KeyCardId",
                table: "ControlAccesses",
                column: "KeyCardId");

            migrationBuilder.CreateIndex(
                name: "IX_MotionSensorActivities_MotionSensorId",
                table: "MotionSensorActivities",
                column: "MotionSensorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlAccesses");

            migrationBuilder.DropTable(
                name: "DoorLogActivities");

            migrationBuilder.DropTable(
                name: "MotionSensorActivities");

            migrationBuilder.DropTable(
                name: "Doors");

            migrationBuilder.DropTable(
                name: "KeyCards");

            migrationBuilder.DropTable(
                name: "MotionSensors");
        }
    }
}
