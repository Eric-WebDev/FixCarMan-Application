using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehicle.Data.Migrations
{
    public partial class PhotoEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NCTResults_VehicleProfiles_VehicleProfileNCTId",
                table: "NCTResults");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleProfiles_VehicleOwners_VehicleOwnerId",
                table: "VehicleProfiles");

            migrationBuilder.DropIndex(
                name: "IX_NCTResults_VehicleProfileNCTId",
                table: "NCTResults");

            migrationBuilder.DropColumn(
                name: "VehicleProfileNCTId",
                table: "NCTResults");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VehicleServices",
                newName: "VehicleServiceId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VehicleProfiles",
                newName: "VehicleProfileId");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleOwnerId",
                table: "VehicleProfiles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleProfileId",
                table: "NCTResults",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NCTResults_VehicleProfileId",
                table: "NCTResults",
                column: "VehicleProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_NCTResults_VehicleProfiles_VehicleProfileId",
                table: "NCTResults",
                column: "VehicleProfileId",
                principalTable: "VehicleProfiles",
                principalColumn: "VehicleProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleProfiles_VehicleOwners_VehicleOwnerId",
                table: "VehicleProfiles",
                column: "VehicleOwnerId",
                principalTable: "VehicleOwners",
                principalColumn: "VehicleOwnerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NCTResults_VehicleProfiles_VehicleProfileId",
                table: "NCTResults");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleProfiles_VehicleOwners_VehicleOwnerId",
                table: "VehicleProfiles");

            migrationBuilder.DropIndex(
                name: "IX_NCTResults_VehicleProfileId",
                table: "NCTResults");

            migrationBuilder.DropColumn(
                name: "VehicleProfileId",
                table: "NCTResults");

            migrationBuilder.RenameColumn(
                name: "VehicleServiceId",
                table: "VehicleServices",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "VehicleProfileId",
                table: "VehicleProfiles",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleOwnerId",
                table: "VehicleProfiles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "VehicleProfileNCTId",
                table: "NCTResults",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NCTResults_VehicleProfileNCTId",
                table: "NCTResults",
                column: "VehicleProfileNCTId");

            migrationBuilder.AddForeignKey(
                name: "FK_NCTResults_VehicleProfiles_VehicleProfileNCTId",
                table: "NCTResults",
                column: "VehicleProfileNCTId",
                principalTable: "VehicleProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleProfiles_VehicleOwners_VehicleOwnerId",
                table: "VehicleProfiles",
                column: "VehicleOwnerId",
                principalTable: "VehicleOwners",
                principalColumn: "VehicleOwnerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
