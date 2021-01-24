using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehicle.Data.Migrations
{
    public partial class PhotoEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garages_VehicleProfiles_VehicleProfileId",
                table: "Garages");

            migrationBuilder.DropForeignKey(
                name: "FK_NCTResults_VehicleProfiles_VehicleProfileNCTId",
                table: "NCTResults");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleProfiles_VehicleOwners_VehicleOwnerId",
                table: "VehicleProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleServices_VehicleProfiles_VehicleProfileId",
                table: "VehicleServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleProfiles",
                table: "VehicleProfiles");

            migrationBuilder.DropIndex(
                name: "IX_VehicleProfiles_VehicleOwnerId",
                table: "VehicleProfiles");

            migrationBuilder.DropIndex(
                name: "IX_NCTResults_VehicleProfileNCTId",
                table: "NCTResults");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "VehicleProfiles");

            migrationBuilder.DropColumn(
                name: "VehicleProfileNCTId",
                table: "NCTResults");

            migrationBuilder.AlterColumn<Guid>(
                name: "VehicleProfileId",
                table: "VehicleServices",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VehicleOwnerId",
                table: "VehicleProfiles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleProfileId",
                table: "VehicleProfiles",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleOwnerId1",
                table: "VehicleProfiles",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "VehicleOwnerId",
                table: "VehicleOwners",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<Guid>(
                name: "NctResultId",
                table: "NCTResults",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "VehicleProfileId",
                table: "NCTResults",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleProfileId1",
                table: "NCTResults",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "VehicleProfileId",
                table: "Garages",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GarageId",
                table: "Garages",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleProfiles",
                table: "VehicleProfiles",
                column: "VehicleProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleProfiles_VehicleOwnerId1",
                table: "VehicleProfiles",
                column: "VehicleOwnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_NCTResults_VehicleProfileId1",
                table: "NCTResults",
                column: "VehicleProfileId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Garages_VehicleProfiles_VehicleProfileId",
                table: "Garages",
                column: "VehicleProfileId",
                principalTable: "VehicleProfiles",
                principalColumn: "VehicleProfileId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NCTResults_VehicleProfiles_VehicleProfileId1",
                table: "NCTResults",
                column: "VehicleProfileId1",
                principalTable: "VehicleProfiles",
                principalColumn: "VehicleProfileId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleProfiles_VehicleOwners_VehicleOwnerId1",
                table: "VehicleProfiles",
                column: "VehicleOwnerId1",
                principalTable: "VehicleOwners",
                principalColumn: "VehicleOwnerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleServices_VehicleProfiles_VehicleProfileId",
                table: "VehicleServices",
                column: "VehicleProfileId",
                principalTable: "VehicleProfiles",
                principalColumn: "VehicleProfileId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garages_VehicleProfiles_VehicleProfileId",
                table: "Garages");

            migrationBuilder.DropForeignKey(
                name: "FK_NCTResults_VehicleProfiles_VehicleProfileId1",
                table: "NCTResults");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleProfiles_VehicleOwners_VehicleOwnerId1",
                table: "VehicleProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleServices_VehicleProfiles_VehicleProfileId",
                table: "VehicleServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleProfiles",
                table: "VehicleProfiles");

            migrationBuilder.DropIndex(
                name: "IX_VehicleProfiles_VehicleOwnerId1",
                table: "VehicleProfiles");

            migrationBuilder.DropIndex(
                name: "IX_NCTResults_VehicleProfileId1",
                table: "NCTResults");

            migrationBuilder.DropColumn(
                name: "VehicleProfileId",
                table: "VehicleProfiles");

            migrationBuilder.DropColumn(
                name: "VehicleOwnerId1",
                table: "VehicleProfiles");

            migrationBuilder.DropColumn(
                name: "VehicleProfileId",
                table: "NCTResults");

            migrationBuilder.DropColumn(
                name: "VehicleProfileId1",
                table: "NCTResults");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleProfileId",
                table: "VehicleServices",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VehicleOwnerId",
                table: "VehicleProfiles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "VehicleProfiles",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "VehicleOwnerId",
                table: "VehicleOwners",
                nullable: false,
                oldClrType: typeof(Guid))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "NctResultId",
                table: "NCTResults",
                nullable: false,
                oldClrType: typeof(Guid))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "VehicleProfileNCTId",
                table: "NCTResults",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VehicleProfileId",
                table: "Garages",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GarageId",
                table: "Garages",
                nullable: false,
                oldClrType: typeof(Guid))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleProfiles",
                table: "VehicleProfiles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleProfiles_VehicleOwnerId",
                table: "VehicleProfiles",
                column: "VehicleOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_NCTResults_VehicleProfileNCTId",
                table: "NCTResults",
                column: "VehicleProfileNCTId");

            migrationBuilder.AddForeignKey(
                name: "FK_Garages_VehicleProfiles_VehicleProfileId",
                table: "Garages",
                column: "VehicleProfileId",
                principalTable: "VehicleProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleServices_VehicleProfiles_VehicleProfileId",
                table: "VehicleServices",
                column: "VehicleProfileId",
                principalTable: "VehicleProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
