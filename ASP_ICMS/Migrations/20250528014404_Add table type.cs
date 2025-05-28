using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_ICMS.Migrations
{
    /// <inheritdoc />
    public partial class Addtabletype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "SOPMaster",
                newName: "Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusDate",
                table: "ChoiceList",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SOPMaster",
                newName: "id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusDate",
                table: "ChoiceList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
