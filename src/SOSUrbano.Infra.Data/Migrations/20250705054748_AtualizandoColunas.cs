using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOSUrbano.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoColunas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_incidents_incident_statuses_IncidentStatusId",
                table: "tb_incidents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_incident_statuses",
                table: "incident_statuses");

            migrationBuilder.RenameTable(
                name: "incident_statuses",
                newName: "tb_incident_statuses");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "tb_incidents",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_incident_statuses",
                table: "tb_incident_statuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_incidents_tb_incident_statuses_IncidentStatusId",
                table: "tb_incidents",
                column: "IncidentStatusId",
                principalTable: "tb_incident_statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_incidents_tb_incident_statuses_IncidentStatusId",
                table: "tb_incidents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_incident_statuses",
                table: "tb_incident_statuses");

            migrationBuilder.RenameTable(
                name: "tb_incident_statuses",
                newName: "incident_statuses");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "tb_incidents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddPrimaryKey(
                name: "PK_incident_statuses",
                table: "incident_statuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_incidents_incident_statuses_IncidentStatusId",
                table: "tb_incidents",
                column: "IncidentStatusId",
                principalTable: "incident_statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
