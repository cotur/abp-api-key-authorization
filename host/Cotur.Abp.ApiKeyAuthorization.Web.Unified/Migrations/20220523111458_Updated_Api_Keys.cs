using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cotur.Abp.ApiKeyAuthorization.Migrations
{
    public partial class Updated_Api_Keys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "ApiKeyAuthorizationApiKeys",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "ApiKeyAuthorizationApiKeys",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "ApiKeyAuthorizationApiKeys");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "ApiKeyAuthorizationApiKeys");
        }
    }
}
