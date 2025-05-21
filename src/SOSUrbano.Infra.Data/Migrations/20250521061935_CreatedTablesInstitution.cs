using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOSUrbano.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatedTablesInstitution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InstitutionId",
                table: "IncidentSet",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "tb_institution_statuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_institution_statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_institution_types",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_institution_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_institutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    UrlSite = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InstitutionStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstitutionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_institutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_institutions_tb_institution_statuses_InstitutionStatusId",
                        column: x => x.InstitutionStatusId,
                        principalTable: "tb_institution_statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_institutions_tb_institution_types_InstitutionTypeId",
                        column: x => x.InstitutionTypeId,
                        principalTable: "tb_institution_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_institution_emails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InstitutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_institution_emails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_institution_emails_tb_institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "tb_institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_institution_phones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    InstitutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_institution_phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_institution_phones_tb_institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "tb_institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IncidentSet_InstitutionId",
                table: "IncidentSet",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_institution_emails_InstitutionId",
                table: "tb_institution_emails",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_institution_phones_InstitutionId",
                table: "tb_institution_phones",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_institutions_InstitutionStatusId",
                table: "tb_institutions",
                column: "InstitutionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_institutions_InstitutionTypeId",
                table: "tb_institutions",
                column: "InstitutionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentSet_tb_institutions_InstitutionId",
                table: "IncidentSet",
                column: "InstitutionId",
                principalTable: "tb_institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncidentSet_tb_institutions_InstitutionId",
                table: "IncidentSet");

            migrationBuilder.DropTable(
                name: "tb_institution_emails");

            migrationBuilder.DropTable(
                name: "tb_institution_phones");

            migrationBuilder.DropTable(
                name: "tb_institutions");

            migrationBuilder.DropTable(
                name: "tb_institution_statuses");

            migrationBuilder.DropTable(
                name: "tb_institution_types");

            migrationBuilder.DropIndex(
                name: "IX_IncidentSet_InstitutionId",
                table: "IncidentSet");

            migrationBuilder.DropColumn(
                name: "InstitutionId",
                table: "IncidentSet");
        }
    }
}
