using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosApi.Migrations
{
    public partial class Criandoroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7c197994-bb8c-4b15-a29d-bf060540eb06");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 2, "1a96f371-f5b7-42dc-be5e-1fd5d0872f7a", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e4f4977-0fed-41e2-95f0-fb6511fd0883", "AQAAAAEAACcQAAAAEMR0yjfKTVpCTh/uH4MWw7WmVZ5x9mN9+MwhsM8L/jCN69Q5tefbvOR6S9Rpks4JbA==", "e3917aa6-c201-4a14-ac63-8f8f7d5df647" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "0a13b1cf-4ad0-43ae-848e-041de96699a3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1190f07d-ea0a-4627-bfec-cac638ff4342", "AQAAAAEAACcQAAAAEOEQarBPIMIDzDPp8yGJRHqhPzr6EuGGee+SWkSVLs08moQ8YcvJb5zKfuISesahUA==", "4b827709-cb94-4c7e-8b0b-aa03a75eae78" });
        }
    }
}
