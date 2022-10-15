using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class UpdateName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("c7e23fdd-05ed-4bf3-bf39-72fc8e415e4e"));

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "ContactId", "Name" },
                values: new object[] { new Guid("4c233c11-2868-4dff-83fb-361c5b6f256b"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("4c233c11-2868-4dff-83fb-361c5b6f256b"));

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "ContactId", "Name" },
                values: new object[] { new Guid("c7e23fdd-05ed-4bf3-bf39-72fc8e415e4e"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "test" });
        }
    }
}
