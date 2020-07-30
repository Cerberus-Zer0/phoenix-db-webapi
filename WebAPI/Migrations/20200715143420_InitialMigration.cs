using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Logo = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(maxLength: 3, nullable: true),
                    Postcode = table.Column<string>(maxLength: 4, nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(maxLength: 10, nullable: true),
                    ABN = table.Column<string>(maxLength: 11, nullable: true),
                    RTOProvider = table.Column<string>(maxLength: 5, nullable: true),
                    CRICOSCode = table.Column<string>(maxLength: 6, nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Youtube = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    LinkedIn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Institutions");
        }
    }
}
