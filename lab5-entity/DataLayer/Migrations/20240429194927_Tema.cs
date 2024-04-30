using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Tema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    InstrumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstrumentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.InstrumentId);
                });

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    LaptopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecificationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.LaptopId);
                });

            migrationBuilder.CreateTable(
                name: "Musicians",
                columns: table => new
                {
                    MusicianId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusicianName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicians", x => x.MusicianId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "LaptopSpecifications",
                columns: table => new
                {
                    SpecificationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LaptopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cpu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gpu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Memory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaptopSpecifications", x => x.SpecificationsId);
                    table.ForeignKey(
                        name: "FK_LaptopSpecifications_Laptops_LaptopId",
                        column: x => x.LaptopId,
                        principalTable: "Laptops",
                        principalColumn: "LaptopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicianInstrument",
                columns: table => new
                {
                    InstrumentsInstrumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusiciansMusicianId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicianInstrument", x => new { x.InstrumentsInstrumentId, x.MusiciansMusicianId });
                    table.ForeignKey(
                        name: "FK_MusicianInstrument_Instruments_InstrumentsInstrumentId",
                        column: x => x.InstrumentsInstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "InstrumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicianInstrument_Musicians_MusiciansMusicianId",
                        column: x => x.MusiciansMusicianId,
                        principalTable: "Musicians",
                        principalColumn: "MusicianId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    PassengerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PassengerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.PassengerId);
                    table.ForeignKey(
                        name: "FK_Passengers_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LaptopSpecifications_LaptopId",
                table: "LaptopSpecifications",
                column: "LaptopId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicianInstrument_MusiciansMusicianId",
                table: "MusicianInstrument",
                column: "MusiciansMusicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_VehicleId",
                table: "Passengers",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LaptopSpecifications");

            migrationBuilder.DropTable(
                name: "MusicianInstrument");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Laptops");

            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropTable(
                name: "Musicians");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
