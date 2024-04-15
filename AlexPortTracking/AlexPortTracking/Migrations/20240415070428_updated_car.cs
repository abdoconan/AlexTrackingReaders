using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlexPortTracking.Migrations
{
    /// <inheritdoc />
    public partial class updated_car : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LogTime",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 9, 4, 23, 583, DateTimeKind.Local).AddTicks(4743),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 14, 10, 7, 11, 446, DateTimeKind.Local).AddTicks(787));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LogTime",
                table: "TransactionLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 9, 4, 23, 584, DateTimeKind.Local).AddTicks(3828),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 14, 10, 7, 11, 446, DateTimeKind.Local).AddTicks(4910));

            migrationBuilder.AddColumn<int>(
                name: "CarClassId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarTypeId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GovernorateId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "Length",
                table: "Cars",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MaxLoadedWeight",
                table: "Cars",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "CarClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Governorate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorate", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarClassId",
                table: "Cars",
                column: "CarClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarTypeId",
                table: "Cars",
                column: "CarTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_GovernorateId",
                table: "Cars",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_CarClass_Description",
                table: "CarClass",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarType_Description",
                table: "CarType",
                column: "Description",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarClass_CarClassId",
                table: "Cars",
                column: "CarClassId",
                principalTable: "CarClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarType_CarTypeId",
                table: "Cars",
                column: "CarTypeId",
                principalTable: "CarType",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Governorate_GovernorateId",
                table: "Cars",
                column: "GovernorateId",
                principalTable: "Governorate",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarClass_CarClassId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarType_CarTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Governorate_GovernorateId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "CarClass");

            migrationBuilder.DropTable(
                name: "CarType");

            migrationBuilder.DropTable(
                name: "Governorate");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarClassId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarTypeId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_GovernorateId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarClassId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarTypeId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "GovernorateId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "MaxLoadedWeight",
                table: "Cars");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LogTime",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 14, 10, 7, 11, 446, DateTimeKind.Local).AddTicks(787),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 15, 9, 4, 23, 583, DateTimeKind.Local).AddTicks(4743));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LogTime",
                table: "TransactionLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 14, 10, 7, 11, 446, DateTimeKind.Local).AddTicks(4910),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 15, 9, 4, 23, 584, DateTimeKind.Local).AddTicks(3828));
        }
    }
}
