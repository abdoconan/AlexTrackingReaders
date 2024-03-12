using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlexPortTracking.Migrations
{
    /// <inheritdoc />
    public partial class updatedColumnsInCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LogTime",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 12, 12, 51, 44, 215, DateTimeKind.Local).AddTicks(9206),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 11, 13, 30, 33, 32, DateTimeKind.Local).AddTicks(1057));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LogTime",
                table: "TransactionLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 12, 12, 51, 44, 216, DateTimeKind.Local).AddTicks(4311),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 11, 13, 30, 33, 32, DateTimeKind.Local).AddTicks(6967));

            migrationBuilder.AddColumn<int>(
                name: "CarModel",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LicenceExpiryDate",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "WeightInTon",
                table: "Cars",
                type: "DECIMAL(10,4)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarModel",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "LicenceExpiryDate",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "WeightInTon",
                table: "Cars");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LogTime",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 11, 13, 30, 33, 32, DateTimeKind.Local).AddTicks(1057),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 12, 12, 51, 44, 215, DateTimeKind.Local).AddTicks(9206));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LogTime",
                table: "TransactionLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 11, 13, 30, 33, 32, DateTimeKind.Local).AddTicks(6967),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 12, 12, 51, 44, 216, DateTimeKind.Local).AddTicks(4311));
        }
    }
}
