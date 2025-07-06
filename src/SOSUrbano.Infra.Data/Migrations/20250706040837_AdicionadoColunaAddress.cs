using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOSUrbano.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoColunaAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "tb_incidents",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "tb_incidents");
        }
    }
}
