using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehicle.Data.Migrations
{
    public partial class PhotoEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    IsMain = table.Column<bool>(nullable: false),
                    NctResultId = table.Column<int>(nullable: true),
                    VehicleProfileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_NCTResults_NctResultId",
                        column: x => x.NctResultId,
                        principalTable: "NCTResults",
                        principalColumn: "NctResultId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photo_VehicleProfiles_VehicleProfileId",
                        column: x => x.VehicleProfileId,
                        principalTable: "VehicleProfiles",
                        principalColumn: "VehicleProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photo_NctResultId",
                table: "Photo",
                column: "NctResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_VehicleProfileId",
                table: "Photo",
                column: "VehicleProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photo");
        }
    }
}
