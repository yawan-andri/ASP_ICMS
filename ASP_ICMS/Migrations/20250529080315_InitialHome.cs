using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_ICMS.Migrations
{
    /// <inheritdoc />
    public partial class InitialHome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SOPMaster_ChoiceList_DivisionId",
                table: "SOPMaster");

            migrationBuilder.AddColumn<DateTime>(
                name: "StatusDate",
                table: "SOPMaster",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusDate",
                table: "ChoiceList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SOPMasterAuditType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SOPMasterId = table.Column<int>(type: "int", nullable: false),
                    SOPAuditTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOPMasterAuditType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SOPMasterAuditType_ChoiceList_SOPAuditTypeId",
                        column: x => x.SOPAuditTypeId,
                        principalTable: "ChoiceList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SOPMasterAuditType_SOPMaster_SOPMasterId",
                        column: x => x.SOPMasterId,
                        principalTable: "SOPMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SOPMasterType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SOPMasterId = table.Column<int>(type: "int", nullable: false),
                    SOPTypeId = table.Column<int>(type: "int", nullable: false),
                    DateAdd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOPMasterType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SOPMasterType_ChoiceList_SOPTypeId",
                        column: x => x.SOPTypeId,
                        principalTable: "ChoiceList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SOPMasterType_SOPMaster_SOPMasterId",
                        column: x => x.SOPMasterId,
                        principalTable: "SOPMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SOPMasterAuditType_SOPAuditTypeId",
                table: "SOPMasterAuditType",
                column: "SOPAuditTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SOPMasterAuditType_SOPMasterId",
                table: "SOPMasterAuditType",
                column: "SOPMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_SOPMasterType_SOPMasterId",
                table: "SOPMasterType",
                column: "SOPMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_SOPMasterType_SOPTypeId",
                table: "SOPMasterType",
                column: "SOPTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SOPMaster_ChoiceList_DivisionId",
                table: "SOPMaster",
                column: "DivisionId",
                principalTable: "ChoiceList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SOPMaster_ChoiceList_DivisionId",
                table: "SOPMaster");

            migrationBuilder.DropTable(
                name: "SOPMasterAuditType");

            migrationBuilder.DropTable(
                name: "SOPMasterType");

            migrationBuilder.DropColumn(
                name: "StatusDate",
                table: "SOPMaster");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusDate",
                table: "ChoiceList",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_SOPMaster_ChoiceList_DivisionId",
                table: "SOPMaster",
                column: "DivisionId",
                principalTable: "ChoiceList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
