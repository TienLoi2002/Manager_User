using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manager_User_API.Migrations
{
    public partial class AddClaimValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClaimValue",
                table: "Claims",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClaimValue",
                table: "Claims");
        }
    }
}
