using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cotur.Abp.ApiKeyAuthorization.Migrations
{
    public partial class Added_Unique_Constraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ApiKeyAuthorizationApiKeys_Key",
                table: "ApiKeyAuthorizationApiKeys");

            migrationBuilder.DropIndex(
                name: "IX_ApiKeyAuthorizationApiKeys_Key_Active_ExpireAt",
                table: "ApiKeyAuthorizationApiKeys");

            migrationBuilder.CreateIndex(
                name: "IX_ApiKeyAuthorizationApiKeys_Key",
                table: "ApiKeyAuthorizationApiKeys",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiKeyAuthorizationApiKeys_Key_Active_ExpireAt",
                table: "ApiKeyAuthorizationApiKeys",
                columns: new[] { "Key", "Active", "ExpireAt" },
                unique: true,
                filter: "[ExpireAt] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ApiKeyAuthorizationApiKeys_Key",
                table: "ApiKeyAuthorizationApiKeys");

            migrationBuilder.DropIndex(
                name: "IX_ApiKeyAuthorizationApiKeys_Key_Active_ExpireAt",
                table: "ApiKeyAuthorizationApiKeys");

            migrationBuilder.CreateIndex(
                name: "IX_ApiKeyAuthorizationApiKeys_Key",
                table: "ApiKeyAuthorizationApiKeys",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_ApiKeyAuthorizationApiKeys_Key_Active_ExpireAt",
                table: "ApiKeyAuthorizationApiKeys",
                columns: new[] { "Key", "Active", "ExpireAt" });
        }
    }
}
