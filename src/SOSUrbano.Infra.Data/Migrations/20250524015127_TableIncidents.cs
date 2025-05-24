using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOSUrbano.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class TableIncidents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncidentSet_tb_institutions_InstitutionId",
                table: "IncidentSet");

            migrationBuilder.DropForeignKey(
                name: "FK_IncidentSet_tb_users_UserId",
                table: "IncidentSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncidentSet",
                table: "IncidentSet");

            migrationBuilder.RenameTable(
                name: "IncidentSet",
                newName: "tb_incidents");

            migrationBuilder.RenameIndex(
                name: "IX_IncidentSet_UserId",
                table: "tb_incidents",
                newName: "IX_tb_incidents_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_IncidentSet_InstitutionId",
                table: "tb_incidents",
                newName: "IX_tb_incidents_InstitutionId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "tb_incidents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "IncidentStatusId",
                table: "tb_incidents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "LatLocalization",
                table: "tb_incidents",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LongLocalization",
                table: "tb_incidents",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "TermsOfUse",
                table: "tb_incidents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_incidents",
                table: "tb_incidents",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "incident_statuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incident_statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_incident_photos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SavedPath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IncidentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_incident_photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_incident_photos_tb_incidents_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "tb_incidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_incidents_IncidentStatusId",
                table: "tb_incidents",
                column: "IncidentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_incident_photos_IncidentId",
                table: "tb_incident_photos",
                column: "IncidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_incidents_incident_statuses_IncidentStatusId",
                table: "tb_incidents",
                column: "IncidentStatusId",
                principalTable: "incident_statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_incidents_tb_institutions_InstitutionId",
                table: "tb_incidents",
                column: "InstitutionId",
                principalTable: "tb_institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_incidents_tb_users_UserId",
                table: "tb_incidents",
                column: "UserId",
                principalTable: "tb_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_incidents_incident_statuses_IncidentStatusId",
                table: "tb_incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_incidents_tb_institutions_InstitutionId",
                table: "tb_incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_incidents_tb_users_UserId",
                table: "tb_incidents");

            migrationBuilder.DropTable(
                name: "incident_statuses");

            migrationBuilder.DropTable(
                name: "tb_incident_photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_incidents",
                table: "tb_incidents");

            migrationBuilder.DropIndex(
                name: "IX_tb_incidents_IncidentStatusId",
                table: "tb_incidents");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "tb_incidents");

            migrationBuilder.DropColumn(
                name: "IncidentStatusId",
                table: "tb_incidents");

            migrationBuilder.DropColumn(
                name: "LatLocalization",
                table: "tb_incidents");

            migrationBuilder.DropColumn(
                name: "LongLocalization",
                table: "tb_incidents");

            migrationBuilder.DropColumn(
                name: "TermsOfUse",
                table: "tb_incidents");

            migrationBuilder.RenameTable(
                name: "tb_incidents",
                newName: "IncidentSet");

            migrationBuilder.RenameIndex(
                name: "IX_tb_incidents_UserId",
                table: "IncidentSet",
                newName: "IX_IncidentSet_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_incidents_InstitutionId",
                table: "IncidentSet",
                newName: "IX_IncidentSet_InstitutionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncidentSet",
                table: "IncidentSet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentSet_tb_institutions_InstitutionId",
                table: "IncidentSet",
                column: "InstitutionId",
                principalTable: "tb_institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentSet_tb_users_UserId",
                table: "IncidentSet",
                column: "UserId",
                principalTable: "tb_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
