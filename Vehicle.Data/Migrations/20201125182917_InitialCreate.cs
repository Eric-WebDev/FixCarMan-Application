using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehicle.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleOwners",
                columns: table => new
                {
                    VehicleOwnerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleOwners", x => x.VehicleOwnerId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleProfiles",
                columns: table => new
                {
                    VehicleProfileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RegistrationYear = table.Column<string>(nullable: true),
                    CarMake = table.Column<string>(nullable: true),
                    CarModel = table.Column<string>(nullable: true),
                    BodyStyle = table.Column<string>(nullable: true),
                    Transmission = table.Column<string>(nullable: true),
                    FuelType = table.Column<string>(nullable: true),
                    NumberOfSeats = table.Column<int>(nullable: false),
                    NumberOfDoors = table.Column<int>(nullable: false),
                    EngineSize = table.Column<double>(nullable: false),
                    Vin = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    VehicleOwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleProfiles", x => x.VehicleProfileId);
                    table.ForeignKey(
                        name: "FK_VehicleProfiles_VehicleOwners_VehicleOwnerId",
                        column: x => x.VehicleOwnerId,
                        principalTable: "VehicleOwners",
                        principalColumn: "VehicleOwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Garages",
                columns: table => new
                {
                    GarageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    VehicleProfileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garages", x => x.GarageId);
                    table.ForeignKey(
                        name: "FK_Garages_VehicleProfiles_VehicleProfileId",
                        column: x => x.VehicleProfileId,
                        principalTable: "VehicleProfiles",
                        principalColumn: "VehicleProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NCTResults",
                columns: table => new
                {
                    NctResultId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Odometer = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ValidUntil = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    VehicleProfileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCTResults", x => x.NctResultId);
                    table.ForeignKey(
                        name: "FK_NCTResults_VehicleProfiles_VehicleProfileId",
                        column: x => x.VehicleProfileId,
                        principalTable: "VehicleProfiles",
                        principalColumn: "VehicleProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleServices",
                columns: table => new
                {
                    VehicleServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceDetails = table.Column<string>(nullable: true),
                    ServiceType = table.Column<int>(nullable: false),
                    InvoiceURL = table.Column<string>(nullable: true),
                    VehicleProfileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleServices", x => x.VehicleServiceId);
                    table.ForeignKey(
                        name: "FK_VehicleServices_VehicleProfiles_VehicleProfileId",
                        column: x => x.VehicleProfileId,
                        principalTable: "VehicleProfiles",
                        principalColumn: "VehicleProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Garages",
                columns: new[] { "GarageId", "City", "CompanyName", "County", "Street", "URL", "VehicleProfileId" },
                values: new object[] { 1, "Sligo", "GarageFix", "Sligo", "39 Connor Street", "www.GarageFix.test", null });

            migrationBuilder.CreateIndex(
                name: "IX_Garages_VehicleProfileId",
                table: "Garages",
                column: "VehicleProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_NCTResults_VehicleProfileId",
                table: "NCTResults",
                column: "VehicleProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleProfiles_VehicleOwnerId",
                table: "VehicleProfiles",
                column: "VehicleOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleServices_VehicleProfileId",
                table: "VehicleServices",
                column: "VehicleProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Garages");

            migrationBuilder.DropTable(
                name: "NCTResults");

            migrationBuilder.DropTable(
                name: "VehicleServices");

            migrationBuilder.DropTable(
                name: "VehicleProfiles");

            migrationBuilder.DropTable(
                name: "VehicleOwners");
        }
    }
}
