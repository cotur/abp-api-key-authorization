using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cotur.Abp.ApiKeyAuthorization.Migrations
{
    public partial class Updated_Api_Keys_Expire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ApiKeyAuthorizationApiKeys_Key_TenantId_Active",
                table: "ApiKeyAuthorizationApiKeys");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireAt",
                table: "ApiKeyAuthorizationApiKeys",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiKeyAuthorizationApiKeys_Key_Active_ExpireAt",
                table: "ApiKeyAuthorizationApiKeys",
                columns: new[] { "Key", "Active", "ExpireAt" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ApiKeyAuthorizationApiKeys_Key_Active_ExpireAt",
                table: "ApiKeyAuthorizationApiKeys");

            migrationBuilder.DropColumn(
                name: "ExpireAt",
                table: "ApiKeyAuthorizationApiKeys");

            migrationBuilder.CreateIndex(
                name: "IX_ApiKeyAuthorizationApiKeys_Key_TenantId_Active",
                table: "ApiKeyAuthorizationApiKeys",
                columns: new[] { "Key", "TenantId", "Active" });
        }
    }
}
