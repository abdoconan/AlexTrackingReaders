using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlexPortTracking.Migrations
{
    /// <inheritdoc />
    public partial class updatedColumnLengthInTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LogTime",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 14, 10, 7, 11, 446, DateTimeKind.Local).AddTicks(787),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 12, 12, 51, 44, 215, DateTimeKind.Local).AddTicks(9206));

            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                table: "TransactionLogs",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LogTime",
                table: "TransactionLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 14, 10, 7, 11, 446, DateTimeKind.Local).AddTicks(4910),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 12, 12, 51, 44, 216, DateTimeKind.Local).AddTicks(4311));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LogTime",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 12, 12, 51, 44, 215, DateTimeKind.Local).AddTicks(9206),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 14, 10, 7, 11, 446, DateTimeKind.Local).AddTicks(787));

            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                table: "TransactionLogs",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LogTime",
                table: "TransactionLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 12, 12, 51, 44, 216, DateTimeKind.Local).AddTicks(4311),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 14, 10, 7, 11, 446, DateTimeKind.Local).AddTicks(4910));
        }
    }
}
