using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestAPI.Data.Migrations
{
    public partial class CategoryIdChangedToRequiredInProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                table: "Categories",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 2, 17, 26, 37, 633, DateTimeKind.Utc).AddTicks(4780),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 29, 14, 54, 23, 451, DateTimeKind.Utc).AddTicks(6114));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 2, 17, 26, 37, 631, DateTimeKind.Utc).AddTicks(6933),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 29, 14, 54, 23, 449, DateTimeKind.Utc).AddTicks(8912));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 29, 14, 54, 23, 451, DateTimeKind.Utc).AddTicks(6114),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 5, 2, 17, 26, 37, 633, DateTimeKind.Utc).AddTicks(4780));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 29, 14, 54, 23, 449, DateTimeKind.Utc).AddTicks(8912),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 5, 2, 17, 26, 37, 631, DateTimeKind.Utc).AddTicks(6933));
        }
    }
}
