using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosApi.Migrations
{
    public partial class Adicionandocustomidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e858b9ad-d70b-4885-a80b-4b7e1ac9c83f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "7bbd42c1-781a-4ee3-995d-1a1463341a3a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "776a3087-2854-4a6c-a2c2-8bac4c135c2a", "AQAAAAEAACcQAAAAENfoBxFM/zLtOOmXF9nmsSi3jrZ1GQ9A65N+tfYNP2+8QBquPSaLgUXmjnxULpMZVQ==", "d95acb27-2b8f-4eea-b073-e1c6aa7294fc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7c197994-bb8c-4b15-a29d-bf060540eb06");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "1a96f371-f5b7-42dc-be5e-1fd5d0872f7a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e4f4977-0fed-41e2-95f0-fb6511fd0883", "AQAAAAEAACcQAAAAEMR0yjfKTVpCTh/uH4MWw7WmVZ5x9mN9+MwhsM8L/jCN69Q5tefbvOR6S9Rpks4JbA==", "e3917aa6-c201-4a14-ac63-8f8f7d5df647" });
        }
    }
}
