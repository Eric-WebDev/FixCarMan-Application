using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserProfile.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    ProfileDescription = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    IsUserGarage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersProfiles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UsersProfiles",
                columns: new[] { "Id", "Birthday", "City", "CompanyName", "County", "Email", "FirstName", "IsUserGarage", "LastName", "PhoneNumber", "ProfileDescription", "Street", "URL", "ZipCode" },
                values: new object[] { 1, null, "Sligo", "GarageFix", "Sligo", "GarageFix@email.com", "John", true, "Smyth", "0888555666", "the best service", "39 Connor Street", "www.GarageFix.test", "2GRE1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersProfiles");
        }
    }
}
