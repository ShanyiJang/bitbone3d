using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bitbone3d.Migrations
{
    /// <inheritdoc />
    public partial class AddParking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PKG_Parkings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LicensePlateNo = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntryLane = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntryTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(20,6)", precision: 20, scale: 6, nullable: false),
                    LastPayTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PKG_Parkings", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PKG_ParkingSpaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParkingLicensePlateNo = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PKG_ParkingSpaces", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PKG_Q_InParkVehicleCounters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PKG_Q_InParkVehicleCounters", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PKG_Q_ParkingIncomDailies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(20,6)", precision: 20, scale: 6, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PKG_Q_ParkingIncomDailies", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PKG_Q_ParkingRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LicensePlateNo = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntryLane = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntryTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastParkingSpaceCode = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Exited = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastPayTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    TotalPaidAmount = table.Column<decimal>(type: "decimal(20,6)", precision: 20, scale: 6, nullable: false),
                    ExitLane = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExitTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PKG_Q_ParkingRecords", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PKG_Q_ParkingSpaceMonitors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ParkingSpaceCode = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAvailable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ParkingLicensePlateNo = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParkedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PKG_Q_ParkingSpaceMonitors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PKG_Parkings_TenantId_LicensePlateNo",
                table: "PKG_Parkings",
                columns: new[] { "TenantId", "LicensePlateNo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PKG_ParkingSpaces_TenantId_Code",
                table: "PKG_ParkingSpaces",
                columns: new[] { "TenantId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PKG_Q_InParkVehicleCounters_TenantId",
                table: "PKG_Q_InParkVehicleCounters",
                column: "TenantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PKG_Q_ParkingIncomDailies_TenantId_Date",
                table: "PKG_Q_ParkingIncomDailies",
                columns: new[] { "TenantId", "Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PKG_Q_ParkingRecords_TenantId_EntryTime",
                table: "PKG_Q_ParkingRecords",
                columns: new[] { "TenantId", "EntryTime" });

            migrationBuilder.CreateIndex(
                name: "IX_PKG_Q_ParkingRecords_TenantId_LicensePlateNo_EntryTime",
                table: "PKG_Q_ParkingRecords",
                columns: new[] { "TenantId", "LicensePlateNo", "EntryTime" });

            migrationBuilder.CreateIndex(
                name: "IX_PKG_Q_ParkingSpaceMonitors_TenantId_ParkingLicensePlateNo",
                table: "PKG_Q_ParkingSpaceMonitors",
                columns: new[] { "TenantId", "ParkingLicensePlateNo" });

            migrationBuilder.CreateIndex(
                name: "IX_PKG_Q_ParkingSpaceMonitors_TenantId_ParkingSpaceCode",
                table: "PKG_Q_ParkingSpaceMonitors",
                columns: new[] { "TenantId", "ParkingSpaceCode" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PKG_Parkings");

            migrationBuilder.DropTable(
                name: "PKG_ParkingSpaces");

            migrationBuilder.DropTable(
                name: "PKG_Q_InParkVehicleCounters");

            migrationBuilder.DropTable(
                name: "PKG_Q_ParkingIncomDailies");

            migrationBuilder.DropTable(
                name: "PKG_Q_ParkingRecords");

            migrationBuilder.DropTable(
                name: "PKG_Q_ParkingSpaceMonitors");
        }
    }
}
