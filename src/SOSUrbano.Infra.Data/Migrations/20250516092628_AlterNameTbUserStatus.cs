using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOSUrbano.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterNameTbUserStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_user_UserStatus_UserStatusId",
                table: "tb_user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserStatus",
                table: "UserStatus");

            migrationBuilder.RenameTable(
                name: "UserStatus",
                newName: "tb_user_status");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserTypeSet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "tb_user_status",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_user_status",
                table: "tb_user_status",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_user_tb_user_status_UserStatusId",
                table: "tb_user",
                column: "UserStatusId",
                principalTable: "tb_user_status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_user_tb_user_status_UserStatusId",
                table: "tb_user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_user_status",
                table: "tb_user_status");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserTypeSet");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "tb_user_status");

            migrationBuilder.RenameTable(
                name: "tb_user_status",
                newName: "UserStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserStatus",
                table: "UserStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_user_UserStatus_UserStatusId",
                table: "tb_user",
                column: "UserStatusId",
                principalTable: "UserStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
