using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOSUrbano.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTbUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TermsOfUse",
                table: "tb_incidents");

            migrationBuilder.AddColumn<bool>(
                name: "TermsOfUse",
                table: "tb_users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TermsOfUse",
                table: "tb_users");

            migrationBuilder.AddColumn<bool>(
                name: "TermsOfUse",
                table: "tb_incidents",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
