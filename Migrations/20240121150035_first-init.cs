using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace congestion_tax_calculator_net_core.Migrations
{
    public partial class firstinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    MaxTax = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    NumberPlates = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CongestionTaxRule",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CityId = table.Column<Guid>(nullable: false),
                    From = table.Column<DateTime>(nullable: false),
                    To = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongestionTaxRule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CongestionTaxRule_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CongestionTax",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    VehicleId = table.Column<Guid>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongestionTax", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CongestionTax_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CreatedAt", "MaxTax", "Name" },
                values: new object[] { new Guid("1114eb2e-3588-4239-98a4-f7e3023674e8"), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 60, "Gothenburg" });

            migrationBuilder.InsertData(
                table: "CongestionTaxRule",
                columns: new[] { "Id", "Amount", "CityId", "CreatedAt", "From", "To", "Type" },
                values: new object[,]
                {
                    { new Guid("1114eb2e-3588-4239-98a4-f7e3023674e9"), 8, new Guid("1114eb2e-3588-4239-98a4-f7e3023674e8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 6, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 6, 29, 59, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("2114eb2e-3588-4239-98a4-f7e3023674e9"), 13, new Guid("1114eb2e-3588-4239-98a4-f7e3023674e8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 6, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 6, 59, 59, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("3114eb2e-3588-4239-98a4-f7e3023674e9"), 18, new Guid("1114eb2e-3588-4239-98a4-f7e3023674e8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 7, 59, 59, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("4114eb2e-3588-4239-98a4-f7e3023674e9"), 13, new Guid("1114eb2e-3588-4239-98a4-f7e3023674e8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 8, 29, 59, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("5114eb2e-3588-4239-98a4-f7e3023674e9"), 8, new Guid("1114eb2e-3588-4239-98a4-f7e3023674e8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 14, 59, 59, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("6114eb2e-3588-4239-98a4-f7e3023674e9"), 13, new Guid("1114eb2e-3588-4239-98a4-f7e3023674e8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 15, 29, 59, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("7114eb2e-3588-4239-98a4-f7e3023674e9"), 18, new Guid("1114eb2e-3588-4239-98a4-f7e3023674e8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 16, 59, 59, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("8114eb2e-3588-4239-98a4-f7e3023674e9"), 13, new Guid("1114eb2e-3588-4239-98a4-f7e3023674e8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 17, 59, 59, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("9114eb2e-3588-4239-98a4-f7e3023674e9"), 8, new Guid("1114eb2e-3588-4239-98a4-f7e3023674e8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 18, 29, 59, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CongestionTax_VehicleId",
                table: "CongestionTax",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_CongestionTaxRule_CityId",
                table: "CongestionTaxRule",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CongestionTax");

            migrationBuilder.DropTable(
                name: "CongestionTaxRule");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
